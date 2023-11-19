using Babylon.Blazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<InstanceCreatorBase>(sp => new InstanceCreator(sp.GetService<IJSRuntime>()));

await builder.Build().RunAsync();
