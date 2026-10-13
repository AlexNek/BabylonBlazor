# API Reference

This page lists the main types in the Babylon.Blazor library and their namespaces.

## Namespace: `Babylon.Blazor`

Core component and infrastructure types.

| Type | Kind | Description |
| --- | --- | --- |
| `BabylonCanvas` | Razor component | Main canvas component. Inherits `BabylonCanvasBase` |
| `BabylonCanvasBase` | Abstract class | Base component with scene lifecycle management |
| `BabylonInstance` | Class | Central JS interop wrapper. Creates engines, colors, vectors. Implements `IAsyncDisposable` |
| `InstanceCreatorBase` | Abstract class | DI-registered factory for `BabylonInstance` |
| `InstanceCreator` | Class | WebAssembly implementation (uses `IJSInProcessObjectReference`) |
| `InstanceCreatorAsyncMode` | Class | Server-side implementation (uses `IJSObjectReference`) |
| `SceneCreator` | Abstract class | Base class for scene builders. Subclass and override `CreateAsync` |
| `IData` | Interface | Marker interface for scene data. `ChemicalData` implements this |
| `ChemFormulaViewer` | Razor component | Renders chemical formulas with subscript numbers |
| `ShowLoadingСommander` | Class | Controls the loading indicator visibility |
| `MessageUpdateInvokeHelper` | Class | Helper for JS-to-.NET callbacks (used with sprite animations) |

## Namespace: `Babylon.Blazor.Babylon`

C# wrappers for Babylon.js objects.

| Type | Kind | Description |
| --- | --- | --- |
| `BabylonObject` | Abstract class | Base for all wrappers. Holds `IJSObjectReference JsObjRef` |
| `Engine` | Class | Babylon.js engine. Created by `BabylonInstance.CreateEngine` |
| `Scene` | Class | Babylon.js scene. Factory for meshes, cameras, lights, materials, sprites |
| `Mesh` | Class | A 3D mesh (sphere, box, cylinder, torus, tube). Supports `SetMaterial` |
| `Material` | Class | Surface appearance. Diffuse color, emissive color, alpha, texture |
| `ArcRotateCamera` | Class | Orbit camera. Supports `SetAutoRotate` |
| `HemisphericLight` | Class | Directional light that illuminates all faces |
| `PointLight` | Class | Light emitted from a single point |
| `Vector3` | Class | 3D point / direction |
| `Color3` | Class | RGB color (0..1 per channel) |
| `Color4` | Class | RGBA color (0..1 per channel) |
| `DynamicTexture` | Class | Canvas-based texture for text rendering |
| `SpriteManager` | Class | Pool of sprites sharing one texture |
| `Sprite` | Class | Individual 2D sprite. Supports position, size, animation, angle |
| `Tools` | Static class | Math helpers: `GradToRadian`, `RadianToGrad`, triangle solutions |

## Namespace: `Babylon.Blazor.Babylon.Parameters`

Parameter classes for mesh creation.

| Type | Kind | Description |
| --- | --- | --- |
| `MeshParameters` | Class | Container for mesh options, position, and rotation |
| `Options` | Abstract class | Base for shape-specific options |
| `SphereOptions` | Class | `Diameter` |
| `BoxOptions` | Class | `Size`, `Height`, `Width`, `Depth`, `FaceColors` |
| `CylinderOptions` | Class | `Diameter`, `Height` |
| `TorusOptions` | Class | `Diameter`, `Tessellation` |

## Namespace: `Babylon.Blazor.Chemical`

Types for molecule visualization.

| Type | Kind | Description |
| --- | --- | --- |
| `ChemicalData` | Class | Molecule data: atoms, bonds, name, formula, error display. Implements `IData` |
| `AtomDescription` | Class | Single atom: `X`, `Y`, `Z`, `Name` (element symbol) |
| `BondDescription` | Class | Bond between atoms: `FromAtomIndex`, `ToAtomIndex`, `Type` |
| `BondDescription.BondType` | Enum | `Single`, `Double`, `Triple` |
| `MoleculeCreator` | Class | Built-in `SceneCreator` that renders `ChemicalData` as a 3D molecule |
| `WaterMoleculeCreator` | Class | Test `SceneCreator` that draws a water molecule with hard-coded geometry |
| `ColorPalette` | Static class | Provides 10 distinct colors for element coloring |
| `AtomMapper` | Class | Internal: maps element names to materials |
| `Point3D` | Class | Simple 3D point used in bounding box calculations |
| `Utils` | Static class | `ConvertToFormula` — converts text like `"H2O"` to HTML with `<sub>` tags |

## Scene Methods

Methods on the `Scene` class for creating 3D objects:

| Method | Returns | Parameters |
| --- | --- | --- |
| `CreateArcRotateCamera` | `ArcRotateCamera` | name, alpha, beta, radius, cameraTarget, canvasId |
| `CreateSphere` | `Mesh` | name, MeshParameters |
| `CreateBox` | `Mesh` | name, MeshParameters |
| `CreateCylinder` | `Mesh` | name, MeshParameters |
| `CreateTorus` | `Mesh` | name, MeshParameters |
| `CreateTube` | `Mesh` | name, fromPoint, toPoint, radius |
| `CreateMaterial` | `Material` | name, diffuseColor, emissiveColor, alpha |
| `CreateDynamicTexture` | `DynamicTexture` | text, fontAsText, colorAsText, width, height |
| `CreateHemispehericLight` | `HemisphericLight` | name, lightDirection, intensity? |
| `CreatePointLight` | `PointLight` | name, lightDirection, intensity? |
| `CreateSpriteManager` | `SpriteManager` | name, url, capacity, width, height |
| `CreateTextPlane` | `Mesh` | position, text, textColor, rectanglePlaneSize |
| `ShowWorldAxis` | — | size |

## BabylonInstance Methods

| Method | Returns | Parameters |
| --- | --- | --- |
| `CreateEngine` | `Engine` | canvasId, antialias? |
| `CreateColor3` | `Color3` | System.Drawing.Color |
| `CreateColor4` | `Color4` | System.Drawing.Color |
| `CreateVector3` | `Vector3` | x, y, z |
| `CreateFaceColors` | `FaceColorsObj` | System.Drawing.Color |
| `CreateGrid` | — | sizeX, sizeY, step, color |
| `DrawText` | — | canvasId, text, color, x?, y?, fontText? |
| `RunRenderLoop` | — | engine, scene |
