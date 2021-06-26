using System;
using System.Drawing;

using Babylon.Blazor.Babylon;
using Babylon.Blazor.Chemical;

using NUnit.Framework;

namespace Babylon.Blazor.Test
{
    public class BabylonToolsTests
    {
        [Test]
        public void ColorsTest()
        {
            Color brown = Color.Brown;
            var hlsBrown = Tools.RgbToHls(brown.R,brown.G,brown.B);
            //hls = (0, 0.40588235294117647, 0.59420289855072472)
            Color green = Color.Green;
            var hlsGreen = Tools.RgbToHls(green.R, green.G, green.B);
            //hlsGreen = (120, 0.25098039215686274, 1)
            //Color.Chartreuse;
            Color yellow = Color.Yellow;
            var hlsYdellow = Tools.RgbToHls(yellow.R, yellow.G, yellow.B);
            //hlsYdellow = (60, 0.5, 1)
            Color orange = Color.Orange;
            var hlsOrange = Tools.RgbToHls(orange.R, orange.G, orange.B);
            //hlsOrange = (38.82352941176471, 0.5, 1)
            Color red = Color.Red;
            var hlsRed = Tools.RgbToHls(red.R, red.G, red.B);
            //hlsRed = (0, 0.5, 1)
            Color violet = Color.Violet;
            var hlsViolet = Tools.RgbToHls(violet.R, violet.G, violet.B);
            //hlsViolet = (300, 0.72156862745098038, 0.76056338028169024)
            Color blue = Color.Blue;
            var hlsBlue = Tools.RgbToHls(blue.R, blue.G, blue.B);
            //hlsBlue = (240, 0.5, 1)
        }

        [Test]
        public void ColorGenerator()
        {
            int colorCount = 24;
            double angle = 360.0 / colorCount;

            for (int i = 0; i < colorCount; i++)
            {
                var rgb = Tools.HlsToRgb(i * angle,0.5, 1);
                Console.WriteLine(rgb);
            }
        }

        [Test]
        public void CircleGenerator()
        {
            double radius = 2.0;
            for (int i = 0; i < 360; i+=60)
            {
                double angle = Tools.GradToRadian(i);
                double y =  radius * Math.Cos(angle);
                double x = radius * Math.Sin(angle);
                Console.WriteLine($"grad:{i} -- x:{x}, y:{y}");
            }
            
        }
    }
}
