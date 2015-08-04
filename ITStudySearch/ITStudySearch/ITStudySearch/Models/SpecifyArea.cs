using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ITStudySearch.Models
{
    class SpecifyArea
    {
        /// <summary>
        /// 都道府県名から地域名を特定するメソッドです。
        /// </summary>
        /// <param name="city">都道府県名</param>
        /// <returns></returns>
        public static string GetArea(string city)
        {
            string area = "";

            if (Regex.IsMatch(city, "(東京都|神奈川県|埼玉県|千葉県|茨城県|栃木県|群馬県)"))
                area = "関東";
            else if (Regex.IsMatch(city, "(大阪府|京都府|三重県|滋賀県|兵庫県|奈良県|和歌山県)"))
                area = "近畿";
            else if (Regex.IsMatch(city, "(新潟県|富山県|石川県|福井県|山梨県|長野県|岐阜県|静岡県|愛知県)"))
                area = "中部";
            else if (Regex.IsMatch(city, "(福岡県|佐賀県|長崎県|熊本県|大分県|宮崎県|鹿児島県|沖縄県)"))
                area = "九州";
            else if (Regex.IsMatch(city, "(青森県|岩手県|宮城県|秋田県|山形県|福島県)"))
                area = "東北";
            else if (Regex.IsMatch(city, "北海道"))
                area = "北海道";
            else if (Regex.IsMatch(city, "(鳥取県|島根県|岡山県|広島県|山口県)"))
                area = "中国";
            else if (Regex.IsMatch(city, "(徳島県|香川県|愛媛県|高知県)"))
                area = "四国";

            return area;
        }
    }
}
