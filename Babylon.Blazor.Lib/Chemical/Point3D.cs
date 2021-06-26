namespace Babylon.Blazor.Chemical
{
    /// <summary>
    /// Class Point3D.
    /// </summary>
    public class Point3D
    {
        /// <summary>
        /// Gets or sets the x.
        /// </summary>
        /// <value>The x.</value>
        public double X { get; set; }
        /// <summary>
        /// Gets or sets the y.
        /// </summary>
        /// <value>The y.</value>
        public double Y { get; set; }
        /// <summary>
        /// Gets or sets the z.
        /// </summary>
        /// <value>The z.</value>
        public double Z { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}