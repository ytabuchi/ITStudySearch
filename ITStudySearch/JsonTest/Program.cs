using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;


namespace JsonTest
{
    class Program
    {
        static void Main(string[] args)
        {




            try
            {
                var task = MyClass1.GetAtndJsonAsync(new DateTime(2015, 7, 10), new DateTime(2015, 7, 13));
                //var task = MyClass2.GetJson(new DateTime(2015, 7, 10), new DateTime(2015, 7, 11));
                task.Wait();
                var data = task.Result;

                if (data != null)
                {
                    Console.WriteLine(data.events.ToString());
                }
            }
            catch (AggregateException ex)
            {
                foreach (var innerEx in ex.InnerExceptions)
                {
                    Console.WriteLine("error:" + innerEx.Message);
#if DEBUG
                    Console.ReadLine();
#endif
                }

            }

            

            //if (task.Result == null)
            //{
            //    Console.WriteLine("Error");
            //}
            //else
            //{
            //    var res = task.Result; // List<AtndJson.AtndRoot> が返る？
            //    foreach (var item in res)
            //    {
            //        Console.WriteLine(item.events.ToArray());
            //    }
            //}



        }


    }

    class MyClass1
    {
        public static async Task<ATRoot> GetAtndJsonAsync(DateTime from, DateTime to)
        {
            // 日数を取得します。
            var timeSpan = to - from;
            var diffDays = timeSpan.Days;

            // ATND は ymd に取得するすべての yyyyMMdd を , で接続します。
            var sb = new StringBuilder();
            sb.Append("format=json&count=100&ymd=");

            for (int i = 0; i < diffDays; i++)
            {
                sb.Append(from.AddDays(i).ToString("yyyyMMdd")).Append(",");
            }
            sb.Append(from.AddDays(diffDays).ToString("yyyyMMdd"));

            var subUri = sb.ToString();
            var uri = new Uri(string.Format("http://api.atnd.org/events/?" + subUri));
#if DEBUG
            uri = new Uri("http://api.atnd.org/events/?format=json&count=3&ymd=20150710");
#endif
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
                            Console.WriteLine(str);

                            var json = str.Replace("\"event\"", "\"_event\"").Replace("catch", "_catch");
                            Console.WriteLine(json);

                            var res = JsonConvert.DeserializeObject<ATRoot>(
                                json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                            Console.WriteLine(res.ToString());

                            return res;
                        }
                    }
                }
            }
            catch (HttpRequestException e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("Error: {0}\n{1}", e.Message, e.InnerException);
#endif
                return null;
            }

        }
    }

    class MyClass2
    {
        public static async Task<CPRoot> GetJson(DateTime datefrom, DateTime dateto)
        {

            // datefrom から dateto までを ymd=yyyyMMdd,yyyyMMdd とパラメーターに追加
            var timespan = dateto - datefrom;
            var differenceInDay = timespan.Days;

            var sb = new StringBuilder();
            sb.Append("count=100&ymd=");

            for (int i = 0; i < differenceInDay; i++)
            {
                sb.Append(datefrom.AddDays(i).ToString("yyyyMMdd")).Append(",");
            }
            sb.Append(datefrom.AddDays(differenceInDay).ToString("yyyyMMdd"));

            var subUri = sb.ToString();
            var uri = new Uri(string.Format("http://connpass.com/api/v1/event/?" + subUri));
#if DEBUG
            uri = new Uri("http://connpass.com/api/v1/event/?count=3&ymd=20150711");
#endif


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
                            Console.WriteLine(str);

                            var json = str.Replace("catch", "_catch");
                            Console.WriteLine(json);

                            var res = JsonConvert.DeserializeObject<CPRoot>(
                                json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                            Console.WriteLine(res.ToString());

                            return res;
                        }
                    }
                }
            }
            catch (HttpRequestException e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("Error: {0}\n{1}", e.Message, e.InnerException);
#endif
                return null;
            }


        }
    }




    public class ATRoot
    {
        public class Event
        {
            public class Event2
            {
                public int event_id { get; set; }
                public string title { get; set; }
                public object _catch { get; set; }
                public string description { get; set; }
                public string event_url { get; set; }
                public DateTime started_at { get; set; }
                public DateTime? ended_at { get; set; }
                public string url { get; set; }
                public int limit { get; set; }
                public string address { get; set; }
                public string place { get; set; }
                public string lat { get; set; }
                public string lon { get; set; }
                public int owner_id { get; set; }
                public string owner_nickname { get; set; }
                public object owner_twitter_id { get; set; }
                public int accepted { get; set; }
                public int waiting { get; set; }
                public DateTime updated_at { get; set; }
            }

            public Event2 _event { get; set; }
        }

        public int results_returned { get; set; }
        public int results_start { get; set; }
        public List<Event> events { get; set; }
    }


    public class CPRoot
    {

        public class Event
        {
            public string event_url { get; set; }
            public string event_type { get; set; }
            public string owner_nickname { get; set; }
            public Series series { get; set; }
            public DateTime updated_at { get; set; }
            public string lat { get; set; }
            public DateTime started_at { get; set; }
            public string hash_tag { get; set; }
            public string title { get; set; }
            public int event_id { get; set; }
            public string lon { get; set; }
            public int waiting { get; set; }
            public int limit { get; set; }
            public int owner_id { get; set; }
            public string owner_display_name { get; set; }
            public string description { get; set; }
            public string address { get; set; }
            public string _catch { get; set; }
            public int accepted { get; set; }
            public DateTime ended_at { get; set; }
            public string place { get; set; }
        }

        public class Series
        {
            public string url { get; set; }
            public int id { get; set; }
            public string title { get; set; }
        }
        public int results_returned { get; set; }
        public List<Event> events { get; set; }
        public int results_start { get; set; }
        public int results_available { get; set; }


    }













    




}