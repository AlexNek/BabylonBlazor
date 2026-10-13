# Materials and Textures

Materials control the appearance of meshes. Babylon.Blazor provides `Material` with
diffuse color, emissive color, alpha, and texture support.

## Creating a Material

```csharp
var diffuseColor = await BabylonInstance.CreateColor3(Color.Aqua);
var emissiveColor = await BabylonInstance.CreateColor3(Color.Red); // optional
var material = await scene.CreateMaterial("mat1", diffuseColor, emissiveColor, 1.0);
```

| Parameter | Type | Description |
| --- | --- | --- |
| `name` | `string` | Material name |
| `diffuseColor` | `Color3` | The base color that reacts to light |
| `emissiveColor` | `Color3?` | Self-illuminating color. Pass `null` for no emission |
| `alpha` | `double` | Opacity. `1.0` = fully opaque, `0.0` = fully transparent |

## Applying a Material

Call `SetMaterial` on any `Mesh`:

```csharp
sphere.SetMaterial(material);
```

## Colors

### Color3

RGB color (no alpha). Created from `System.Drawing.Color`:

```csharp
var color = await BabylonInstance.CreateColor3(Color.CadetBlue);
```

The `BabylonInstance.CreateColor3` method divides each component by 255 to produce
the 0..1 range Babylon.js expects.

### Color4

RGBA color (with alpha):

```csharp
var color = await BabylonInstance.CreateColor4(Color.FromArgb(128, 255, 0, 0));
```

## DynamicTexture

`DynamicTexture` renders text onto a texture that can be applied to a material.
This is used in the molecule viewer to label each atom sphere with its element
symbol.

```csharp
var texture = await scene.CreateDynamicTexture(
    "elementLabel",     // texture name
    "bold 60px monospace", // CSS font string
    "#FF0000",          // color as hex string
    2 * Math.PI * 40,  // width in pixels
    2 * Math.PI * 20   // height in pixels
);
material.SetTexture(texture);
```

| Parameter | Type | Description |
| --- | --- | --- |
| `text` | `string` | Texture/material name |
| `fontAsText` | `string` | CSS font string (e.g. `"bold 60px monospace"`) |
| `colorAsText` | `string` | Color as hex string (e.g. `"#FF0000"`) |
| `width` | `double` | Texture width in pixels |
| `height` | `double` | Texture height in pixels |

## Box Face Colors

Boxes support per-face colors through `BoxOptions.FaceColors`:

```csharp
var faceColors = await BabylonInstance.CreateFaceColors(Color.Blue);
var options = new BoxOptions
{
    Height = 2,
    Width = 5.5,
    Depth = 0.5,
    FaceColors = faceColors
};
```

`FaceColors` applies the same color to all six faces. The underlying JavaScript
creates a per-face color array that Babylon.js uses for individual face rendering.

## Material Properties Summary

| Property | Set via | Description |
| --- | --- | --- |
| Diffuse color | `CreateMaterial(..., diffuseColor, ...)` | Base color under lighting |
| Emissive color | `CreateMaterial(..., emissiveColor, ...)` | Self-illumination color |
| Alpha | `CreateMaterial(..., alpha)` | Transparency (0..1) |
| Texture | `material.SetTexture(texture)` | DynamicTexture with text or graphics |
