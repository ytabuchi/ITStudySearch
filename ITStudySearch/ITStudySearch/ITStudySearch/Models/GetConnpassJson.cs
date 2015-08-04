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
    class GetConnpassJson
    {
        /// <summary>
        /// 日付から json データを取得します。
        /// </summary>
        /// <param name="from">開始日</param>
        /// <param name="to">終了日</param>
        /// <returns></returns>
        public async Task<ConnpassJson> GetConnpassJsonAsync(DateTime from, DateTime to)
        {
            // 日数を取得します。
            var timespan = to - from;
            var diffDays = timespan.Days;

            // Connpass は ymd に取得するすべての yyyyMMdd を , で接続します。
            var sb = new StringBuilder();
            sb.Append("count=50&ymd=");

            for (int i = 0; i < diffDays; i++)
            {
                sb.Append(from.AddDays(i).ToString("yyyyMMdd")).Append(",");
            }
            sb.Append(from.AddDays(diffDays).ToString("yyyyMMdd"));

            var subUri = sb.ToString();
            var uri = new Uri(string.Format("http://connpass.com/api/v1/event/?" + subUri));
//#if DEBUG
//            uri = new Uri("http://connpass.com/api/v1/event/?count=20&ymd=20150711");
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
                            var json = str.Replace("catch", "_catch");
                            var res = JsonConvert.DeserializeObject<ConnpassJson>(
                                json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                            return res;
                        }
                    }
                }
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("***Connpass Error***: {0}\n{1}\n{2}", e.Source, e.Message, e.InnerException);
#endif
                return null;
            }
        }
    }
}
