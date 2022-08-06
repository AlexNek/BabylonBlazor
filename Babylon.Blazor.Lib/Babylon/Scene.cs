using System.Threading.Tasks;

using Babylon.Blazor.Babylon.Parameters;

using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class Scene.
    /// Implements the <see cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// Implements the <see cref="Babylon.Blazor.IJsLibInstanceGetter" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.Babylon.BabylonObject" />
    /// <seealso cref="Babylon.Blazor.IJsLibInstanceGetter" />
    public class Scene : BabylonObject, IJsLibInstanceGetter
    {
        //public Scene(IJSRuntime jsRuntime, JsRuntimeObjectRef objRef) : base(jsRuntime, objRef) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Scene"/> class.
        /// </summary>
        /// <param name="jsObjRef">The js object reference.</param>
        /// <param name="babylonInstance">The babylon instance.</param>
        public Scene(IJSObjectReference jsObjRef, IJSInProcessObjectReference babylonInstance)
            : base(jsObjRef)
        {
            BabylonInstance = babylonInstance;
        }

        /// <summary>
        /// Creates the arc rotate camera.
        /// This camera always points towards a given target position and can be rotated around that target with the target as the center of rotation
        /// </summary>
        /// <param name="name">The camera name.</param>
        /// <param name="alpha">The alpha. The longitudinal rotation, in radians</param>
        /// <param name="beta">The beta. The latitudinal rotation, in radians</param>
        /// <param name="radius">The radius. The distance from the target</param>
        /// <param name="cameraTarget">The camera target 3d point.</param>
        /// <param name="canvasId">The canvas identifier.</param>
        /// <returns>ArcRotateCamera.</returns>
        public async Task<ArcRotateCamera> CreateArcRotateCamera(
            string name,
            double alpha,
            double beta,
            double radius,
            Vector3 cameraTarget,
            string canvasId)
        {
            var jsCamera = await BabylonInstance.InvokeAsync<IJSObjectReference>(
                               "createArcRotateCamera",
                               name,
                               alpha,
                               beta,
                               radius,
                               cameraTarget.JsObjRef,
                               JsObjRef,
                               canvasId);

            return new ArcRotateCamera(jsCamera, BabylonInstance);
        }

        public async Task<Mesh> CreateBox(string name, MeshParameters parameters)
        {
            //export function createBox(name, options, rotation, position, scene)
            // var box = BABYLON.Mesh.CreateBox("box", 3.0, scene);
            BoxOptions boxOptions = parameters.Options as BoxOptions;
            var jsMesh = await BabylonInstance.InvokeAsync<IJSObjectReference>(
                             "createBox",
                             name,
                             parameters.Options.Data,
                             parameters.Rotation?.JsObjRef,
                             parameters.Position?.JsObjRef,
                             boxOptions?.FaceColors?.JsObjRef,
                             JsObjRef);
            return new Mesh(jsMesh, BabylonInstance);
        }

        /// <summary>
        /// Creates the cylinder.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Mesh.</returns>
        public async Task<Mesh> CreateCylinder(string name, MeshParameters parameters)
        {
            //export function сreateCylinder (name, options, rotation, position, scene) {
            var jsMesh = await BabylonInstance.InvokeAsync<IJSObjectReference>(
                             "сreateCylinder",
                             name,
                             parameters.Options.Data,
                             parameters.Rotation.JsObjRef,
                             parameters.Position.JsObjRef,
                             JsObjRef);
            return new Mesh(jsMesh, BabylonInstance);
        }

        /// <summary>
        /// Creates the dynamic texture.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="fontAsText">The font as text.</param>
        /// <param name="colorAsText">The color as text.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>DynamicTexture.</returns>
        public async Task<DynamicTexture> CreateDynamicTexture(string text, string fontAsText, string colorAsText, double width, double height)
        {
            var jsTexture = await BabylonInstance.InvokeAsync<IJSObjectReference>(
                                "createTextTexture",
                                JsObjRef,
                                text,
                                width,
                                height,
                                fontAsText,
                                colorAsText
                            );

            return new DynamicTexture(jsTexture);
        }

        /// <summary>
        /// Creates the hemispeheric light.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="lightDirection">The light direction.</param>
        /// <param name="intensity">The intensity.</param>
        /// <returns>HemisphericLight.</returns>
        public async Task<HemisphericLight> CreateHemispehericLight(string name, Vector3 lightDirection, double intensity = 1.0)
        {
            var jsLight = await BabylonInstance.InvokeAsync<IJSObjectReference>(
                              "createHemisphericLight",
                              name,
                              lightDirection.JsObjRef,
                              intensity,
                              JsObjRef);

            return new HemisphericLight(jsLight);
        }

        /// <summary>
        /// Creates the material.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="diffuseColor">Color of the diffuse.</param>
        /// <param name="emissiveColor">Color of the emissive.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns>Material.</returns>
        public async Task<Material> CreateMaterial(string name, Color3 diffuseColor, Color3 emissiveColor, double alpha)
        {
            IJSObjectReference emissiveColorJsObjRef = emissiveColor?.JsObjRef;
            IJSObjectReference diffuseColorJsObjRef = diffuseColor?.JsObjRef;
            var jsMaterial = await BabylonInstance.InvokeAsync<IJSObjectReference>(
                                 "createMaterial",
                                 name,
                                 JsObjRef,
                                 diffuseColorJsObjRef,
                                 emissiveColorJsObjRef,
                                 alpha);
            return new Material(jsMaterial, BabylonInstance);
        }

        /// <summary>
        /// Creates the point light.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="lightDirection">The light direction.</param>
        /// <param name="intensity">The intensity.</param>
        /// <returns>PointLight.</returns>
        public async Task<PointLight> CreatePointLight(string name, Vector3 lightDirection, double intensity = 1.0)
        {
            var jsLight = await BabylonInstance.InvokeAsync<IJSObjectReference>(
                              "createPointLight",
                              name,
                              lightDirection.JsObjRef,
                              intensity,
                              JsObjRef);
            return new PointLight(jsLight);
        }

        /// <summary>
        /// Creates the sphere.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Mesh.</returns>
        public async Task<Mesh> CreateSphere(string name, MeshParameters parameters)
        {
            IJSObjectReference positionJsObjRef = parameters.Position?.JsObjRef;
            IJSObjectReference rotationJsObjRef = parameters.Rotation?.JsObjRef;
            IJSObjectReference jsMesh = await BabylonInstance.InvokeAsync<IJSObjectReference>(
                                            "createSphere",
                                            name,
                                            parameters.Options.Data,
                                            rotationJsObjRef,
                                            positionJsObjRef,
                                            JsObjRef
                                        );
            return new Mesh(jsMesh, BabylonInstance);
        }

        /// <summary>
        /// Creates the sprite manager.
        /// </summary>
        /// <param name="name">The name. Manager name</param>
        /// <param name="url">The URL. path to the image/spritesheet url</param>
        /// <param name="capacity">The capacity. Maximum number of sprite instances in this manager</param>
        /// <param name="width">The width. Width of a sprite or a cell within a spritesheet.</param>
        /// <param name="height">The height. Height of a sprite or a cell within a spritesheet</param>
        /// <returns>SpriteManager.</returns>
        public async Task<SpriteManager> CreateSpriteManager(string name, string url, int capacity, int width, int height)
        {
            var jsMesh = await BabylonInstance.InvokeAsync<IJSObjectReference>(
                             "сreateSpriteManager",
                             name,
                             url,
                             capacity,
                             width, height,
                             JsObjRef);
            return new SpriteManager(jsMesh, BabylonInstance);
        }

        /// <summary>
        /// Creates the text plane.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="text">The text.</param>
        /// <param name="textColor">Color of the text.</param>
        /// <param name="rectanglePlaneSize">Size of the rectangle plane.</param>
        /// <returns>Mesh.</returns>
        public async Task<Mesh> CreateTextPlane(Vector3 position, string text, Color3 textColor, double rectanglePlaneSize)
        {
            var jsMesh = await BabylonInstance.InvokeAsync<IJSObjectReference>(
                             "createTextPlane",
                             JsObjRef,
                             position.JsObjRef,
                             text,
                             "black",
                             rectanglePlaneSize
                         );
            return new Mesh(jsMesh, BabylonInstance);
        }

        public async Task<Mesh> CreateTorus(string name, MeshParameters parameters)
        {
            //var torus = BABYLON.Mesh.CreateTorus("torus", 5, 1, 10, scene, false);
            var jsMesh = await BabylonInstance.InvokeAsync<IJSObjectReference>(
                             "createTorus",
                             name,
                             parameters.Options.Data,
                             parameters.Rotation?.JsObjRef,
                             parameters.Position?.JsObjRef,
                             JsObjRef);
            return new Mesh(jsMesh, BabylonInstance);
        }

        /// <summary>
        /// Creates the tube.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="fromPoint">From point.</param>
        /// <param name="toPoint">To point.</param>
        /// <param name="radius">The radius.</param>
        /// <returns>Mesh.</returns>
        public async Task<Mesh> CreateTube(string name, Vector3 fromPoint, Vector3 toPoint, double radius)
        {
            var jsMesh = await BabylonInstance.InvokeAsync<IJSObjectReference>(
                             "createTube",
                             name,
                             fromPoint.JsObjRef,
                             toPoint.JsObjRef,
                             radius,
                             JsObjRef);
            return new Mesh(jsMesh, BabylonInstance);
        }

        /// <summary>
        /// Shows the world axis.
        /// </summary>
        /// <param name="size">The size.</param>
        public async Task ShowWorldAxis(double size)
        {
            await BabylonInstance.InvokeVoidAsync("showWorldAxis", size, JsObjRef);
        }

        /// <summary>
        /// Gets the babylon instance.
        /// </summary>
        /// <value>The babylon instance.</value>
        public IJSInProcessObjectReference BabylonInstance { get; }
    }
}
