using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    public class SpriteManager : BabylonObject, IJsLibInstanceGetter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpriteManager"/> class.
        /// </summary>
        /// <param name="jsObjRef">The js object reference.</param>
        /// <param name="babylonInstance">The babylon instance.</param>
        public SpriteManager(IJSObjectReference jsObjRef, IJSInProcessObjectReference babylonInstance)
            : base(jsObjRef)
        {
            BabylonInstance = babylonInstance;
        }

        public async Task<Sprite> CreateSprite(string name)
        {
            var sprite = await BabylonInstance.InvokeAsync<IJSObjectReference>(
                             "сreateSprite",
                             name,
                             JsObjRef);
            return new Sprite(sprite, BabylonInstance);
        }

        /// <summary>
        /// Gets the babylon instance.
        /// </summary>
        /// <value>The babylon instance.</value>
        public IJSInProcessObjectReference BabylonInstance { get; }
    }
}
