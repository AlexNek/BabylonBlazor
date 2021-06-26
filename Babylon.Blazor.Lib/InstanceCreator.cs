using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Babylon.Blazor
{
    /// <summary>
    /// Class InstanceCreator.
    /// </summary>
    public class InstanceCreator
    {
        /// <summary>
        /// The j s instance
        /// </summary>
        private readonly IJSRuntime _jSInstance;

        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceCreator"/> class.
        /// </summary>
        /// <param name="jSInstance">The j s instance.</param>
        public InstanceCreator(IJSRuntime jSInstance)
        {
            this._jSInstance = jSInstance;
        }

        /// <summary>
        /// create babylon as an asynchronous operation.
        /// </summary>
        /// <returns>System.Threading.Tasks.Task&lt;Babylon.Blazor.BabylonInstance&gt;.</returns>
        public async Task<BabylonInstance> CreateBabylonAsync()
        {
           
            IJSInProcessObjectReference babylonWrapper = await _jSInstance.InvokeAsync<IJSInProcessObjectReference>("import",
                                                             "./_content/Babylon.Blazor/babylonInterop.js");
            return new(_jSInstance, babylonWrapper);
        }
    }
}