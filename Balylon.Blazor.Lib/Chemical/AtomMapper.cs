using System.Drawing;

using Babylon.Blazor.Babylon;

namespace Babylon.Blazor.Chemical
{
    /// <summary>
    /// Class AtomMapper.
    /// Store additional information for different atoms
    /// </summary>
    public class AtomMapper
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the emissive color.
        /// </summary>
        /// <value>The  emissive color of .</value>
        public Color3 EmissiveColor { get; set; }
        /// <summary>
        /// Gets or sets the diffuse color.
        /// </summary>
        /// <value>The diffuse color.</value>
        public Color3 DiffuseColor { get; set; }
        /// <summary>
        /// Gets the material.
        /// </summary>
        /// <value>The material.</value>
        public Material Material { get; internal set; }
    }
}
