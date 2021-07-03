using System;
using System.Drawing;
using System.Threading.Tasks;

using Babylon.Blazor.Babylon;

using Microsoft.JSInterop;

namespace Babylon.Blazor
{
    /// <summary>
    /// Class BabylonInstance.
    /// Interop class to Babylon JS library
    /// for common objects and actions
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class BabylonInstance : IDisposable
    {
        private readonly IJSInProcessObjectReference _babylonWrapper;

        private readonly IJSRuntime _jSInstance;

        /// <summary>
        /// Initializes a new instance of the <see cref="BabylonInstance"/> class.
        /// </summary>
        /// <param name="jSInstance">The j s instance.</param>
        /// <param name="babylonWrapper">The babylon wrapper.</param>
        public BabylonInstance(IJSRuntime jSInstance, IJSInProcessObjectReference babylonWrapper)
        {
            _jSInstance = jSInstance;

            _babylonWrapper = babylonWrapper;
        }

        /// <summary>
        /// Creates the color3.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Color3.</returns>
        public async Task<Color3> CreateColor3(Color color)
        {
            var jsColor3 = await _babylonWrapper.InvokeAsync<IJSObjectReference>("createColor3", color.R / 255.0, color.G / 255.0, color.B / 255.0);
            return new Color3(jsColor3);
        }

        public async Task DrawText(string canvasId, string text, Color color, int x=0, int y=16, string fontText= "15px Arial")
        {
            //canvasId,x,y,text, fontText, colorText
            await _babylonWrapper.InvokeVoidAsync("drawText", canvasId, x, y, text, fontText, color.Name);

        }

        /// <summary>
        /// Creates the engine.
        /// </summary>
        /// <param name="canvasId">The canvas identifier.</param>
        /// <param name="antialias">if set to <c>true</c> [antialias].</param>
        /// <returns>Engine.</returns>
        public async Task<Engine> CreateEngine(string canvasId, bool antialias = false)
        {
            await _jSInstance.InvokeVoidAsync("console.log", $"***CreateEngine {_babylonWrapper}");
            var jsEngine = await _babylonWrapper.InvokeAsync<IJSObjectReference>("createEngine", canvasId, antialias);
            //var jsEngine = await _babylonWrapper.InvokeAsync<IJSObjectReference>("createEngine", "canvasId", true);
            return new Engine(jsEngine, _babylonWrapper);
        }

        /// <summary>
        /// Creates the grid.
        /// </summary>
        /// <param name="sizeX">The size x.</param>
        /// <param name="sizeY">The size y.</param>
        /// <param name="step">The step.</param>
        /// <param name="color">The color.</param>
        public async Task CreateGrid(double sizeX, double sizeY, double step, Color color)
        {
            var jsColor3 = await _babylonWrapper.InvokeAsync<IJSObjectReference>("createColor3", color.R / 255.0, color.G / 255.0, color.B / 255.0);
            await _babylonWrapper.InvokeVoidAsync("createGrid", sizeX, sizeY, step, jsColor3);
        }

        /// <summary>
        /// Creates the test scene.
        /// </summary>
        /// <param name="canvasId">The canvas identifier.</param>
        /// <returns>Scene.</returns>
        public async Task<Scene> CreateTestScene(string canvasId)
        {
            var jsScene = await _babylonWrapper.InvokeAsync<IJSObjectReference>("createTestScene", canvasId);
            return new Scene(jsScene, _babylonWrapper);
        }

        /// <summary>
        /// Creates the vector3.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <returns>Vector3.</returns>
        public async Task<Vector3> CreateVector3(double x, double y, double z)
        {
            var jsScene = await _babylonWrapper.InvokeAsync<IJSObjectReference>("createVector3", x, y, z);
            return new Vector3(jsScene);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _babylonWrapper.Dispose();
        }

        /// <summary>
        /// Runs the render loop.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <param name="scene">The scene.</param>
        public async Task RunRenderLoop(Engine engine, Scene scene)
        {
            await _babylonWrapper.InvokeVoidAsync("runRenderLoop", engine.JsObjRef, scene.JsObjRef);
        }
    }
}
//https://playground.babylonjs.com
//https://doc.babylonjs.com/
