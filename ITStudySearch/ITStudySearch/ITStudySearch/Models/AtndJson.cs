using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITStudySearch.Models
{
    public class AtndJson
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
}
