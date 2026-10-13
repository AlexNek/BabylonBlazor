# JavaScript Interop

Babylon.Blazor communicates with Babylon.js through a JavaScript interop layer.
This page explains how the C# wrappers call into JavaScript and how JavaScript
objects are managed.

## The Interop Module

The file `babylonInterop.js` is an ES module shipped inside the NuGet package at
`_content/Babylon.Blazor/babylonInterop.js`. It exports functions that create and
manipulate Babylon.js objects.

The C# side loads this module with:

```csharp
IJSObjectReference babylonWrapper = await jsRuntime.InvokeAsync<IJSObjectReference>(
    "import", "./_content/Babylon.Blazor/babylonInterop.js");
```

## How C# Wrappers Work

Every Babylon.js object has a corresponding C# wrapper class:

| JavaScript object | C# wrapper class |
| --- | --- |
| `BABYLON.Engine` | `Engine` |
| `BABYLON.Scene` | `Scene` |
| `BABYLON.Mesh` | `Mesh` |
| `BABYLON.Material` | `Material` |
| `BABYLON.ArcRotateCamera` | `ArcRotateCamera` |
| `BABYLON.HemisphericLight` | `HemisphericLight` |
| `BABYLON.PointLight` | `PointLight` |
| `BABYLON.SpriteManager` | `SpriteManager` |
| `BABYLON.Sprite` | `Sprite` |
| `BABYLON.Vector3` | `Vector3` |
| `BABYLON.Color3` | `Color3` |
| `BABYLON.Color4` | `Color4` |
| `BABYLON.DynamicTexture` | `DynamicTexture` |

Each wrapper holds an `IJSObjectReference` (`JsObjRef`) that points to the
JavaScript object. The wrapper classes inherit from `BabylonObject`, which stores
this reference.

## Calling JavaScript Functions

The C# wrappers call JavaScript functions through the `IJSObjectReference`:

```csharp
// C# side
public async Task<Mesh> CreateSphere(string name, MeshParameters parameters)
{
    var jsMesh = await BabylonInstance.InvokeAsync<IJSObjectReference>(
        "createSphere",
        name,
        parameters.Options.Data,
        parameters.Rotation?.JsObjRef,
        parameters.Position?.JsObjRef,
        JsObjRef  // the scene reference
    );
    return new Mesh(jsMesh, BabylonInstance);
}
```

```javascript
// JavaScript side (babylonInterop.js)
export function createSphere(name, options, rotation, position, scene) {
    var sphere = BABYLON.MeshBuilder.CreateSphere(name, options, scene);
    if (position) sphere.position = position;
    if (rotation) sphere.rotation = rotation;
    return sphere;
}
```

## Object Lifecycle

1. The `InstanceCreatorBase` imports `babylonInterop.js` and gets an
   `IJSObjectReference` to the module.
2. `BabylonInstance` wraps this module reference and provides factory methods
   (`CreateEngine`, `CreateColor3`, `CreateVector3`, etc.).
3. Each factory method returns a new C# wrapper that holds a reference to the
   JavaScript object.
4. When the canvas is disposed, `BabylonInstance.DisposeAsync()` disposes the
   module reference.

## Passing Objects Between C# and JavaScript

JavaScript object references (`IJSObjectReference`) can be passed as parameters
to other JavaScript functions. This is how the C# wrappers build up a scene —
they create objects one at a time and pass the references to subsequent calls:

```csharp
// Create a color
Color3 diffuseColor = await BabylonInstance.CreateColor3(Color.Red);

// Create a material using the color reference
Material material = await scene.CreateMaterial("mat1", diffuseColor, null, 1.0);

// Apply the material to a mesh
sphere.SetMaterial(material);
```

Each step passes the `JsObjRef` of the previously created object to the next
JavaScript call.

## Callbacks from JavaScript to .NET

Sprites support animation callbacks. The pattern uses `DotNetObjectReference<T>`:

```csharp
// Create a helper with a .NET callback
var helper = new MessageUpdateInvokeHelper(() => Console.WriteLine("Animation ended"));

// Pass it to JavaScript
await sprite.PlayAnimation(0, 40, false, 100,
    DotNetObjectReference.Create(helper));
```

JavaScript calls `[Invoke]` on the .NET reference when the animation finishes.

## BabylonInstance

`BabylonInstance` is the central interop class. It provides:

| Method | Returns | Description |
| --- | --- | --- |
| `CreateEngine(canvasId, antialias)` | `Engine` | Creates the Babylon.js engine on the given canvas |
| `CreateColor3(color)` | `Color3` | Creates a Babylon.js Color3 from `System.Drawing.Color` |
| `CreateColor4(color)` | `Color4` | Creates a Babylon.js Color4 (with alpha) |
| `CreateVector3(x, y, z)` | `Vector3` | Creates a 3D point |
| `CreateFaceColors(color)` | `FaceColorsObj` | Creates per-face colors for a box |
| `CreateGrid(sizeX, sizeY, step, color)` | — | Draws a grid on the ground |
| `DrawText(canvasId, text, color, x, y)` | — | Draws 2D text on the canvas |
| `RunRenderLoop(engine, scene)` | — | Starts the render loop |

`BabylonInstance` implements `IAsyncDisposable` and disposes the JS module
reference when done.
