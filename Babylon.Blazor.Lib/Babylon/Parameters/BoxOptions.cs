using System;
using System.Collections.Generic;

namespace Babylon.Blazor.Babylon.Parameters
{
    public class BoxOptions : Options
    {
        private const string DepthJsName = "depth"; //depth size, overwrites size option

        private const string HeightJsName = "height"; //height size, overwrites size option

        private const string SideOrientationJsName = "sideOrientation";

        private const string SizeJsName = "size"; //size of each box side

        private const string WidthJsName = "width"; //width size, overwrites size option

        public enum ESideOrientation
        {
            Default = 0,

            FrontSide = 0,

            BackSide = 1,

            DoubleSide = 2
        }

        //private const string HeightJsName = "height";

        public double Depth
        {
            get
            {
                IDictionary<string, object> dictionary = _options;
                if (dictionary.ContainsKey(DepthJsName))
                {
                    return Convert.ToSingle(dictionary[DepthJsName]);
                }

                return 0;
            }
            set
            {
                _options.TryAdd(DepthJsName, value);
            }
        }

        /// <summary>
        /// Gets or sets the height.
        /// height size, overwrites size option
        /// </summary>
        /// <value>The height.</value>
        public double Height
        {
            get
            {
                IDictionary<string, object> dictionary = _options;
                if (dictionary.ContainsKey(HeightJsName))
                {
                    return Convert.ToDouble(dictionary[HeightJsName]);
                }

                return 0;
            }
            set
            {
                _options.TryAdd(HeightJsName, value);
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
        /// Gets or sets the size.
        /// Size of each box side
        /// </summary>
        /// <value>The size.</value>
        public double Size
        {
            get
            {
                IDictionary<string, object> dictionary = _options;
                if (dictionary.ContainsKey(SizeJsName))
                {
                    return Convert.ToDouble(dictionary[SizeJsName]);
                }

                return 0;
            }
            set
            {
                _options.TryAdd(SizeJsName, value);
            }
        }

        public double Width
        {
            get
            {
                IDictionary<string, object> dictionary = _options;
                if (dictionary.ContainsKey(WidthJsName))
                {
                    return Convert.ToDouble(dictionary[WidthJsName]);
                }

                return 0;
            }
            set
            {
                _options.TryAdd(WidthJsName, value);
            }
        }
    }
}

/*
 * https://doc.babylonjs.com/divingDeeper/mesh/creation/set/box
 */
