# Changelog

All notable changes to the Babylon.Blazor NuGet package are documented here.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

## [Unreleased]

## [1.5.1] - 2026-02-08

### Changed
- Target framework updated to .NET 10.0

## [1.5.0] - 2024-11-13

### Changed
- Target framework updated to .NET 9.0

## [1.4.0] - 2024-11-13

### Added
- `LoadingTemplate` render fragment on `BabylonCanvas` — customizable overlay shown while the Babylon engine initializes (default text: "Loading...")

### Changed
- Target framework updated to .NET 8.0

## [1.3.0] - 2022-08-06

### Added
- `SpriteManager` and `Sprite` classes for 2D sprites and sprite-sheet animations inside a 3D scene
- JavaScript-to-.NET callback function support
- Sprite example scene in the demo application

## [1.2.0] - 2022-01-02

### Added
- Single-color box mesh (`CreateBox` with `BoxOptions`)
- Torus mesh (`CreateTorus` with `TorusOptions`)
- Custom scene drawing sample in the demo application

## [1.1.0] - 2021-07-04

### Added
- Error display on the 3D canvas — `ChemicalData.ErrorText` and `ChemicalData.ShowErrorText` render an error message instead of a molecule
- `ChemFormulaViewer` Razor component that renders a chemical formula with subscript numbers
- New `ChemicalData` properties: `MolecularFormula`, `Name`

[Unreleased]: https://github.com/AlexNek/BabylonBlazor/compare/1.5.1...HEAD
[1.5.1]: https://github.com/AlexNek/BabylonBlazor/releases/tag/1.5.1
[1.5.0]: https://github.com/AlexNek/BabylonBlazor/compare/1.4.36...1.5.1
[1.4.0]: https://github.com/AlexNek/BabylonBlazor/compare/1.3.27...1.4.36
[1.3.0]: https://github.com/AlexNek/BabylonBlazor/compare/1.2.22...1.3.27
[1.2.0]: https://github.com/AlexNek/BabylonBlazor/compare/1.1.21...1.2.22
[1.1.0]: https://github.com/AlexNek/BabylonBlazor/compare/v1.0...1.1.21
