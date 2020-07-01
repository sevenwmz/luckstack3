using Microsoft.JScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace WebUI.Helper
{
    public class HtmlSecurityHelper
    {
        #region Left here just understand for myself
        //Get HTML Tag.
        private static string _fristGetElement = "<.*?>";

        //Get pure HTML element "<something>".
        private static string _getTag = @"</?(?<tagName>[\S/]*)[>\s/]";

        //Before and after plus (" ") is normal symbol,not meaning.Careabot high light \ it's i need.
        //The word meaning almost is i wanna inside of HTML element, like "<a href=" something ">",get without <a > .
        private static string _getProprety = @"\S+\s*=\s*['" + "\"]" + @"[\S\s]*?['" + "\"]";

        //Get pure inside HTML element.
        //Example:
        //Before (href=" something ") || After (href)
        //
        //Extension: (?=) get before (?=) content.
        private static string _getPureProprety = @"(?<prop>\S*)(\s*)(?==\s*['" + "\"])";

        //Allow tag list;
        private static string[] allowTags = new string[] {"h1","h2", "h3", "h4", "h5", "h6","p","div",
                                                    "a","small","style","del","em","lable","ol","il","ul","span","i","b","strong",
                                                    "samp","!--","br/ "};
        //Allow proprety
        private static string[] allowProprety = new string[] { "href", "class", "style",
                                                    "a","small","del","em","lable","ol","il","ul","span","i","b","strong"
                                                    ,"samp","!--","br/"};
        #endregion

        #region Check input html is security

        /// <summary>
        /// Check html content security,if not security will be repleace.
        /// </summary>
        /// <param name="content">Need html content</param>
        /// <param name="onlyPureText">Without html tag,only pure text return</param>
        /// <returns>Return security text.</returns>
        public static string HtmlSecurity(string content, bool onlyPureText = false)
        {
            return Regex.Replace(content,
                            _fristGetElement,
                            match => fixTag(match, allowTags, allowProprety, onlyPureText),
                            RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Check tag is security,if not security replace "",
        /// </summary>
        /// <param name="thisMatch">content text</param>
        /// <param name="allowTags">White tag list</param>
        /// <param name="allowProprety">White proprety list</param>
        /// <param name="onlyPureText">Get only text without html tags</param>
        /// <returns>Return after check text</returns>
        private static string fixTag(Match thisMatch, string[] allowTags, string[] allowProprety, bool onlyPureText = false)
        {
            if (onlyPureText)
            {
                return "";
            }

            string tag = thisMatch.Value;
            Match m = Regex.Match(tag, _getTag, RegexOptions.IgnoreCase);
            string tagName = m.Groups["tagName"].Value.ToLower();

            if (Array.IndexOf(allowTags, tagName) < 0)
            {
                return "";
            }
            else
            {
                return Regex.Replace(tag, _getProprety, match => fixProprety(match, allowProprety), RegexOptions.IgnoreCase);
            }

        }

        /// <summary>
        /// Further check html property,if have some danger remove.
        /// </summary>
        /// <param name="match">Need check element</param>
        /// <param name="allowProprety">Need allow property white list</param>
        /// <returns>Return security html</returns>
        private static string fixProprety(Match match, string[] allowProprety)
        {
            string proprety = match.Value;
            Match m = Regex.Match(proprety, _getPureProprety, RegexOptions.IgnoreCase);

            string propertyName = m.Groups["prop"].Value.ToLower();

            if (Array.IndexOf(allowProprety, propertyName) < 0)
            {
                return "";
            }

            return proprety;
        }
        #endregion
    }
}