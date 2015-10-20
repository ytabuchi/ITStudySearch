using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ITStudySearch.Converters
{
    class HtmlToPlainConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // 例えば ConverterParameter=true とすると、parameter に string "true" が入ります。
            if (value == null)
                return "";

            // HtmlAgilityPack を使用してタグ付きの string からタグを除去します。
            var hap = new HtmlAgilityPack.HtmlDocument();
            hap.LoadHtml(value.ToString());
            var doc = hap.DocumentNode.InnerText;
            doc = doc.Replace(@"&nbsp;", " ").Replace(@"&lt;", "<").Replace(@"&gt;", ">").Replace(@"&amp;", "&").Replace(@"&quot;", "\"");

            var multiCRRegex = new Regex(@"\n\n\n+");
            doc = multiCRRegex.Replace(doc, "\n\n");

            // parameter には数字が入りますので、数値があればその文字数でカットした string を返します。
            int strLength;
            if (int.TryParse(parameter as string, out strLength)) {
                if (doc.Length > strLength)
                {
                    return doc.Substring(0, strLength) + "…";
                }
                return doc;
            }
            else
            {
                return doc;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
