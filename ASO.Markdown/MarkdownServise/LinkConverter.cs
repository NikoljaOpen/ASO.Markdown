using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASO.Markdown.MarkdownServise
{
    public static class LinkConverter
    {
        public static string ServerPath = "https://i1.wallbox.ru/wallpapers/preview/202119/";
        private static Regex _regexForReleativeLinks = new Regex(@"\[.*\]\(/.+\)");
        private static Regex _regexForAbsoluteLink = new Regex(@"^/");
        public static string ConvertLinksToAbsolute(string markdown)
        {
            
            MatchCollection matches = _regexForReleativeLinks.Matches(markdown);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    string newValue = match.Value.Replace("(/", $"({ServerPath}");
                    markdown = markdown.Replace(match.Value, newValue);
                }
            }
            return markdown;
        }

        public static string ConvertToReleative(string link)
        {
            return link.Replace(ServerPath,"/");
        }

        public static string ConvertToAbsolute(string link)
        {
            return _regexForAbsoluteLink.Replace(link, ServerPath);
        }
    }
}
