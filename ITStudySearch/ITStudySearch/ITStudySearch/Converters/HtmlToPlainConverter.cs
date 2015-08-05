﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
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

            // parameter には数字が入りますので、数値があればその文字数でカットした string を返します。
            int strLength;
            if (int.TryParse(parameter as string, out strLength)) {

                return doc.Substring(0, strLength) + "…";
            }
            else
            {
                return doc;
            }
                
            //    strLength = 200;
            //return doc.Replace("&hellip;", "…");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}