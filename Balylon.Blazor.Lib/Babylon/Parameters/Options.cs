using System.Dynamic;

namespace Babylon.Blazor.Babylon.Parameters
{
    /// <summary>
    /// Class Options.
    /// Base class
    /// </summary>
    public class Options
    {
        /// <summary>
        /// The options
        /// </summary>
        protected readonly ExpandoObject _options = new ExpandoObject();


        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>The data.</value>
        public ExpandoObject Data
        {
            get
            {
                return _options;
            }
        }
    }
}