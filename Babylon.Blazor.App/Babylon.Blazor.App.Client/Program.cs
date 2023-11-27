using Babylon.Blazor;

using BabylonBlazor.AppShared.Pages;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//JUST DO A STATIC REFERENCE HERE ! Workaround about Razor library connection
var type = typeof(Water);

builder.Services.AddTransient<InstanceCreatorBase>(sp => new InstanceCreator(sp.GetService<IJSRuntime>()));

await builder.Build().RunAsync();
