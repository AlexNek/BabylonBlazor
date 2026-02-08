using Babylon.Blazor;

using BabylonBlazor.AppShared.Pages;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

namespace BabylonBlazor.App.Client
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            //JUST DO A STATIC REFERENCE HERE ! Workaround about Razor library connection
            var type = typeof(Water);

            builder.Services.AddTransient<InstanceCreatorBase>(sp =>
                new InstanceCreatorAsyncMode(sp.GetService<IJSRuntime>()));
            await builder.Build().RunAsync();
        }
    }
}
