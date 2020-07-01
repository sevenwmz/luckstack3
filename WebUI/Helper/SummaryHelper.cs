using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Helper
{
    public class SummaryHelper
    {
        /// <summary>
        /// Get 255 char summary ,if Content enough.
        /// </summary>
        /// <param name="Content">Need Content text</param>
        /// <returns>Return appropriate summary</returns>
        public static string GetSumarry(string Content)
        {
            string summary = string.Empty;
            if (string.IsNullOrEmpty(summary))
            {
                summary = Content.PadRight(255).Substring(0, 255).Trim();
            }
            else
            {
                summary = summary.Trim();
                if (summary.Length > 255)
                {
                    summary = summary.Substring(0, 255);
                }//else nothing.
            }
            return summary;
        }

    }
}