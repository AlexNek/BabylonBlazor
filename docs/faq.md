# FAQ

## Which .NET versions are supported?

Babylon.Blazor targets .NET 10.0. Older versions of the package support .NET 5.0,
6.0, 8.0, and 9.0. Find old branches on the
[GitHub repository](https://github.com/AlexNek/BabylonBlazor).

## Which Blazor hosting models are supported?

Both WebAssembly and server-side prerendering (SSR) are supported. The difference
is in the DI registration:

- **WebAssembly** — register `InstanceCreator`
- **Server-side / SSR** — register `InstanceCreatorAsyncMode`

See [Installation](getting-started/installation.md) for details.

## Why do I need to add Babylon.js scripts manually?

The NuGet package contains only the C# wrappers and the `babylonInterop.js` bridge.
The Babylon.js engine itself is loaded from CDN or local files. This keeps the
package small and lets you choose which Babylon.js version to use.

## The canvas shows "Loading..." forever

This usually means the component is not running in interactive mode. Check:

1. The page has `@rendermode InteractiveAuto` or `@rendermode InteractiveWebAssembly`
   or `@rendermode InteractiveServer`.
2. The `InstanceCreatorBase` is registered in DI.
3. The Babylon.js `<script>` tags are present in `App.razor` or `index.html`.
4. The browser console shows no errors (open DevTools → Console).

## The canvas is empty / nothing is rendered

- Make sure the parent `<div>` has an explicit height. The `<canvas>` fills its
  container, so a container with zero height produces an invisible canvas.
- Check that `SceneData` is not null and contains at least one atom.
- Check the browser console for JavaScript errors.

## Can I use multiple canvases on one page?

Yes. Each `BabylonCanvas` must have a unique `CanvasId`. Each canvas creates its
own Babylon.js engine and scene.

## How do I create custom 3D scenes (not molecules)?

Subclass `SceneCreator`, override `CreateAsync`, and build your scene with the
`BabylonInstance` and `Scene` APIs. Then create a custom canvas component that
calls your creator. See [Custom Scene](getting-started/custom-scene.md).

## Where do atom coordinates come from?

Coordinates come from chemical data files in the SDF/MOL format, which is the
standard format used by [PubChem](https://pubchem.ncbi.nlm.nih.gov/) and other
chemical databases. The [PubChem Viewer](https://pubchemviewer.azurewebsites.net)
demo shows how to fetch and parse this data.

## Can I change the atom colors?

Colors are assigned automatically from `ColorPalette.GetColors` based on the
element name. To customize colors, create your own `SceneCreator` subclass and
build the materials manually. See [Molecule Creator](chemical-visualization/molecule-creator.md).

## How do I report bugs or request features?

Open an issue on the [GitHub repository](https://github.com/AlexNek/BabylonBlazor/issues).
