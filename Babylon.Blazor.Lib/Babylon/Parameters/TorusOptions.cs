using System.Collections.Generic;

namespace Babylon.Blazor.Babylon.Parameters
{
    public class TorusOptions : Options
    {
        private const string DiameterJsName = "diameter";

        private const string SideOrientationJsName = "sideOrientation";

        private const string TessellationJsName = "tessellation";

        private const string ThicknessJsName = "thickness";

        /// <summary>
        /// Gets or sets the diameter.
        /// Diameter of the torus. Default 1
        /// </summary>
        /// <value>The diameter.</value>
        public double Diameter
        {
            get
            {
                IDictionary<string, object> dictionary = _options;
                if (dictionary.ContainsKey(DiameterJsName))
                {
                    return (double)dictionary[DiameterJsName];
                }

                return 0;
            }
            set
            {
                _options.TryAdd(DiameterJsName, value);
            }
        }

        public ESideOrientation SideOrientation
        {
            get
            {
                IDictionary<string, object> dictionary = _options;
                if (dictionary.ContainsKey(SideOrientationJsName))
                {
                    return (ESideOrientation)dictionary[SideOrientationJsName];
                }

                return 0;
            }
            set
            {
                _options.TryAdd(SideOrientationJsName, value);
            }
        }

        /// <summary>
        /// Gets or sets the tessellation.
        /// Number of segments along the circle. Default 16
        /// </summary>
        /// <value>The tessellation.</value>
        public double Tessellation
        {
            get
            {
                IDictionary<string, object> dictionary = _options;
                if (dictionary.ContainsKey(TessellationJsName))
                {
                    return (double)dictionary[TessellationJsName];
                }

                return 0;
            }
            set
            {
                _options.TryAdd(TessellationJsName, value);
            }
        }

        /// <summary>
        /// Gets or sets the thickness.
        /// Thickness of its tube. Default 0.5
        /// </summary>
        /// <value>The thickness.</value>
        public double Thickness
        {
            get
            {
                IDictionary<string, object> dictionary = _options;
                if (dictionary.ContainsKey(ThicknessJsName))
                {
                    return (double)dictionary[ThicknessJsName];
                }

                return 0;
            }
            set
            {
                _options.TryAdd(ThicknessJsName, value);
            }
        }
    }
}

/*
 * https://doc.babylonjs.com/divingDeeper/mesh/creation/set/torus
 */