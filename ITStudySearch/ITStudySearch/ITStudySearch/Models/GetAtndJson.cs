using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ITStudySearch.Models
{
    public class GetAtndJson
    {
        /// <summary>
        /// Web サービス標準の出力順序で先頭から json データを取得します。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public async Task<AtndJson> GetAtndJsonAsync(int n)
        {
            var uri = new Uri(string.Format("http://api.atnd.org/events/?format=json&count=25&start=" + n));
            var res = await GetJsonAsync(uri);
            return res;
        }

        /// <summary>
        /// 日付から json データを取得します。
        /// </summary>
        /// <param name="from">開始日</param>
        /// <param name="to">終了日</param>
        /// <returns></returns>
        public async Task<AtndJson> GetAtndJsonAsync(DateTime from, DateTime to)
        {
            // 日数を取得します。
            var timeSpan = to - from;
            var diffDays = timeSpan.Days;

            // ATND は ymd に取得するすべての yyyyMMdd を , で接続します。
            var sb = new StringBuilder();
            sb.Append("ymd=");

            for (int i = 0; i < diffDays; i++)
            {
                sb.Append(from.AddDays(i).ToString("yyyyMMdd")).Append(",");
            }
            sb.Append(from.AddDays(diffDays).ToString("yyyyMMdd"));

            var subUri = sb.ToString();

            var uri = new Uri(string.Format("http://api.atnd.org/events/?format=json&count=50&" + subUri));
            var res = await GetJsonAsync(uri);
            return res;
        }

        /// <summary>
        /// 検索キーワードから Json データを取得します。
        /// </summary>
        /// <param name="searchWords"></param>
        /// <returns></returns>
        public async Task<AtndJson> GetAtndJsonAsync(string searchWords)
        {
            var subUri = "";
            searchWords = searchWords.Replace(" ", ","); // 複数の ,,, でも正常に結果が返ってくることを確認
            if (searchWords.Contains("&") || searchWords.Contains("＆"))
            {
                subUri = "keyword=" + searchWords.Replace("&", ",").Replace("＆", ",");
            }
            else
            {
                subUri = "keyword_or=" + searchWords;
            }

            var uri = new Uri(string.Format("http://api.atnd.org/events/?format=json&count=50&" + subUri));
            var res = await GetJsonAsync(uri);
            return res;
        }

        private async Task<AtndJson> GetJsonAsync(Uri uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode(); // StatusCode が 200 以外なら Exception

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        using (var streamReader = new StreamReader(stream))
                        {
                            var str = await streamReader.ReadToEndAsync();
                            var json = str.Replace("\"event\"", "\"_event\"").Replace("catch", "_catch");
                            var res = JsonConvert.DeserializeObject<AtndJson>(
                                json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                            return res;
                        }
                    }
                }
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("***Atnd Error***: {0}\n{1}\n{2}", e.Source, e.Message, e.InnerException);
#endif
                return null;
                //res = null;
            }
        }
    }
}
