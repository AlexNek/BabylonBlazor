using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class BabylonObject.
    /// Base object
    /// </summary>
    public abstract class BabylonObject
    {
        private readonly IJSObjectReference _jsObjRef;

        /// <summary>
        /// Initializes a new instance of the <see cref="BabylonObject"/> class.
        /// </summary>
        /// <param name="jsObjRef">The js object reference.</param>
        protected BabylonObject(IJSObjectReference jsObjRef)
        {
            _jsObjRef = jsObjRef;
        }

        /// <summary>
        /// Gets the js object reference.
        /// </summary>
        /// <value>The js object reference.</value>
        public IJSObjectReference JsObjRef
        {
            get
            {
                return _jsObjRef;
            }
        }
    }
}
