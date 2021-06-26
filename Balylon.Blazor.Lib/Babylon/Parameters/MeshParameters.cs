using System.Diagnostics;
using System.Threading.Tasks;

namespace Babylon.Blazor.Babylon.Parameters
{
    /// <summary>
    /// Class MeshParameters.
    /// Additional parameters for object creation
    /// </summary>
    public class MeshParameters
    {
        private Vector3 _position;

        private Vector3 _rotation;

        /// <summary>
        /// Initializes a new instance of the <see cref="MeshParameters"/> class.
        /// </summary>
        /// <param name="babylonInstance">The babylon instance.</param>
        public MeshParameters(BabylonInstance babylonInstance)
        {
            BabylonInstance = babylonInstance;
        }

        /// <summary>
        /// Sets the position.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        public async Task SetPosition(double x, double y, double z)
        {
            Trace.WriteLine($"Babylon:{BabylonInstance}");
            _position = await BabylonInstance.CreateVector3(x, y, z);
        }

        /// <summary>
        /// Sets the rotation.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        public async Task SetRotation(double x, double y, double z)
        {
            _rotation = await BabylonInstance.CreateVector3(x, y, z);
        }

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>The options.</value>
        public Options Options { get; set; }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <value>The position.</value>
        public Vector3 Position
        {
            get
            {
                return _position;
            }
        }

        /// <summary>
        /// Gets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        public Vector3 Rotation
        {
            get
            {
                return _rotation;
            }
        }

        //[Inject]
        private BabylonInstance BabylonInstance { get; }
    }
}
