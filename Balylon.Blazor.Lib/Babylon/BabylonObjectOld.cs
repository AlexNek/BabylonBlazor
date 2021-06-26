using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class BabylonObjectOld.
    /// Implements the <see cref="Microsoft.JSInterop.IJSObjectReference" />
    /// </summary>
    /// <seealso cref="Microsoft.JSInterop.IJSObjectReference" />
    public abstract class BabylonObjectOld: IJSObjectReference
    {
        /// <summary>
        /// The js object reference
        /// </summary>
        protected JsRuntimeObjectRef _jsObjRef;

        /// <summary>
        /// Gets the js object reference identifier.
        /// </summary>
        /// <value>The js object reference identifier.</value>
        [JsonPropertyName("__jsObjRefId")]
        public int JsObjectRefId => _jsObjRef.JsObjectRefId;

        /// <summary>
        /// Initializes a new instance of the <see cref="BabylonObjectOld"/> class.
        /// </summary>
        /// <param name="jsRuntime">The js runtime.</param>
        /// <param name="objRef">The object reference.</param>
        protected BabylonObjectOld(IJSRuntime jsRuntime, JsRuntimeObjectRef objRef)
        {
            _jsObjRef = objRef;
            _jsObjRef.JSRuntime = jsRuntime;
        }

        /// <summary>
        /// Alerts the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void Alert(object obj)
        {
            _jsObjRef.JSRuntime.InvokeVoidAsync("alert", obj); 

        }

        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// <para><see cref="T:Microsoft.JSInterop.JSRuntime" /> will apply timeouts to this operation based on the value configured in <see cref="P:Microsoft.JSInterop.JSRuntime.DefaultAsyncTimeout" />. To dispatch a call with a different, or no timeout,
        /// consider using <see cref="M:Microsoft.JSInterop.IJSObjectReference.InvokeAsync``1(System.String,System.Threading.CancellationToken,System.Object[])" />.
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>someScope.someFunction</c> on the target instance.</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>An instance of <typeparamref name="TValue" /> obtained by JSON-deserializing the return value.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object[] args)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Invokes the specified JavaScript function asynchronously.
        /// </summary>
        /// <typeparam name="TValue">The JSON-serializable return type.</typeparam>
        /// <param name="identifier">An identifier for the function to invoke. For example, the value <c>"someScope.someFunction"</c> will invoke the function <c>someScope.someFunction</c> on the target instance.</param>
        /// <param name="cancellationToken">A cancellation token to signal the cancellation of the operation. Specifying this parameter will override any default cancellations such as due to timeouts
        /// (<see cref="P:Microsoft.JSInterop.JSRuntime.DefaultAsyncTimeout" />) from being applied.</param>
        /// <param name="args">JSON-serializable arguments.</param>
        /// <returns>An instance of <typeparamref name="TValue" /> obtained by JSON-deserializing the return value.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object[] args)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Disposes the asynchronous.
        /// </summary>
        /// <returns>ValueTask.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public ValueTask DisposeAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
