using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class DynamicTexture.
    /// Implements the <see cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.Babylon.BabylonObject" />
    public class DynamicTexture : BabylonObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTexture"/> class.
        /// </summary>
        /// <param name="jsObjRef">The js object reference.</param>
        public DynamicTexture(IJSObjectReference jsObjRef)
            : base(jsObjRef)
        {
        }
    }
}