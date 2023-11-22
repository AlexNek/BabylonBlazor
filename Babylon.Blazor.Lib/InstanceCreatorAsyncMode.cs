using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Babylon.Blazor;

public class InstanceCreatorAsyncMode : InstanceCreatorBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InstanceCreator"/> class.
    /// </summary>
    /// <param name="jSInstance">The java script runtime instance.</param>
    public InstanceCreatorAsyncMode(IJSRuntime jSInstance)
        : base(jSInstance)
    {
    }

    /// <summary>
    /// create babylon instance as an asynchronous operation.
    /// </summary>
    /// <returns>System.Threading.Tasks.Task&lt;Babylon.Blazor.BabylonInstance&gt;.</returns>
    public override async Task<BabylonInstance> CreateBabylonAsync()
    {

        IJSObjectReference babylonWrapper = await JSInstance.InvokeAsync<IJSObjectReference>(
                                                "import",
                                                "./_content/Babylon.Blazor/babylonInterop.js");

        return new(JSInstance, babylonWrapper);
    }
}
