using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class Color3. RGB color
    /// Implements the <see cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.Babylon.BabylonObject" />
    public class Color3 : BabylonObject
    {
        //public Color3(IJSRuntime jsRuntime, JsRuntimeObjectRef objRef) : base(jsRuntime, objRef) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Color3"/> class.
        /// </summary>
        /// <param name="jsObjRef">The js object reference.</param>
        public Color3(IJSObjectReference jsObjRef) : base(jsObjRef) { }
    }
}
