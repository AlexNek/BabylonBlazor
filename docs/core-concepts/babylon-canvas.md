# BabylonCanvas Component

`BabylonCanvas` is the main Razor component in Babylon.Blazor. It renders an HTML
`<canvas>` element, creates the Babylon.js engine, and manages the scene lifecycle.

## How It Works

`BabylonCanvas` inherits from `BabylonCanvasBase`, which is a Blazor `ComponentBase`
subclass. The lifecycle is:

1. **`OnInitializedAsync`** — base initialization, no scene work yet.
2. **`OnAfterRenderAsync(firstRender)`** — on the first render (or when a re-render
   is requested):
   - Shows the loading indicator.
   - Calls `InstanceCreatorBase.CreateBabylonAsync()` to get a `BabylonInstance`.
   - Calls `InitializeSzene(babylonInstance, canvasId)`.
   - Hides the loading indicator.
3. **`ShouldRender`** — checks whether the control needs to be recreated after a
   Blazor refresh (`RecreateControlAfterRefresh` flag).

## InitializeSzene

The `InitializeSzene` method is the key extension point. The base implementation
checks the type of `SceneData`:

- If it is `ChemicalData`, the method creates a `MoleculeCreator` and builds the
  molecule scene.
- If `SceneData` is null or an unknown type, an error message is drawn on the canvas.

Override this method in a custom canvas to provide your own scene creation logic.
See [Custom Scene](../getting-started/custom-scene.md).

## Component Parameters

| Parameter | Type | Default | Description |
| --- | --- | --- | --- |
| `CanvasId` | `string` | `"babylon-canvas"` | Unique HTML id for the `<canvas>` element. Must be unique per page |
| `SceneData` | `IData` | — | Data to visualize. Pass `ChemicalData` for automatic molecule rendering |
| `UseAutoRotate` | `bool` | `true` | Enable/disable camera auto-rotation |
| `IdleRotationSpeed` | `double` | `1` | Speed multiplier for auto-rotation |
| `RecreateControlAfterRefresh` | `bool` | `true` | Whether to recreate the 3D scene after a Blazor re-render |
| `LoadingTemplate` | `RenderFragment?` | `"Loading..."` | Custom content shown while the Babylon engine initializes |

## Loading Indicator

While the Babylon.js engine loads (which takes a moment, especially with
server-side prerendering), the component shows a loading overlay. The default text
is "Loading...". Replace it with the `LoadingTemplate` parameter:

```razor
<BabylonCanvas CanvasId="Canvas1" SceneData=@PanelData>
    <LoadingTemplate>
        <div class="spinner">Loading molecule...</div>
    </LoadingTemplate>
</BabylonCanvas>
```

## Canvas Element

The rendered HTML is:

```html
<canvas id="Canvas1" touch-action="none"></canvas>
```

The `touch-action="none"` attribute prevents the browser from handling touch
gestures so the Babylon.js camera can handle them for rotation and zoom.

## Container Sizing

The `<canvas>` element does not have intrinsic dimensions. It fills its parent
container. Always wrap it in a `<div>` with an explicit height:

```html
<div style="height: 600px;">
    <BabylonCanvas CanvasId="Canvas1" SceneData=@PanelData />
</div>
```

## Multiple Canvases

Each `BabylonCanvas` on a page must have a unique `CanvasId`. The id is used both
as the HTML canvas element id and as the input to Babylon.js for engine creation.

## Injected Dependencies

`BabylonCanvasBase` injects two services:

| Service | Purpose |
| --- | --- |
| `InstanceCreatorBase` | Factory that creates the `BabylonInstance` |
| `IJSRuntime` | Blazor JavaScript interop for error logging |

Both are registered during application startup. See [Installation](../getting-started/installation.md).
