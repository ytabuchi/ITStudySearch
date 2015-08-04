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
    class GetDoorkeeperJson
    {
        /// <summary>
        /// 日付から json データを取得します。
        /// </summary>
        /// <param name="from">開始日</param>
        /// <param name="to">終了日</param>
        /// <returns></returns>
        public async Task<List<DoorkeeperJson>> GetDoorkeeperJsonAsync(DateTime from, DateTime to)
        {
            // datefrom と dateto を since=yyyy-MM-dd と until=yyyy-MM-dd に
            var subUri = string.Format("since={0}&until={1}",
                from.ToString("yyyyMMdd"), to.ToString("yyyyMMdd"));

            var uri = new Uri(string.Format("http://api.doorkeeper.jp/events/?" + subUri));
//#if DEBUG
//            uri = new Uri("http://api.doorkeeper.jp/events/?since=20150710&until=20150711");
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
                            var json = str.Replace("\"event\"", "\"_event\"").Replace("long", "_long");
                            var res = JsonConvert.DeserializeObject<List<DoorkeeperJson>>(
                                json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                            foreach (var item in res)
                            {
                                item._event.starts_at = item._event.starts_at.AddHours(9);
                                item._event.ends_at = item._event.ends_at.AddHours(9);
                            }
                            return res;
                        }
                    }
                }
            }
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("***Doorkeeper Error***: {0}\n{1}\n{2}", e.Source, e.Message, e.InnerException);
#endif
                return null;
            }
        }
    }
}
