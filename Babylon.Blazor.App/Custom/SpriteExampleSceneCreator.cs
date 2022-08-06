using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Babylon.Blazor;
using Babylon.Blazor.Babylon;
using Babylon.Blazor.Babylon.Parameters;

using Microsoft.JSInterop;

namespace BabylonBlazorApp.Custom
{
    public class SpriteExampleSceneCreator : SceneCreator
    {
        public event EventHandler AnimationEnd;
        private readonly MessageUpdateInvokeHelper? _messageUpdateInvokeHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="SceneCreator"/> class.
        /// </summary>
        /// <param name="babylonInstance">The babylon instance.</param>
        /// <param name="canvasId">The canvas identifier.</param>
        public SpriteExampleSceneCreator(BabylonInstance babylonInstance, string canvasId)
            : base(babylonInstance, canvasId)
        {
            _messageUpdateInvokeHelper = new MessageUpdateInvokeHelper(UpdateMessage);
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

            SpriteManager spriteManagerPlayers = await scene.CreateSpriteManager("playerManager",
                                                                          "https://playground.babylonjs.com/textures/player.png",
                                                                          3,
                                                                          64,
                                                                          64
                                                                          );
            var player0 = await spriteManagerPlayers.CreateSprite("player0");

            await player0.PlayAnimation(0, 40, false, 100, DotNetObjectReference.Create(_messageUpdateInvokeHelper));

            var player1 = await spriteManagerPlayers.CreateSprite("player1");
            await player1.SetFrameNumber(2);
            var player1Position = await BabylonInstance.CreateVector3(-1, 0.2, 0);
            await player1.SetPosition(player1Position);
            await player1.SetSize(0.5,0.5);
            await player1.SetInvert(true, false);


            var spriteManagerTrees = await scene.CreateSpriteManager("treesManager", "https://playground.babylonjs.com/textures/palm.png", 1000, 512,1024 );
            Random rnd = new Random();
            //We create some trees at random positions
            for (var i = 0; i < 200; i++) {
                var tree = await spriteManagerTrees.CreateSprite("tree");
                double posX = rnd.NextDouble() * 100 - 50;
                double posZ = rnd.NextDouble() * 10 - 5;
                var treePosition = await BabylonInstance.CreateVector3(posX, 0, posZ);
                await tree.SetPosition(treePosition);

                //Add some "dead" trees
                if (rnd.NextDouble() > 0.9)
                {
                    //tree.angle = Math.PI * 90 / 180;
                    await tree.SetAngle(Math.PI * 90 / 180);
                    var treePosition2 = await BabylonInstance.CreateVector3(posX, -0.3, posZ);
                    await tree.SetPosition(treePosition2);
                }
            }

            await RunRender(canvas, camera, engine, scene);
        }


        private async Task RunRender(BabylonCanvasBase canvas, ArcRotateCamera camera, Engine engine, Scene scene)
        {
            //await camera.SetAutoRotate(canvas.UseAutoRotate, canvas.IdleRotationSpeed);
            await BabylonInstance.RunRenderLoop(engine, scene);
        }

        private void UpdateMessage()
        {
           Console.WriteLine("Animation finished");
           OnAnimationEnd();
        }

        protected virtual void OnAnimationEnd()
        {
            EventHandler handler = AnimationEnd;
            
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}
