using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITStudySearch.Models
{
    /// <summary>
    /// 各 Json からのイベント情報を格納します。
    /// </summary>
    public class AllEventsInfo
    {
        public string site { get; set; }
        public string title { get; set; }
        public string event_uri { get; set; }
        //public string daystring { get; set; }
        public DateTime start_at { get; set; }
        public DateTime? end_at { get; set; }
        public string description { get; set; }
        public string overview { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public int accepted { get; set; }
        public int? limit { get; set; }

    }
}
