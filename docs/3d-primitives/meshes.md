# Meshes

Babylon.Blazor supports five mesh types. All mesh creation methods are on the
`Scene` class and return a `Mesh` object.

## Common Pattern

Every mesh method takes a `name` and a `MeshParameters` object:

```csharp
var parameters = new MeshParameters(BabylonInstance) { Options = options };
await parameters.SetPosition(x, y, z);
await parameters.SetRotation(x, y, z);
var mesh = await scene.CreateSphere("name", parameters);
```

`MeshParameters` holds:

| Property | Type | Description |
| --- | --- | --- |
| `Options` | `Options` | Shape-specific options (see below) |
| `Position` | `Vector3` | Set with `await parameters.SetPosition(x, y, z)` |
| `Rotation` | `Vector3` | Set with `await parameters.SetRotation(x, y, z)` |

## Sphere

```csharp
var options = new SphereOptions { Diameter = 5.0 };
var parameters = new MeshParameters(BabylonInstance) { Options = options };
await parameters.SetPosition(-4.5, 0, 0);
var sphere = await scene.CreateSphere("sphere1", parameters);
```

| Option | Type | Description |
| --- | --- | --- |
| `Diameter` | `double` | Sphere diameter |

## Box

```csharp
var boxColors = await BabylonInstance.CreateFaceColors(Color.Chocolate);
var options = new BoxOptions { Size = 2, FaceColors = boxColors };
var parameters = new MeshParameters(BabylonInstance) { Options = options };
await parameters.SetPosition(0, 0, 0);
await scene.CreateBox("box1", parameters);
```

| Option | Type | Description |
| --- | --- | --- |
| `Size` | `double` | Uniform size for all sides |
| `Height` | `double` | Height (overrides `Size` for this dimension) |
| `Width` | `double` | Width |
| `Depth` | `double` | Depth |
| `FaceColors` | `BoxOptions.FaceColorsObj` | Per-face colors. Create with `BabylonInstance.CreateFaceColors(color)` |

## Cylinder

```csharp
var options = new CylinderOptions { Diameter = 1, Height = 3 };
var parameters = new MeshParameters(BabylonInstance) { Options = options };
await parameters.SetRotation(0, 0, Tools.GradToRadian(45));
await parameters.SetPosition(0, 0, 0);
var cylinder = await scene.CreateCylinder("cyl1", parameters);
```

| Option | Type | Description |
| --- | --- | --- |
| `Diameter` | `double` | Cylinder diameter |
| `Height` | `double` | Cylinder height |

## Torus

```csharp
var options = new TorusOptions { Diameter = 4, Tessellation = 20 };
var parameters = new MeshParameters(BabylonInstance) { Options = options };
var torus = await scene.CreateTorus("torus1", parameters);
```

| Option | Type | Description |
| --- | --- | --- |
| `Diameter` | `double` | Overall torus diameter |
| `Tessellation` | `int` | Number of segments around the ring |

## Tube

A tube connects two 3D points with a cylindrical shape. It does not use
`MeshParameters`:

```csharp
var from = await BabylonInstance.CreateVector3(0, 0, 0);
var to = await BabylonInstance.CreateVector3(3, 2, 0);
var tube = await scene.CreateTube("tube1", from, to, radius: 0.1);
```

| Parameter | Type | Description |
| --- | --- | --- |
| `name` | `string` | Mesh name |
| `fromPoint` | `Vector3` | Start point |
| `toPoint` | `Vector3` | End point |
| `radius` | `double` | Tube radius |

## Applying Materials

Any mesh can have a material applied:

```csharp
var color = await BabylonInstance.CreateColor3(Color.Aqua);
var material = await scene.CreateMaterial("mat1", color, null, 1.0);
sphere.SetMaterial(material);
```

See [Materials and Textures](materials.md) for details on materials and textures.

## Tools Helper

The `Tools` class provides math utilities for positioning meshes:

| Method | Description |
| --- | --- |
| `GradToRadian(degrees)` | Convert degrees to radians |
| `RadianToGrad(radians)` | Convert radians to degrees |
| `RectangularTriangleSolutions(hypotenuse, angleRad)` | Returns `(X, Y)` legs of a right triangle |
| `RectangularTriangleSolutionAngle(sideA, sideB)` | Returns the angle from two sides |
