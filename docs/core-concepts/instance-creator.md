# Instance Creator

`InstanceCreatorBase` is the abstract factory that creates `BabylonInstance` objects.
It is registered in dependency injection and injected into `BabylonCanvasBase`.

## Class Hierarchy

```
InstanceCreatorBase (abstract)
├── InstanceCreator          — for WebAssembly (IJSInProcessObjectReference)
└── InstanceCreatorAsyncMode — for server-side / SSR (IJSObjectReference)
```

## InstanceCreatorBase

The base class holds the `IJSRuntime` reference and declares one abstract method:

```csharp
public abstract class InstanceCreatorBase
{
    protected InstanceCreatorBase(IJSRuntime jSInstance) { ... }
    public abstract Task<BabylonInstance> CreateBabylonAsync();
    protected IJSRuntime JSInstance { get; }
}
```

`CreateBabylonAsync` imports the `babylonInterop.js` module and returns a
`BabylonInstance` that wraps the resulting `IJSObjectReference`.

## InstanceCreator (WebAssembly)

Uses `IJSInProcessObjectReference` for synchronous JS calls. This is faster
because it avoids the async overhead of JS interop, but it only works in
WebAssembly mode.

```csharp
builder.Services.AddTransient<InstanceCreatorBase>(
    sp => new InstanceCreator(sp.GetService<IJSRuntime>()));
```

## InstanceCreatorAsyncMode (Server-side / SSR)

Uses `IJSObjectReference` for async JS calls. This is required for server-side
rendering because the JS runtime communicates over a SignalR connection.

```csharp
builder.Services.AddTransient<InstanceCreatorBase>(
    sp => new InstanceCreatorAsyncMode(sp.GetService<IJSRuntime>()));
```

## Which One to Use

| Hosting model | Class to register |
| --- | --- |
| Blazor WebAssembly | `InstanceCreator` |
| Blazor Server (interactive) | `InstanceCreatorAsyncMode` |
| Blazor Web App with `InteractiveAuto` | `InstanceCreatorAsyncMode` (for the server path) |
| Blazor Web App with `InteractiveWebAssembly` | `InstanceCreator` (for the client path) |

## DI Registration

Register as `Transient` — each canvas gets its own creator instance. The creator
is lightweight and only holds a reference to the `IJSRuntime`.
