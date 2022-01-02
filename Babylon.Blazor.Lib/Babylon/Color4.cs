using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class Color4.
    /// Hold a RBGA color
    /// Implements the <see cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.Babylon.BabylonObject" />
    public class Color4 : BabylonObject
    {
        public Color4(IJSObjectReference jsObjRef) : base(jsObjRef) { }
    }
}
