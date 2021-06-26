using System.Drawing;

namespace Babylon.Blazor.Chemical
{
    /// <summary>
    /// Class ColorPalette.
    /// </summary>
    public class ColorPalette
    {
        /// <summary>
        /// Gets the get colors.
        /// </summary>
        /// <value>The get colors.</value>
        public static Color[] GetColors
        {
            get
            {
                return new[]
                           {
                               Color.FromArgb(255, 0, 0), //1
                               Color.FromArgb(255, 191, 0), //2
                               Color.FromArgb(255, 255, 0), //3
                               Color.FromArgb(255, 127, 0), //4
                               Color.FromArgb(191, 255, 0), //5
                               Color.FromArgb(0, 255, 0), //6
                               Color.FromArgb(0, 127, 127), //7
                               //Color.FromArgb(0, 191, 255),
                               Color.FromArgb(0, 127, 255),
                               Color.FromArgb(0, 0, 255), 
                               Color.FromArgb(191, 0, 255),
                               Color.FromArgb(255, 0, 255),
                           };
            }
        }
    }
}
