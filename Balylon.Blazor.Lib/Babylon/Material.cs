using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class Material.
    /// Implements the <see cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// Implements the <see cref="Babylon.Blazor.IJsLibInstanceGetter" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// <seealso cref="Babylon.Blazor.IJsLibInstanceGetter" />
    public class Material : BabylonObject, IJsLibInstanceGetter
    {
        //public Material(IJSRuntime jsRuntime, JsRuntimeObjectRef objRef) : base(jsRuntime, objRef) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Material"/> class.
        /// </summary>
        /// <param name="jsObjRef">The js object reference.</param>
        /// <param name="babylonInstance">The babylon instance.</param>
        public Material(IJSObjectReference jsObjRef, IJSInProcessObjectReference babylonInstance)
            : base(jsObjRef)
        {
            BabylonInstance = babylonInstance;
        }
        /// <summary>
        /// Sets the texture.
        /// </summary>
        /// <param name="texture">The texture.</param>
        public void SetTexture(DynamicTexture texture)
        {
            BabylonInstance.InvokeAsync<object>("setMaterialTexture", JsObjRef, texture.JsObjRef);
        }

        /// <summary>
        /// Gets the babylon instance.
        /// </summary>
        /// <value>The babylon instance.</value>
        public IJSInProcessObjectReference BabylonInstance
        {
            get;
        }

    }
}
