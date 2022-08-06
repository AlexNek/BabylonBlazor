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
                startDelayMs, 
                onAnimationEndObjRef,
                JsObjRef);
        }

        public async Task SetPickable(bool pickable)
        {
            await BabylonInstance.InvokeVoidAsync(
                "setPickable",
                pickable,
                JsObjRef);
        }

        public async Task SetPosition(Vector3 position)
        {
            await BabylonInstance.InvokeVoidAsync(
                "setPosition",
                position.JsObjRef,
                JsObjRef);
        }

        public async Task SetInvert(bool invertU, bool invertV)
        {
            await BabylonInstance.InvokeVoidAsync(
                "setInvert",
                invertU, 
                invertV,
                JsObjRef);
        }
        /// <summary>
        /// Sets the size.
        /// </summary>
        /// <param name="height">The height. 0..1</param>
        /// <param name="width">The width. 0..1</param>
        public async Task SetSize(double height, double width)
        {
            await BabylonInstance.InvokeVoidAsync(
                "setSize",
                height,
                width,
                JsObjRef);
        }

        public async Task SetFrameNumber(int frameNumber)
        {
            await BabylonInstance.InvokeVoidAsync(
                "setFrameNumber",
                frameNumber,
                JsObjRef);
        }

        /// <summary>
        /// Gets the babylon instance.
        /// </summary>
        /// <value>The babylon instance.</value>
        public IJSInProcessObjectReference BabylonInstance { get; }

        public async Task SetAngle(double angleRadian)
        {
            await BabylonInstance.InvokeVoidAsync(
                "setAngle",
                angleRadian,
                JsObjRef);
        }
    }
}
