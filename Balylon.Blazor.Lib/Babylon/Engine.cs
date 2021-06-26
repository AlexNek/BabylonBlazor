using System;
using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class Engine.
    /// The engine class is responsible for interfacing with all lower-level APIs such as WebGL
    /// Implements the <see cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// Implements the <see cref="Babylon.Blazor.IJsLibInstanceGetter" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// <seealso cref="Babylon.Blazor.IJsLibInstanceGetter" />
    public class Engine : BabylonObject, IJsLibInstanceGetter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Engine"/> class.
        /// </summary>
        /// <param name="jsObjRef">The js object reference.</param>
        /// <param name="babylonInstance">The babylon instance.</param>
        public Engine(IJSObjectReference jsObjRef, IJSInProcessObjectReference babylonInstance)
            : base(jsObjRef)
        {
            BabylonInstance = babylonInstance;
        }


        //public Engine(IJSRuntime jsRuntime, JsRuntimeObjectRef objRef) : base(jsRuntime, objRef) { }
        /// <summary>
        /// Creates the scene.
        /// </summary>
        /// <returns>Scene.</returns>
        public async Task<Scene> CreateScene()
        {
            var jsScene = await BabylonInstance.InvokeAsync<IJSObjectReference>("createScene", JsObjRef);
            return new Scene(jsScene, BabylonInstance);
        }

        /// <summary>
        /// Gets the babylon instance.
        /// </summary>
        /// <value>The babylon instance.</value>
        public IJSInProcessObjectReference BabylonInstance { get; }
    }
}
