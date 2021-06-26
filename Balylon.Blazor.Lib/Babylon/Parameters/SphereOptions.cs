using System;
using System.Collections.Generic;

namespace Babylon.Blazor.Babylon.Parameters
{
    /// <summary>
    /// Class SphereOptions.
    /// Options for sphere creation
    /// Implements the <see cref="Babylon.Blazor.Babylon.Parameters.Options" />
    /// </summary>
    /// <seealso cref="Babylon.Blazor.Babylon.Parameters.Options" />
    public class SphereOptions : Options
    {
        private const string DiameterJsName = "diameter";

        /// <summary>
        /// Gets or sets the diameter.
        /// </summary>
        /// <value>The diameter.</value>
        public double Diameter
        {
            get
            {
                IDictionary<string, object> dictionary = (IDictionary<String, Object>)_options;
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
    }
}