using System;
using System.Collections.Generic;

using Microsoft.JSInterop;

namespace Babylon.Blazor.Babylon.Parameters
{
    public class BoxOptions : Options
    {
        public const int ColorsCount = 6;

        private const string DepthJsName = "depth"; //depth size, overwrites size option

        private const string FaceColorsJsName = "faceColors";

        private const string HeightJsName = "height"; //height size, overwrites size option

        private const string SideOrientationJsName = "sideOrientation";

        private const string SizeJsName = "size"; //size of each box side

        private const string WidthJsName = "width"; //width size, overwrites size option

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
        /// Gets or sets the face colors.
        /// array of 6 Color4, one per box face
        /// </summary>
        /// <value>The face colors.</value>
        public FaceColorsObj FaceColors
        {
            get
            {
                IDictionary<string, object> dictionary = _options;
                if (dictionary.ContainsKey(FaceColorsJsName))
                {
                    return (FaceColorsObj)dictionary[FaceColorsJsName];
                }

                return null;
            }
            set
            {
                _options.TryAdd(FaceColorsJsName, value);
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
        public class FaceColorsObj : BabylonObject
        {
            public FaceColorsObj(IJSObjectReference jsObjRef) : base(jsObjRef) { }
        }
    }
}

/*
 * https://doc.babylonjs.com/divingDeeper/mesh/creation/set/box
 */
