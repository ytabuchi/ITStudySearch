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
            sb.Append("format=json&count=50&ymd=");

            for (int i = 0; i < diffDays; i++)
            {
                sb.Append(from.AddDays(i).ToString("yyyyMMdd")).Append(",");
            }
            sb.Append(from.AddDays(diffDays).ToString("yyyyMMdd"));

            var subUri = sb.ToString();
            var uri = new Uri(string.Format("http://api.atnd.org/events/?" + subUri));
//#if DEBUG
//            uri = new Uri("http://api.atnd.org/events/?format=json&count=10&ymd=20150710");
//#endif

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
            }

        }
    }
}
