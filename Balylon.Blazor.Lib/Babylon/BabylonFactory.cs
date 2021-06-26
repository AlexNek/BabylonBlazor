using System.Drawing;
using System.Dynamic;
using System.Threading.Tasks;

using Babylon.Blazor.Babylon.Parameters;

using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    public class BabylonFactory : IBabylonFactory
    {
        private readonly IJSRuntime _jsRuntime;

        public BabylonFactory(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<ArcRotateCamera> CreateArcRotateCamera(
            string name,
            double alpha,
            double beta,
            double radius,
            Vector3 target,
            Scene scene,
            string canvasId)
        {
            return new ArcRotateCamera(
                _jsRuntime,
                await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>(
                    "babylonInterop.createArcRotateCamera",
                    name,
                    alpha,
                    beta,
                    radius,
                    target,
                    scene,
                    canvasId));
        }

        public async Task<Mesh> CreateBox(string name, ExpandoObject options, Scene scene)
        {
            return new Mesh(_jsRuntime, await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>("babylonInterop.createBox", name, options, scene));
        }

        public async Task<Mesh> CreateCylinder(string name, ExpandoObject options, Scene scene, Vector3 rotation = null)
        {
            //if (rotation == null)
            //{
            //    return new Mesh(_jsRuntime, await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>("babylonInterop.сreateCylinder", name, options, scene));
            //}

            return new Mesh(_jsRuntime, await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>("babylonInterop.сreateCylinder", name, options, rotation, scene));
        }

        public async Task<Mesh> CreateCylinder(string name, MeshParameters parameters, Scene scene)
        {
            return new Mesh(_jsRuntime, await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>("babylonInterop.сreateCylinder", name, parameters.Options.Data, parameters.Rotation, parameters.Position, scene));
        }

        public async Task<Engine> CreateEngine(string canvasId, bool antialias = false)
        {
            return new Engine(_jsRuntime, await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>("babylonInterop.createEngine", canvasId, antialias));
        }

        public async Task<HemisphericLight> CreateHemispehericLight(string name, Vector3 direction, Scene scene)
        {
            return new HemisphericLight(
                _jsRuntime,
                await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>("babylonInterop.createHemisphericLight", name, direction, scene));
        }

        public async Task<PointLight> CreatePointLight(string name, Vector3 direction, Scene scene)
        {
            return new PointLight(
                _jsRuntime,
                await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>("babylonInterop.createPointLight", name, direction, scene));
        }

        public async Task<Scene> CreateScene(Engine engine)
        {
            return new Scene(_jsRuntime, await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>("babylonInterop.createScene", engine));
        }

        public async Task<Mesh> CreateSphere(string name, ExpandoObject options, Scene scene)
        {
            return new Mesh(_jsRuntime, await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>("babylonInterop.createSphere", name, options, scene));
        }

        public async Task<Mesh> CreateSphere(string name, MeshParameters parameters, Scene scene)
        {
            
            return new Mesh(
                _jsRuntime,
                await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>(
                    "babylonInterop.createSphere",
                    name,
                    parameters.Options.Data,
                    scene,
                    parameters.Position));
        }

        public async Task<Material> CreateMaterial(string name, Scene scene, Color3 diffuseColor, Color3 emissiveColor, float alpha)
        {
            return new Material(_jsRuntime, await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>("babylonInterop.createMaterial", name,  scene, diffuseColor, emissiveColor, alpha));
        }

        public async Task<Vector3> CreateVector3(double x, double y, double z)
        {
            return new Vector3(_jsRuntime, await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>("babylonInterop.createVector3", x, y, z));
        }

        public async Task<Color3> CreateColor3(double x, double y, double z)
        {
            return new Color3(_jsRuntime, await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>("babylonInterop.createColor3", x, y, z));
        }

        public async Task<Color3> CreateColor3(Color color)
        {
            return new Color3(
                _jsRuntime,
                await _jsRuntime.InvokeAsync<JsRuntimeObjectRef>("babylonInterop.createColor3", color.R / 255.0, color.G / 255.0, color.B / 255.0));
        }
    }
}
