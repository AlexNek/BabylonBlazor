using Microsoft.JSInterop;

namespace Babylon.Blazor
{
    /// <summary>
    /// Interface IJsLibInstanceGetter
    /// </summary>
    internal interface IJsLibInstanceGetter
    {
        /// <summary>
        /// Gets the babylon instance.
        /// </summary>
        /// <value>The babylon instance.</value>
        public IJSInProcessObjectReference BabylonInstance { get; }
    }
}
