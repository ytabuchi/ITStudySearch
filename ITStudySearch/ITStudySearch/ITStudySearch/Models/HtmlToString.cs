using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ITStudySearch.Models
{
    class HtmlToString
    {
        static public string GetString(string html, int length)
        {
            // HtmlAgilityPack を使用してタグ付きの string からタグを除去します。
            var hap = new HtmlAgilityPack.HtmlDocument();
            hap.LoadHtml(html);
            var doc = hap.DocumentNode.InnerText;
            doc = doc.Replace(@"&nbsp;", " ").Replace(@"&lt;", "<").Replace(@"&gt;", ">").Replace(@"&amp;", "&").Replace(@"&quot;", "\"");

            var multiCRRegex = new Regex(@"\n\n\n+");
            doc = multiCRRegex.Replace(doc, "\n\n");

            if (doc.Length > length)
            {
                return doc.Substring(0, length) + "…";
            } else
                return doc;
        }
    }
}
