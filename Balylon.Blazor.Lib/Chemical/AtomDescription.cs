namespace Babylon.Blazor.Chemical
{
    /// <summary>
    /// Class AtomDescription. Describe coordinated and name
    /// </summary>
    public class AtomDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AtomDescription"/> class.
        /// </summary>
        public AtomDescription()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AtomDescription"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        /// <param name="name">The name.</param>
        public AtomDescription(double x, double y, double z, string name)
        {
            X = x;
            Y = y;
            Z = z;
            Name = name;
        }
        /// <summary>
        /// Gets or sets the x coordinate.
        /// </summary>
        /// <value>The x.</value>
        public double X { get; set; }
        /// <summary>
        /// Gets or sets the y coordinate.
        /// </summary>
        /// <value>The y.</value>
        public double Y { get; set; }
        /// <summary>
        /// Gets or sets the z coordinate.
        /// </summary>
        /// <value>The z.</value>
        public double Z { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{Name}, X:{X}, Y:{Y}. Z:{Z}";
        }
    }
}