using System.Threading.Tasks;

namespace Babylon.Blazor
{
    /// <summary>
    /// Class SceneCreator.
    /// Base class for any scene creator
    /// </summary>
    public abstract class SceneCreator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneCreator"/> class.
        /// </summary>
        /// <param name="babylonInstance">The babylon instance.</param>
        /// <param name="canvasId">The canvas identifier.</param>
        protected SceneCreator(BabylonInstance babylonInstance, string canvasId)
        {
            BabylonInstance = babylonInstance;
            CanvasId = canvasId;
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="canvas">The canvas.</param>
        /// <returns>Task.</returns>
        public abstract Task CreateAsync(BabylonCanvasBase canvas);

        /// <summary>
        /// Gets the babylon instance.
        /// </summary>
        /// <value>The babylon instance.</value>
        protected BabylonInstance BabylonInstance { get; }

        /// <summary>
        /// Gets the canvas identifier.
        /// </summary>
        /// <value>The canvas identifier.</value>
        protected string CanvasId { get; }
    }
}
