using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class HemisphericLight.
    /// Implements the <see cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.Babylon.BabylonObject" />
    public class HemisphericLight : BabylonObject
    {
        //public HemisphericLight(IJSRuntime jsRuntime, JsRuntimeObjectRef objRef) : base(jsRuntime, objRef) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="HemisphericLight"/> class.
        /// </summary>
        /// <param name="jsObjRef">The js object reference.</param>
        public HemisphericLight(IJSObjectReference jsObjRef) : base(jsObjRef) { }
    }
}
