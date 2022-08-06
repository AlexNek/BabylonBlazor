#nullable enable
using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    public class Sprite : BabylonObject, IJsLibInstanceGetter
    {
        public Sprite(IJSObjectReference jsObjRef, IJSInProcessObjectReference babylonInstance)
            : base(jsObjRef)
        {
            BabylonInstance = babylonInstance;
        }
        
        public async Task PlayAnimation(
            int fromKey,
            int toKey,
            bool isInLoop,
            int startDelayMs,
            DotNetObjectReference<MessageUpdateInvokeHelper>? onAnimationEndObjRef=null)
        {
            await BabylonInstance.InvokeVoidAsync(
                "playAnimation",
                fromKey,
                toKey,
                isInLoop,
                startDelayMs, onAnimationEndObjRef,
                JsObjRef);
        }

        /// <summary>
        /// Gets the babylon instance.
        /// </summary>
        /// <value>The babylon instance.</value>
        public IJSInProcessObjectReference BabylonInstance { get; }
    }
}
