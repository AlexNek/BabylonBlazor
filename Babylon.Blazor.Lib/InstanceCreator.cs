using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Babylon.Blazor
{
    /// <summary>
    /// Class InstanceCreator.
    /// </summary>
    public class InstanceCreator : InstanceCreatorBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceCreator"/> class.
        /// </summary>
        /// <param name="jSInstance">The j s instance.</param>
        public InstanceCreator(IJSRuntime jSInstance)
            : base(jSInstance)
        {
        }

        /// <summary>
        /// create babylon as an asynchronous operation.
        /// TODO: think about better dispose
        /// </summary>
        /// <returns>System.Threading.Tasks.Task&lt;Babylon.Blazor.BabylonInstance&gt;.</returns>
        public override async Task<BabylonInstance> CreateBabylonAsync()
        {


            IJSInProcessObjectReference babylonWrapper = await JSInstance.InvokeAsync<IJSInProcessObjectReference>(
                                                             "import",
                                                             "./_content/Babylon.Blazor/babylonInterop.js");

            return new(JSInstance, babylonWrapper);
        }
    }
}