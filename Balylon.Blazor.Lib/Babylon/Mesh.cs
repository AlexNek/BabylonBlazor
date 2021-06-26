using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class Mesh.
    /// Implements the <see cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// Implements the <see cref="Babylon.Blazor.IJsLibInstanceGetter" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// <seealso cref="Babylon.Blazor.IJsLibInstanceGetter" />
    public class Mesh : BabylonObject, IJsLibInstanceGetter
    {
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Mesh"/> class.
        /// </summary>
        /// <param name="jsObjRef">The js object reference.</param>
        /// <param name="babylonInstance">The babylon instance.</param>
        public Mesh(IJSObjectReference jsObjRef, IJSInProcessObjectReference babylonInstance)
            : base(jsObjRef)
        {
            BabylonInstance = babylonInstance;
        }
        
        /// <summary>
        /// Sets the material.
        /// </summary>
        /// <param name="mat">The mat.</param>
        public void SetMaterial(Material mat)
        {
            BabylonInstance.InvokeAsync<object>("setMaterial", JsObjRef, mat.JsObjRef);
        }

        /// <summary>
        /// Gets the babylon instance.
        /// </summary>
        /// <value>The babylon instance.</value>
        public IJSInProcessObjectReference BabylonInstance { get; }
    }
}
