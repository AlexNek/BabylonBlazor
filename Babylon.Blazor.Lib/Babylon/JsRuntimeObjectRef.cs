using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class JsRuntimeObjectRef.
    /// Implements the <see cref="System.IAsyncDisposable" />
    /// </summary>
    /// <seealso cref="System.IAsyncDisposable" />
    public class JsRuntimeObjectRef : IAsyncDisposable
    {
        /// <summary>
        /// Gets or sets the js runtime.
        /// </summary>
        /// <value>The js runtime.</value>
        internal IJSRuntime JSRuntime { get; set; }

        /// <summary>
        /// Gets or sets the js object reference identifier.
        /// </summary>
        /// <value>The js object reference identifier.</value>
        [JsonPropertyName("__jsObjRefId")]
        public int JsObjectRefId { get; set; }

        /// <summary>
        /// dispose as an asynchronous operation.
        /// </summary>
        /// <returns>ValueTask.</returns>
        public async ValueTask DisposeAsync()
        {
            await JSRuntime.InvokeVoidAsync("babylonInterop.removeObjectRef", JsObjectRefId);
        }
    }
}
