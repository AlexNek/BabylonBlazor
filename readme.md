# Babylon.Blazor 
[![Build status](https://ci.appveyor.com/api/projects/status/c6hl19cdakmoxjiq?svg=true)](https://ci.appveyor.com/project/AlexNek/babylonblazor) [![Publish Status](https://img.shields.io/github/workflow/status/AlexNek/BabylonBlazor/Publish?label=publish)](https://www.nuget.org/packages/BaBylon.Blazor/)  [![NuGet Status](https://img.shields.io/nuget/v/Babylon.Blazor)](https://www.nuget.org/packages/Babylon.Blazor/)

This library packages the well-known 3D library [Babylon.js](https://www.babylonjs.com/) into a Razor component that can be used in a C# Blazor project.
The library is intended to use for creation of molecules visualization and used limited API of Babylon library.  

[Demo application .NET 5.0](https://BabylonBlazorApp202208.azurewebsites.net) - Demo application to show different parts of the library.  
[Demo application .NET 8.0](https://babylonblazorappnet80.azurewebsites.net) - Demo application to show different parts of the library.  

[Pubchem Viewer](https://pubchemviewer.azurewebsites.net) - Demo application using library reference. Show chemical information from `pubchem.ncbi.nlm.nih.gov`


## Getting Started
You can find the old version (.NET 5.0 and 6.0 commpatible) on the branch [net50](https://github.com/AlexNek/BabylonBlazor/tree/net50)
New version supports .NET 8.0 and I use Blazor Web App template with server prerendring for demo purposes.

### Prerequisites

To create Blazor Apps, install the latest version of Visual Studio with the ASP.NET and web development workload.
For using .Net 8.0 you need at least Visual Studio 2022 17.8+.
Another alternative would be to use Visual Studio code. Click [here](https://docs.microsoft.com/en-us/aspnet/core/blazor/get-started?view=aspnetcore-3.1&tabs=visual-studio-code) for more information.


Library used [IJSObjectReference](https://docs.microsoft.com/en-us/dotnet/api/microsoft.jsinterop.ijsobjectreference?view=dotnet-plat-ext-6.0)


### Installing

After you have created your Blazor project, you need to do the following steps:


**Install the latest NuGet Package**

Using Package Manager
```
Install-Package Babylon.Blazor
```

Using .NET CLI
```
dotnet add package Babylon.Blazor
```

Using MS VS Manage NuGet Packages  
Search for `Babylon.Blazor`

Add reference to babylon js library. Add 2 lines (with babylonjs) into app.razor
You will also need to add a reference to babylonInterop.js.

```html
<body>
    <Routes />
    <script src="https://preview.babylonjs.com/babylon.js"></script>
    <script src="https://preview.babylonjs.com/loaders/babylonjs.loaders.min.js"></script>
    <script type="module" src="_content/Babylon.Blazor/babylonInterop.js"></script>
    <script src="_framework/blazor.web.js"></script>
</body>
```

Add `InstanceCreator` to **DI**
*Server Part*
```C#
 public class Program
    {
        public static async Task Main(string[] args)
        {
       ...
           builder.Services.AddTransient<InstanceCreatorBase>(sp => new InstanceCreatorAsyncMode(sp.GetService<IJSRuntime>()));
           var app = builder.Build(); 
        }
    }
```
> **Note** Server side support only `IJSObjectReference`

*Client Part*
```C#
builder.Services.AddTransient<InstanceCreatorBase>(sp => new InstanceCreator(sp.GetService<IJSRuntime>()));

await builder.Build().RunAsync();

```

Add Razor page and replace context to similar code
```C#
@page "/test"
@using Babylon.Blazor.Chemical
@rendermode InteractiveAuto
<h1>Water</h1>

<p> Chemical formula of water is H<sub>2</sub>O</p>

<div style="height: 600px;">
   <BabylonCanvas CanvasId="Canvas1" SceneData=@PanelData/>
</div>

@code {

    ChemicalData PanelData { get; } = new ChemicalData();

    async Task InitDataAsync()
    {
        // Fake await line
        await Task.FromResult(1);


        PanelData.Atoms.Add(new AtomDescription() { Name = "O", X = 2.5369, Y = -0.1550, Z = 0.0000 });
        PanelData.Atoms.Add(new AtomDescription() { Name = "H", X = 3.0739, Y =  0.1550, Z = 0.0000 });
        PanelData.Atoms.Add(new AtomDescription() { Name = "H", X = 2.0000, Y =  0.1550, Z = 0.0000 });

        PanelData.Bonds.Add(new BondDescription(1, 2,  BondDescription.BondType.Single));
        PanelData.Bonds.Add(new BondDescription(1, 3, BondDescription.BondType.Single));
    }

    protected override async Task OnInitializedAsync()
    {
        await InitDataAsync();
    }

}
```

Add to _Imports.razor
```
@using Babylon.Blazor
```
> **_NOTE:_**  You can skip this step

### Demo Application


For demo application I implemented: Water, Benzene, Epinephrine and Sprite example.
All descriptions was get from [PubChem catalog](https://pubchem.ncbi.nlm.nih.gov/).
As I not found atom size into description - I not set it. The same is for double and triple bonds - the parallel lines rotation vector mostly oriented along the Y axis. Colors selected automatically from color palette.
If chemist sees something wrong then please tell me. My goal was to create a C# interface to a Java Script library. Not to draw molecules absolutely correctly.

Water  H<sub>2</sub>O

![--water pic--](docs/images/water.png)

Benzene  C<sub>6</sub>H<sub>6</sub>

![--Benzene pic--](docs/images/benzene.png)

Epinephrine C<sub>9</sub>H<sub>13</sub>NO<sub>3</sub>

![--Epinephrine pic--](docs/images/epinephrine.png)


In addition, I draw some tests

Test1 (not used anymore)

![--Test1 pic--](docs/images/test1.png)

Test2  
![--Test2 pic--](docs/images/test2.png)

### How it works?

With .NET 5.0 and above, it is very easy to transfer objects between Java Script and C#. Calling functions from a JS object in C# is also easy.

You can read more in article [Using JS Object References in Blazor WASM to wrap JS libraries](https://blog.elmah.io/using-js-object-references-in-blazor-wasm-to-wrap-js-libraries/)

Here is the steps you need to wrap JS library for Blazor Web Assembly application:
1. Create Razor library with *LibraryName*.
2. Create under wwwroot js export file with functions like this:
```JavaScript
export function functionName(parameters) {
        ...
        return javaObject;
}
```
3. Create library wrapper
```C#
IJSInProcessObjectReference libraryWrapper = await _jSInstance.InvokeAsync<IJSInProcessObjectReference>("import",
                                                             "./_content/LibraryName/LibraryJSExport.js");
```
> **_NOTE:_**  You can get _jSInstance into main application over dependency injection or service provider call

4. Create C# wrapper
```C#
public async Task<CsharpObj> CsFunctionName(int parameter)
{
        var jsObjRef = await _libraryWrapper.InvokeAsync<IJSObjectReference>("jsFunctionName", parameter);
        return new CsharpObj(jsObjRef);
}
```
5. Call the wrapped function
```C#
var CsharpObj = await LibraryWrapper.CsFunctionName(2);
```
> **_NOTE:_** you can use JS object as function parameter. Use *jsObjRef* for it.

### How to create custom scene?

If you don't want to draw molecules then it is possible to create your own component
1. Create your own creator class
```C#
public class MySceneCreator : SceneCreator
{
    public override async Task CreateAsync(BabylonCanvasBase canvas)
    {
    ...
    }
}
```
2. Create Data class
```C#
public class MyCustomData:IData
{

}
```
3. Create new canvas
```C#
public class MyCustomCanvas : BabylonCanvasBase
{
       protected virtual async Task InitializeSzene(LibraryWrapper LibraryWrapper, string canvasId)
        {
            MyCustomData panelData;
            if (ChemicalData is MyCustomData)
            {
                panelData = (MyCustomData)SceneData;
	            MySceneCreator creator = new MySceneCreator(LibraryWrapper, canvasId, panelData);
    	        await creator.CreateAsync(this);
            }
        }
}
```
4. Create new Rasor component
```html
@inherits MyCustomCanvas
<canvas id=@CanvasId touch-action="none" />
```
## What's New

### in Version 1.4
 - update to .NET 8.0
 - added show loading component. Currently we use server-side prerendering, but the babylog engine could only work client-side. The Babylon engine takes some time to render. We want to show the user a 'loading' notification instead of an empty area. The default text is "Loading...". You can change it to something else using 'LoadingTemplate'
 
 ```csharp
<BabylonCanvas CanvasId="Canvas1" SceneData=@PanelData>
    <LoadingTemplate>
        <div>Loading Custom Demo...</div>
    </LoadingTemplate>
</BabylonCanvas>
```
 
### in Version 1.3

 - added sprite manager
 - added sprite with base attributes
 - added callback function sample JS to .NET 
 - added sprite sample  
 ![--Sprite sample pic--](docs/images/sprites.png)

### in Version 1.2

 - added single color Box
 - added Torus
 - added sample of custom scene drawing  
 ![--Custom Draw pic--](docs/images/customdraw.png)


### in Version 1.1

New features:
 - Show errors on 3D canvas
 - Added new component ChemFormulaViewer
 - Expand ChemicalData. Added new properties: ErrorText, MolecularFormula, Name, ShowErrorText



##Developer notes

If you want to change the library then don't use IIS express by debugging because JS files will be not easy to change.

In some cases, you can try to refresh the page from developer mode with the cache disabled.

![--Sprite sample pic--](docs/images/disable-cache.png)
