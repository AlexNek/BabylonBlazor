using System;
using System.Collections.Generic;

namespace Babylon.Blazor.Babylon.Parameters
{
    /// <summary>
    /// Class CylinderOptions.
    /// Options for cylinder creation
    /// Implements the <see cref="Babylon.Blazor.Babylon.Parameters.Options" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.Babylon.Parameters.Options" />
    public class CylinderOptions : Options
    {
        private const string DiameterJsName = "diameter";

        private const string HeightJsName = "height";

        /// <summary>
        /// Gets or sets the diameter.
        /// </summary>
        /// <value>The diameter.</value>
        public double Diameter
        {
            get
            {
                IDictionary<string, object> dictionary = _options;
                if (dictionary.ContainsKey(DiameterJsName))
                {
                    return Convert.ToSingle(dictionary[DiameterJsName]);
                }

                return 0;
            }
            set
            {
                _options.TryAdd(DiameterJsName, value);
            }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public double Height
        {
            get
            {
                IDictionary<string, object> dictionary = _options;
                if (dictionary.ContainsKey(HeightJsName))
                {
                    return Convert.ToSingle(dictionary[HeightJsName]);
                }

                return 0;
            }
            set
            {
                _options.TryAdd(HeightJsName, value);
            }
        }
    }
}
