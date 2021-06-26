using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class ArcRotateCamera.
    /// This camera always points towards a given target position and can be rotated around that target with the target as the center of rotation
    /// https://doc.babylonjs.com/divingDeeper/cameras/camera_introduction#constructing-an-arc-rotate-camera
    /// Implements the <see cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// Implements the <see cref="Babylon.Blazor.IJsLibInstanceGetter" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// <seealso cref="Babylon.Blazor.IJsLibInstanceGetter" />
    public class ArcRotateCamera : BabylonObject, IJsLibInstanceGetter
    {
        //public ArcRotateCamera(IJSRuntime jsRuntime, JsRuntimeObjectRef objRef) : base(jsRuntime, objRef) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ArcRotateCamera"/> class.
        /// </summary>
        /// <param name="jsObjRef">The js object reference.</param>
        /// <param name="babylonInstance">The babylon instance.</param>
        public ArcRotateCamera(IJSObjectReference jsObjRef, IJSInProcessObjectReference babylonInstance)
            : base(jsObjRef)
        {
            BabylonInstance = babylonInstance;
        }

        /// <summary>
        /// Sets the automatic rotate.
        /// </summary>
        /// <param name="useAutoRotate">if set to <c>true</c> then use automatic rotate.</param>
        /// <param name="idleRotationSpeed">The idle rotation speed.</param>
        public async Task SetAutoRotate(bool useAutoRotate, double idleRotationSpeed)
        {
            await BabylonInstance.InvokeVoidAsync("setAutoRotate", JsObjRef, useAutoRotate, idleRotationSpeed);
        }

        /// <summary>
        /// Gets the babylon instance.
        /// </summary>
        /// <value>The babylon instance.</value>
        public IJSInProcessObjectReference BabylonInstance { get; }
    }
}
