using System.Threading.Tasks;

using Babylon.Blazor;

namespace BabylonBlazorApp.Custom
{
    public class CustomDrawCanvasImp : BabylonCanvasBase
    {
        /// <summary>
        /// Initializes the szene.
        /// </summary>
        /// <param name="babylonInstance">The babylon instance.</param>
        /// <param name="canvasId">The canvas identifier.</param>
        protected override async Task InitializeSzene(BabylonInstance babylonInstance, string canvasId)
        {
            //never mix DrawText with real scene!!!
            //await babylonInstance.DrawText(canvasId, "Hello Custom scene", Color.DarkRed);
            CustomSceneCreator creator = new CustomSceneCreator(babylonInstance, canvasId);

            await creator.CreateAsync(this);
        }


        //var torus = BABYLON.Mesh.CreateTorus("torus", 5, 1, 10, scene, false);
        
       
    }
}
