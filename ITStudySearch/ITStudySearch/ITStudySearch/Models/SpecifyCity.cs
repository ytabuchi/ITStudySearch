using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ITStudySearch.Models
{
    public static class SpecifyCity
    {
        /// <summary>
        /// 住所から都道府県を特定するメソッドです。
        /// </summary>
        /// <param name="address">住所</param>
        /// <returns></returns>
        public static string GetCity(string address)
        {
            var city = "";
            if (string.IsNullOrEmpty(address))
                return "その他";

            // 先頭の郵便番号を削除
            address = Regex.Replace(address, @"^〒*[0-9]+-[0-9]+[ 　]*", "");

            // 都道府県が省略されそうな東京都、大阪府、京都府、神奈川県、愛知県のみ、政令指定都市(?)をマッチさせます。
            const string tokyoRegex = "(千代田区|中央区|港区|新宿区|文京区|台東区|墨田区|江東区|品川区|目黒区|大田区|世田谷区|渋谷区|中野区|杉並区|豊島区|北区|荒川区|板橋区|練馬区|足立区|葛飾区|江戸川区|八王子市|立川市|武蔵野市|三鷹市|府中市|昭島市|調布市|町田市|小金井市|日野市|国分寺市|国立市|狛江市|東大和市|武蔵村山市|多摩市|稲城市|小平市|東村山市|西東京市|清瀬市|東久留米市|青梅市|福生市|羽村市|あきる野市)";
            const string osakaRegex = "(大阪市|堺市|堺市|能勢町|池田市|箕面市|豊中市|茨木市|高槻市|吹田市|摂津市|枚方市|交野市|寝屋川市|守口市|門真市|四條畷市|大東市|東大阪市|八尾市|柏原市|和泉市|高石市|泉大津市|岸和田市|貝塚市|泉佐野市|泉南市|阪南市|松原市|羽曳野市|藤井寺市|富田林市|大阪狭山市|河内長野市)";
            const string kyotoRegex = "(京都市|福知山市|舞鶴市|綾部市|宇治市|宮津市|亀岡市|城陽市|向日市|長岡京市|八幡市|京田辺市|京丹後市|南丹市|木津川市|大山崎町|久御山町|井手町|宇治田原町|笠置町|和束町|精華町|南山城村|京丹波町|伊根町|与謝野町)";
            const string kanagawaRegex = "(横浜市|川崎市|相模原市|横須賀市|平塚市|鎌倉市|藤沢市|小田原市|茅ヶ崎市|逗子市|三浦市|秦野市|厚木市|大和市|伊勢原市|海老名市|座間市|南足柄市|綾瀬市)";
            const string aichiRegex = "(名古屋市|一宮市|瀬戸市|春日井市|犬山市|江南市|小牧市|稲沢市|尾張旭市|岩倉市|豊明市|日進市|清須市|北名古屋市|長久手市|津島市|愛西市|弥富市|あま市|大治町|半田市|常滑市|東海市|大府市|知多市|岡崎市|碧南市|刈谷市|豊田市|安城市|西尾市|知立市|高浜市|みよし市|豊橋市|豊川市|蒲郡市|新城市|田原市)";
            const string hyogoRegex = "(神戸市|尼崎市|西宮市|芦屋市|伊丹市|宝塚市|川西市|三田市|明石市|加古川市|高砂市|西脇市|三木市|小野市|加西市|加東市|姫路市|相生市|たつの市|赤穂市|宍粟市|豊岡市|養父市|朝来市|篠山市|丹波市|洲本市|南あわじ市|淡路市)";

            // address に都道府県が含まれていれば都道府県名を返し、それ以外で各正規表現に該当すればそれぞれの県名を返します。
            Match m;
            m = Regex.Match(address, ".*?(東京都|道|府|県)");
            if (m.Value != "")
                city = m.Value;
            else if (Regex.IsMatch(address, osakaRegex))
                city = "大阪府";
            else if (Regex.IsMatch(address, kyotoRegex))
                city = "京都府";
            else if (Regex.IsMatch(address, kanagawaRegex))
                city = "神奈川県";
            else if (Regex.IsMatch(address, aichiRegex))
                city = "愛知県";
            else if (Regex.IsMatch(address, hyogoRegex))
                city = "兵庫県";
            else if (Regex.IsMatch(address, tokyoRegex))
                city = "東京都";
            else city = "その他";

            return city;
        }
    }
}
