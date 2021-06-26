using System.Drawing;
using System.Dynamic;
using System.Threading.Tasks;

using Babylon.Blazor.Babylon.Parameters;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Interface IBabylonFactory
    /// </summary>
    public interface IBabylonFactory
    {
        /// <summary>
        /// Creates the arc rotate camera.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="alpha">The alpha.</param>
        /// <param name="beta">The beta.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="target">The target.</param>
        /// <param name="scene">The scene.</param>
        /// <param name="canvasId">The canvas identifier.</param>
        /// <returns>Task&lt;ArcRotateCamera&gt;.</returns>
        Task<ArcRotateCamera> CreateArcRotateCamera(
            string name,
            double alpha,
            double beta,
            double radius,
            Vector3 target,
            Scene scene,
            string canvasId);

        /// <summary>
        /// Creates the box.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="options">The options.</param>
        /// <param name="scene">The scene.</param>
        /// <returns>Task&lt;Mesh&gt;.</returns>
        Task<Mesh> CreateBox(string name, ExpandoObject options, Scene scene);

        /// <summary>
        /// Creates the cylinder.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="options">The options.</param>
        /// <param name="scene">The scene.</param>
        /// <param name="rotation">The rotation.</param>
        /// <returns>Task&lt;Mesh&gt;.</returns>
        Task<Mesh> CreateCylinder(string name, ExpandoObject options, Scene scene, Vector3 rotation = null);

        /// <summary>
        /// Creates the cylinder.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="scene">The scene.</param>
        /// <returns>Task&lt;Mesh&gt;.</returns>
        Task<Mesh> CreateCylinder(string name, MeshParameters parameters, Scene scene);

        /// <summary>
        /// Creates the engine.
        /// </summary>
        /// <param name="canvasId">The canvas identifier.</param>
        /// <param name="antialias">if set to <c>true</c> [antialias].</param>
        /// <returns>Task&lt;Engine&gt;.</returns>
        Task<Engine> CreateEngine(string canvasId, bool antialias = false);

        /// <summary>
        /// Creates the hemispeheric light.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="scene">The scene.</param>
        /// <returns>Task&lt;HemisphericLight&gt;.</returns>
        Task<HemisphericLight> CreateHemispehericLight(string name, Vector3 direction, Scene scene);

        /// <summary>
        /// Creates the point light.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="scene">The scene.</param>
        /// <returns>Task&lt;PointLight&gt;.</returns>
        Task<PointLight> CreatePointLight(string name, Vector3 direction, Scene scene);

        /// <summary>
        /// Creates the scene.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <returns>Task&lt;Scene&gt;.</returns>
        Task<Scene> CreateScene(Engine engine);

        /// <summary>
        /// Creates the sphere.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="options">The options.</param>
        /// <param name="scene">The scene.</param>
        /// <returns>Task&lt;Mesh&gt;.</returns>
        Task<Mesh> CreateSphere(string name, ExpandoObject options, Scene scene);

        /// <summary>
        /// Creates the sphere.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="scene">The scene.</param>
        /// <returns>Task&lt;Mesh&gt;.</returns>
        Task<Mesh> CreateSphere(string name, MeshParameters parameters, Scene scene);

        /// <summary>
        /// Creates the material.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="scene">The scene.</param>
        /// <param name="diffuseColor">Color of the diffuse.</param>
        /// <param name="emissiveColor">Color of the emissive.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns>Task&lt;Material&gt;.</returns>
        Task<Material> CreateMaterial(string name, Scene scene, Color3 diffuseColor, Color3 emissiveColor, float alpha);

        /// <summary>
        /// Creates the vector3.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <returns>Task&lt;Vector3&gt;.</returns>
        Task<Vector3> CreateVector3(double x, double y, double z);

        /// <summary>
        /// Creates the color3.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <returns>Task&lt;Color3&gt;.</returns>
        Task<Color3> CreateColor3(double x, double y, double z);

        /// <summary>
        /// Creates the color3.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>Task&lt;Color3&gt;.</returns>
        Task<Color3> CreateColor3(Color color);

    }
}
