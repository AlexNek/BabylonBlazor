using Babylon.Blazor;

using BabylonBlazor.AppShared.Pages;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

namespace BabylonBlazor.AppWasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //JUST DO A STATIC REFERENCE HERE ! Workaround about Razor library connection
            var type = typeof(Water);
           
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddTransient<InstanceCreatorBase>(sp => new InstanceCreator(sp.GetService<IJSRuntime>()));

            var webAssemblyHost = builder.Build();
           
            await webAssemblyHost.RunAsync();
        }
    }
}
