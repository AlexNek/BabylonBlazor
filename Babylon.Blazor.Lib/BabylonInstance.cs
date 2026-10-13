using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

using Babylon.Blazor.Babylon;
using Babylon.Blazor.Babylon.Parameters;

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
    public class BabylonInstance : IAsyncDisposable
    {
        private readonly IJSObjectReference _babylonWrapper;
        private readonly IJSRuntime _jSInstance;
        private readonly string _canvasId;

        /// <summary>
        /// Initializes a new instance of the <see cref="BabylonInstance"/> class.
        /// </summary>
        /// <param name="jSInstance">The j s instance.</param>
        /// <param name="babylonWrapper">The babylon wrapper.</param>
        /// <param name="canvasId">The canvas identifier.</param>
        public BabylonInstance(IJSRuntime jSInstance, IJSObjectReference babylonWrapper, string canvasId)
        {
            _jSInstance = jSInstance;

            _babylonWrapper = babylonWrapper;
            _canvasId = canvasId;
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

        public async Task<Color4> CreateColor4(Color color)
        {
            var jsColor4 = await _babylonWrapper.InvokeAsync<IJSObjectReference>(
                               "createColor4",
                               color.R / 255.0,
                               color.G / 255.0,
                               color.B / 255.0,
                               color.A / 255.0);
            return new Color4(jsColor4);
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

        public async Task<BoxOptions.FaceColorsObj> CreateFaceColors(Color color)
        {
            var objRef = await _babylonWrapper.InvokeAsync<IJSObjectReference>(
                               "createFaceColors",
                               color.R / 255.0,
                               color.G / 255.0,
                               color.B / 255.0,
                               color.A / 255.0);
            return new BoxOptions.FaceColorsObj(objRef);
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
        public async ValueTask DisposeAsync()
        {
            try
            {
                await _babylonWrapper.InvokeVoidAsync("cleanup", _canvasId);
            }
            catch (Exception ex)
            {
                try
                {
                    await _jSInstance.InvokeVoidAsync("console.warn", $"BabylonInstance.DisposeAsync cleanup failed: {ex.Message}");
                }
                catch
                {
                    // swallow — best-effort diagnostic logging
                }
            }

            if (_babylonWrapper is IJSInProcessObjectReference babylonWrapper)
            {
                babylonWrapper.Dispose();
            }
            else
            {
                await _babylonWrapper.DisposeAsync();
            }
        }

        public async Task DrawText(string canvasId, string text, Color color, int x = 0, int y = 16, string fontText = "15px Arial")
        {
            //canvasId,x,y,text, fontText, colorText
            await _babylonWrapper.InvokeVoidAsync("drawText", canvasId, x, y, text, fontText, color.Name);
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
