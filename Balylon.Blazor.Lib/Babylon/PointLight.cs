using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class PointLight.
    /// Implements the <see cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.Babylon.BabylonObject" />
    public class PointLight : BabylonObject
    {
        //public PointLight(IJSRuntime jsRuntime, JsRuntimeObjectRef objRef) : base(jsRuntime, objRef) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PointLight"/> class.
        /// </summary>
        /// <param name="jsObjRef">The js object reference.</param>
        public PointLight(IJSObjectReference jsObjRef) : base(jsObjRef) { }
    }
}
