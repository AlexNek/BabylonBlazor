using System;
using System.Drawing;

namespace Babylon.Blazor.Babylon
{
    /// <summary>
    /// Class Tools.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Converts grads to radian.
        /// </summary>
        /// <param name="grad">The grad.</param>
        /// <returns>System.Double.</returns>
        public static double GradToRadian(double grad)
        {
            return grad * Math.PI / 180.0;
        }

        /// <summary>
        /// Converts radians to grad.
        /// </summary>
        /// <param name="radian">The radian.</param>
        /// <returns>System.Double.</returns>
        public static double RadianToGrad(double radian)
        {
            return radian * 180.0 / Math.PI;
        }

        /// <summary>
        /// The Rectangular triangle solutions.
        /// find a solution to the rectangular triangle if hypotenuse and alpha angle are known
        /// </summary>
        /// <param name="с">The hypotenuse c.</param>
        /// <param name="alphaRadian">The alpha radian.</param>
        /// <returns>System.ValueTuple&lt;System.Double, System.Double&gt;. Catheters a, b</returns>
        public static (double X, double Y) RectangularTriangleSolutions(double с, double alphaRadian)
        {
            return (с * Math.Sin(alphaRadian), с * Math.Cos(alphaRadian));
        }

        /// <summary>
        /// The Rectangular triangle solutions angle.
        /// find a solution to the rectangular triangle on two sides (catheter and catheter)
        /// </summary>
        /// <param name="a">The catheter a.</param>
        /// <param name="b">The catheter b.</param>
        /// <returns>System.ValueTuple&lt;System.Double, System.Double&gt;. Hypotenuse with and alpha angle</returns>
        public static (double C, double Angle) RectangularTriangleSolutionAngle(double a, double b)
        {
            double c = Math.Sqrt(a * a + b * b);
            return (c, Math.Atan(a / b));
        }

        /// <summary>
        /// Convert an RGB value into an HLS value
        /// origin from http://csharphelper.com/blog/2016/08/convert-between-rgb-and-hls-color-models-in-c/
        /// </summary>
        /// <param name="r">The r.</param>
        /// <param name="g">The g.</param>
        /// <param name="b">The b.</param>
        /// <returns>System.ValueTuple&lt;System.Double, System.Double, System.Double&gt;.</returns>
        public static (double H, double L, double S) RgbToHls(int r, int g, int b)
        {
            double h;
            double l;
            double s;
            // Convert RGB to a 0.0 to 1.0 range.
            double double_r = r / 255.0;
            double double_g = g / 255.0;
            double double_b = b / 255.0;

            // Get the maximum and minimum RGB components.
            double max = double_r;
            if (max < double_g) max = double_g;
            if (max < double_b) max = double_b;

            double min = double_r;
            if (min > double_g) min = double_g;
            if (min > double_b) min = double_b;

            double diff = max - min;
            l = (max + min) / 2;
            if (Math.Abs(diff) < 0.00001)
            {
                s = 0;
                h = 0;  // H is really undefined.
            }
            else
            {
                if (l <= 0.5) s = diff / (max + min);
                else s = diff / (2 - max - min);

                double r_dist = (max - double_r) / diff;
                double g_dist = (max - double_g) / diff;
                double b_dist = (max - double_b) / diff;

                if (double_r == max) h = b_dist - g_dist;
                else if (double_g == max) h = 2 + r_dist - b_dist;
                else h = 4 + g_dist - r_dist;

                h = h * 60;
                if (h < 0) h += 360;
            }

            return (h, l, s);
        }

        // Convert an HLS value into an RGB value.
        /// <summary>
        /// HLSs to RGB.
        /// </summary>
        /// <param name="h">The h.</param>
        /// <param name="l">The l.</param>
        /// <param name="s">The s.</param>
        /// <returns>System.ValueTuple&lt;System.Int32, System.Int32, System.Int32&gt;.</returns>
        public static ( int R,  int G,  int B) HlsToRgb(double h, double l, double s)
        {
            int r;  
            int g;
            int b;
            double p2;
            if (l <= 0.5) p2 = l * (1 + s);
            else p2 = l + s - l * s;

            double p1 = 2 * l - p2;
            double double_r, double_g, double_b;
            if (s == 0)
            {
                double_r = l;
                double_g = l;
                double_b = l;
            }
            else
            {
                double_r = QqhToRgb(p1, p2, h + 120);
                double_g = QqhToRgb(p1, p2, h);
                double_b = QqhToRgb(p1, p2, h - 120);
            }

            // Convert RGB to the 0 to 255 range.
            r = (int)(double_r * 255.0);
            g = (int)(double_g * 255.0);
            b = (int)(double_b * 255.0);
            //Color ret = Color.FromArgb(100, r, g, b);
            return (r, g, b);
        }
        private static double QqhToRgb(double q1, double q2, double hue)
        {
            if (hue > 360) hue -= 360;
            else if (hue < 0) hue += 360;

            if (hue < 60) return q1 + (q2 - q1) * hue / 60;
            if (hue < 180) return q2;
            if (hue < 240) return q1 + (q2 - q1) * (240 - hue) / 60;
            return q1;
        }
    }

}
