using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITStudySearch.Models
{
    public class ZusaarJson
    {

        public class Event
        {
            public int limit { get; set; }
            public object lon { get; set; }
            public string owner_nickname { get; set; }
            public int waiting { get; set; }
            public string _catch { get; set; }
            public string event_id { get; set; }
            public string url { get; set; }
            public string owner_profile_url { get; set; }
            public string title { get; set; }
            public DateTime updated_at { get; set; }
            public int accepted { get; set; }
            public string event_url { get; set; }
            public string pay_type { get; set; }
            public string address { get; set; }
            public string description { get; set; }
            public DateTime ended_at { get; set; }
            public string owner_id { get; set; }
            public DateTime started_at { get; set; }
            public string place { get; set; }
            public object lat { get; set; }
        }
        public int results_start { get; set; }
        public List<Event> _event { get; set; }
        public int results_returned { get; set; }
    }
}
