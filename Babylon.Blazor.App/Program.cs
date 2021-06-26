using System;
using System.Net.Http;
using System.Threading.Tasks;

using Babylon.Blazor;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace BabylonBlazorApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
       
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Logging.SetMinimumLevel(LogLevel.Information);
            
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddTransient(sp => new InstanceCreator(sp.GetService<IJSRuntime>()));
            await builder.Build().RunAsync();
        }
    }
}
