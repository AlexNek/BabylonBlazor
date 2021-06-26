using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Babylon.Blazor.Chemical
{
    /// <summary>
    /// Class Utils.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Converts text to HTML molecule formula.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>HtmlString.</returns>
        public static HtmlString ConvertToFormula(string text)
        {
            var match = Regex.Match(text, @"(\D+)(\d+)(\D+)");
            Match nextMatch = match;
            var rxDigits = new Regex(@"\d+", RegexOptions.Compiled);
            var splitByDigits = rxDigits.Split(text);

            var rxNonDigits = new Regex(@"[a-zA-Z]+", RegexOptions.Compiled);
            var splitByNonDigits = rxNonDigits.Split(text);
            StringBuilder sb = new StringBuilder();
            int j = 0;
            for (int i = 0; i < splitByDigits.Length; i++)
            {
                var atomName = splitByDigits[i];
                sb.Append(atomName);
                if (j < splitByNonDigits.Length)
                {
                    var countStr = splitByNonDigits[j++];
                    if (String.IsNullOrEmpty(countStr))
                    {
                        if (j < splitByNonDigits.Length)
                        {
                            countStr = splitByNonDigits[j++];
                        }
                        
                    }

                    if (!String.IsNullOrEmpty(countStr))
                    {
                        sb.Append("<sub>");
                        sb.Append(countStr);
                        sb.Append("</sub>");
                    }
                }
            }

            return new HtmlString(sb.ToString());
        }
    }
}
