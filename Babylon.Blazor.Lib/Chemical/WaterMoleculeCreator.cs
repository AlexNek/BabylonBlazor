using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

using Babylon.Blazor.Babylon;
using Babylon.Blazor.Babylon.Parameters;

namespace Babylon.Blazor.Chemical
{
    /// <summary>
    /// Class WaterMoleculeCreator.
    /// Test class 
    /// Implements the <see cref="Babylon.Blazor.SceneCreator" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.SceneCreator" />
    public class WaterMoleculeCreator : SceneCreator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WaterMoleculeCreator"/> class.
        /// </summary>
        /// <param name="babylonInstance">The babylon instance.</param>
        /// <param name="canvasId">The canvas identifier.</param>
        public WaterMoleculeCreator(BabylonInstance babylonInstance, string canvasId)
            : base(babylonInstance, canvasId)
        {
        }

        /// <summary>
        /// create the scene asynchronous.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        public override async Task CreateAsync(BabylonCanvasBase canvas)
        {
            Engine engine = await BabylonInstance.CreateEngine(CanvasId, true);
            Scene scene = await engine.CreateScene();
            //Scene scene = await BabylonInstance.CreateScene(engine);
            //set rotation center
            var cameraTarget = await BabylonInstance.CreateVector3(0, 0, 0);
            //set camera
            var camera = await scene.CreateArcRotateCamera("Camera", Math.PI / 2, Math.PI / 2, 10, cameraTarget, CanvasId);
            var hemisphericLightDirection = await BabylonInstance.CreateVector3(1, 1, 0);
            var light1 = await scene.CreateHemispehericLight("light1", hemisphericLightDirection);
            var pointLightDirection = await BabylonInstance.CreateVector3(0, 1, -1);
            var light2 = await scene.CreatePointLight("light2", pointLightDirection);

            Color3 diffuseColor = await BabylonInstance.CreateColor3(Color.Brown); //Brown
            Color3 emissiveColor = await BabylonInstance.CreateColor3(Color.Red);
            var mat1 = await scene.CreateMaterial("matOxigen", diffuseColor, emissiveColor, 1.2f);

            SphereOptions sphereOptionsH = new SphereOptions { Diameter = 1.0 };
            SphereOptions sphereOptionsOx = new SphereOptions { Diameter = 1.5 };
            Options cylinderOptionsH = new CylinderOptions { Diameter = 0.1, Height = 2 };

            MeshParameters sphereParametersH1 = new MeshParameters(BabylonInstance) { Options = sphereOptionsH };
            MeshParameters sphereParametersH2 = new MeshParameters(BabylonInstance) { Options = sphereOptionsH };
            MeshParameters sphereParametersOx = new MeshParameters(BabylonInstance) { Options = sphereOptionsOx };
            MeshParameters cylinderParametersH1 = new MeshParameters(BabylonInstance) { Options = cylinderOptionsH };
            MeshParameters cylinderParametersH2 = new MeshParameters(BabylonInstance) { Options = cylinderOptionsH };

            double summaryAngle = 104.5;
            double diffAngle = summaryAngle / 2.0;
            var tuple = Tools.RectangularTriangleSolutions(2, Tools.GradToRadian(diffAngle));
            Trace.WriteLine($"x:{tuple.X}, y: {tuple.Y}");
            await sphereParametersH1.SetPosition(tuple.X, tuple.Y, 0);
            await sphereParametersH2.SetPosition(-tuple.X, tuple.Y, 0);

            await cylinderParametersH1.SetRotation(0, 0, Tools.GradToRadian(diffAngle));
            await cylinderParametersH1.SetPosition(-tuple.X / 2, tuple.Y / 2, 0);

            await cylinderParametersH2.SetRotation(0, 0, Tools.GradToRadian(-diffAngle));
            await cylinderParametersH2.SetPosition(tuple.X / 2, tuple.Y / 2, 0);

            var sphereOx = await scene.CreateSphere("sphereOx", sphereParametersOx);
            sphereOx.SetMaterial(mat1);

            var sphereH1 = await scene.CreateSphere("sphereH1", sphereParametersH1);
            var sphereH2 = await scene.CreateSphere("sphereH2", sphereParametersH2);

            var cyl1 = await scene.CreateCylinder("cyl1", cylinderParametersH1);
            var cyl2 = await scene.CreateCylinder("cyl2", cylinderParametersH2);

            await camera.SetAutoRotate(canvas.UseAutoRotate, canvas.IdleRotationSpeed);
            await BabylonInstance.RunRenderLoop(engine, scene);
        }
    }
}