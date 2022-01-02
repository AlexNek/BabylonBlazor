using System;
using System.Drawing;
using System.Threading.Tasks;

using Babylon.Blazor;
using Babylon.Blazor.Babylon;
using Babylon.Blazor.Babylon.Parameters;

namespace BabylonBlazorApp.Custom
{
    public class CustomSceneCreator : SceneCreator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneCreator"/> class.
        /// </summary>
        /// <param name="babylonInstance">The babylon instance.</param>
        /// <param name="canvasId">The canvas identifier.</param>
        public CustomSceneCreator(BabylonInstance babylonInstance, string canvasId)
            : base(babylonInstance, canvasId)
        {
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <returns>Task.</returns>
        public override async Task CreateAsync(BabylonCanvasBase canvas)
        {
            Engine engine = await BabylonInstance.CreateEngine(CanvasId, true);
            Scene scene = await engine.CreateScene();
            //Scene scene = await BabylonInstance.CreateScene(engine);
            //set rotation center
            var cameraTarget = await BabylonInstance.CreateVector3(0, 0, 0);
            //set camera
            //var camera = await scene.CreateArcRotateCamera("Camera", Math.PI / 2, Math.PI / 2, 10, cameraTarget, CanvasId);
            double absolutMax = 10;
            var camera = await scene.CreateArcRotateCamera("Camera", 3 * Math.PI / 2, 3 * Math.PI / 8, absolutMax * 3.6, cameraTarget, CanvasId);
            var hemisphericLightDirection = await BabylonInstance.CreateVector3(1, 1, 0);
            var light1 = await scene.CreateHemispehericLight("light1", hemisphericLightDirection, 0.98);

            //Sphere
            //AtomDescription atomDescription = new AtomDescription() { Name = "test1" };
            //SphereOptions options = new SphereOptions { Diameter = 1.0 };
            //MeshParameters parameters = new MeshParameters(BabylonInstance) { Options = options };
            //await parameters.SetPosition(atomDescription.X * DistanceScale, atomDescription.Y * DistanceScale, atomDescription.Z * DistanceScale);
            ////rotate for correct viewing of text texture
            ////await parameters.SetRotation(0, 0, Tools.GradToRadian(180));
            //var sphere = await scene.CreateSphere($"sphere{atomDescription.Name}", parameters);
            //var diffuseColor = await BabylonInstance.CreateColor3(Color.Aqua); //Brown,DarkRed
            //var material = await scene.CreateMaterial("material1", diffuseColor, null, 1.0);
            //sphere.SetMaterial(material);

            //Cylinder
            CylinderOptions cylinderOptions = new CylinderOptions { Diameter = 1, Height = 3 };
            MeshParameters cylinderParameters = new MeshParameters(BabylonInstance) { Options = cylinderOptions };
            double diffAngle = 0;
            var tuple = Tools.RectangularTriangleSolutions(cylinderOptions.Height, Tools.GradToRadian(diffAngle));
            await cylinderParameters.SetRotation(0, 0, Tools.GradToRadian(diffAngle));
            // with this line cylinder zero point is cylinder center
            //await cylinderParameters.SetPosition(0, 0, 0);

            //with this line cylinder zero point is start of cylinder
            await cylinderParameters.SetPosition(-tuple.X / 2, tuple.Y / 2, 0);
            var cyl1 = await scene.CreateCylinder("cyl1", cylinderParameters);

            //Box

            BoxOptions.FaceColorsObj boxColors = await BabylonInstance.CreateFaceColors(Color.Aqua);
            Options boxOptions = new BoxOptions() { Size = 2, FaceColors = boxColors };
            MeshParameters boxParameters = new MeshParameters(BabylonInstance) { Options = boxOptions };
            await boxParameters.SetPosition(0, 0, 0);
            await scene.CreateBox("Box1", boxParameters);

            await camera.SetAutoRotate(canvas.UseAutoRotate, canvas.IdleRotationSpeed);
            await BabylonInstance.RunRenderLoop(engine, scene);
        }
        //public double DistanceScale { get; set; } = 2.0;
    }
}
