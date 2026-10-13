# Chemical Data

`ChemicalData` is the data model for molecule visualization. It implements `IData`
and holds a collection of atoms and bonds that the `MoleculeCreator` renders as a
3D scene.

## ChemicalData Properties

| Property | Type | Description |
| --- | --- | --- |
| `Atoms` | `List<AtomDescription>` | The atoms in the molecule |
| `Bonds` | `List<BondDescription>` | The bonds connecting the atoms |
| `Name` | `string` | Display name of the molecule |
| `MolecularFormula` | `string` | Chemical formula (e.g. `"C6H6"`) |
| `ErrorText` | `string` | Error message to display on the canvas |
| `ShowErrorText` | `bool` | Whether to show `ErrorText` instead of the molecule |

## AtomDescription

Describes a single atom with its element name and 3D coordinates:

```csharp
public class AtomDescription
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public string Name { get; set; }  // Element symbol: "C", "H", "O", "N", etc.
}
```

Constructor shorthand:

```csharp
var atom = new AtomDescription(x: 1.5, y: -0.3, z: 0.0, name: "C");
```

Coordinates come from the SDF/MOL file format used by
[PubChem](https://pubchem.ncbi.nlm.nih.gov/) and other chemical databases.

## BondDescription

Describes a connection between two atoms:

```csharp
public class BondDescription
{
    public int FromAtomIndex { get; set; }  // 1-based index into ChemicalData.Atoms
    public int ToAtomIndex { get; set; }    // 1-based index into ChemicalData.Atoms
    public BondType Type { get; set; }
}
```

### BondType

| Value | Rendering |
| --- | --- |
| `Single` (0) | One tube between the atoms |
| `Double` (1) | Two parallel tubes |
| `Triple` (2) | Three tubes (one central + two offset) |

> **Note:** Atom indices are **1-based**, matching the SDF file format. Index 1
> refers to `Atoms[0]`.

## Building ChemicalData

### Manually

```csharp
var data = new ChemicalData();
data.Name = "Water";
data.MolecularFormula = "H2O";

data.Atoms.Add(new AtomDescription() { Name = "O", X = 2.5369, Y = -0.1550, Z = 0.0000 });
data.Atoms.Add(new AtomDescription() { Name = "H", X = 3.0739, Y =  0.1550, Z = 0.0000 });
data.Atoms.Add(new AtomDescription() { Name = "H", X = 2.0000, Y =  0.1550, Z = 0.0000 });

data.Bonds.Add(new BondDescription(1, 2, BondDescription.BondType.Single));
data.Bonds.Add(new BondDescription(1, 3, BondDescription.BondType.Single));
```

### From PubChem Data

The [PubChem Viewer](https://pubchemviewer.azurewebsites.net) demo application
shows how to fetch SDF data from the PubChem API and parse it into `ChemicalData`.

## Helper Methods

| Method | Returns | Description |
| --- | --- | --- |
| `GetBoundingBox()` | `(Point3D Min, Point3D Max)` | Axis-aligned bounding box of all atom positions |
| `GetCenter()` | `Point3D` | Center point of the bounding box |
| `MoveCenterToZero()` | — | Shifts all atom positions so the molecule center is at the origin |

`MoleculeCreator` calls `MoveCenterToZero()` automatically before rendering.

## Color Assignment

Atoms are colored automatically. `ColorPalette.GetColors` provides a fixed array
of 10 distinct colors. Each unique element name gets the next color in the palette:

| Index | Color |
| --- | --- |
| 0 | Red |
| 1 | Orange (255, 191, 0) |
| 2 | Yellow |
| 3 | Orange (255, 127, 0) |
| 4 | Yellow-green (191, 255, 0) |
| 5 | Green |
| 6 | Teal (0, 127, 127) |
| 7 | Blue (0, 127, 255) |
| 8 | Blue (0, 0, 255) |
| 9 | Violet (191, 0, 255) |

If the molecule has more distinct elements than colors, the palette wraps around.

Each atom sphere gets a `DynamicTexture` with the element symbol rendered as text,
so the user can identify atoms in the 3D view.

## ChemFormulaViewer Component

`ChemFormulaViewer` is a small Razor component that converts a formula string
like `"C6H6"` into HTML with subscript numbers:

```razor
<ChemFormulaViewer FormulaText="H2O" />
```

Renders as: H<sub>2</sub>O
