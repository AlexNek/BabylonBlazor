using System;
using System.Threading.Tasks;

using Babylon.Blazor;
using Babylon.Blazor.Babylon;
using Babylon.Blazor.Babylon.Parameters;

namespace BabylonBlazorApp.Custom
{
    public class SpriteExampleSceneCreator : SceneCreator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneCreator"/> class.
        /// </summary>
        /// <param name="babylonInstance">The babylon instance.</param>
        /// <param name="canvasId">The canvas identifier.</param>
        public SpriteExampleSceneCreator(BabylonInstance babylonInstance, string canvasId)
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

            //set rotation center
            var cameraTarget = await BabylonInstance.CreateVector3(0, 0, 0);
            //set camera
            //var camera = await scene.CreateArcRotateCamera("Camera", Math.PI / 2, Math.PI / 2, 10, cameraTarget, CanvasId);
            double absolutMax = 10;
            var camera = await scene.CreateArcRotateCamera("Camera", - Math.PI / 2,  Math.PI / 2, 4, cameraTarget, CanvasId);
            //var hemisphericLightDirection = await BabylonInstance.CreateVector3(1, 1, 0);
            //var light1 = await scene.CreateHemispehericLight("light1", hemisphericLightDirection, 0.98);

            SpriteManager spriteManager = await scene.CreateSpriteManager(
                                              "playerManager",
                                              "https://playground.babylonjs.com/textures/player.png",
                                              3,
                                              64,
                                              64);
            var player = await spriteManager.CreateSprite("player0");

            await player.PlayAnimation(0, 40, true, 100);

            await RunRender(canvas, camera, engine, scene);
        }


        private async Task RunRender(BabylonCanvasBase canvas, ArcRotateCamera camera, Engine engine, Scene scene)
        {
            //await camera.SetAutoRotate(canvas.UseAutoRotate, canvas.IdleRotationSpeed);
            await BabylonInstance.RunRenderLoop(engine, scene);
        }
    }
}
