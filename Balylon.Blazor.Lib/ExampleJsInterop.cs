using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Microsoft.JSInterop;

namespace Babylon.Blazor
{
    // This class provides an example of how JavaScript functionality can be wrapped
    // in a .NET class for easy consumption. The associated JavaScript module is
    // loaded on demand when first needed.
    //
    // This class can be registered as scoped DI service and then injected into Blazor
    // components for use.

    /// <summary>
    /// Class ExampleJsInterop.
    /// Implements the <see cref="System.IAsyncDisposable" />
    /// </summary>
    /// <seealso cref="System.IAsyncDisposable" />
    public class ExampleJsInterop : IAsyncDisposable
    {
        /// <summary>
        /// The module task
        /// </summary>
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleJsInterop"/> class.
        /// </summary>
        /// <param name="jsRuntime">The js runtime.</param>
        public ExampleJsInterop(IJSRuntime jsRuntime)
        {
            Trace.WriteLine($"*** create moduleTask");
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Babylon.Blazor/exampleJsInterop.js").AsTask());
            Trace.WriteLine($"***{moduleTask.Value}");
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>System.Threading.Tasks.ValueTask&lt;string&gt;.</returns>
        public async ValueTask<string> Log(string message)
        {
            var module = await moduleTask.Value;

            await module.InvokeVoidAsync("console.log", message);
            return await Task.FromResult("");
        }

        /// <summary>
        /// Prompts the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>System.Threading.Tasks.ValueTask&lt;string&gt;.</returns>
        public async ValueTask<string> Prompt(string message)
        {
            var module = await moduleTask.Value;
            
            //await module.InvokeVoidAsync("console.log", $"*1*js*{moduleTask.Value}");
            return await module.InvokeAsync<string>("showPrompt", message);
        }
        /// <summary>
        /// Displays the specified welcome message.
        /// </summary>
        /// <param name="welcomeMessage">The welcome message.</param>
        /// <returns>System.Threading.Tasks.Task&lt;string&gt;.</returns>
        public async Task<string> Display(string welcomeMessage)
        {
            // displayWelcome is implemented in wwwroot/exampleJsInterop.js
            var module = await moduleTask.Value;
            //await module.InvokeVoidAsync("console.log", $"*2*js*{moduleTask.Value}");
            return await module.InvokeAsync<string>("displayMessage", welcomeMessage);
        }

        /// <summary>
        /// dispose as an asynchronous operation.
        /// </summary>
        /// <returns>System.Threading.Tasks.ValueTask.</returns>
        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
