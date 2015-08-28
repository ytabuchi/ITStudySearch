using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITStudySearch.Models
{
    public class DoorkeeperJson
    {
        public class Event
        {
            public class Group
            {
                public int id { get; set; }
                public string name { get; set; }
                public string country_code { get; set; }
                public string logo { get; set; }
                public string description { get; set; }
                public string public_url { get; set; }
            }

            public string title { get; set; }
            public int id { get; set; }
            public DateTime starts_at { get; set; }
            public DateTime ends_at { get; set; }
            public string venue_name { get; set; }
            public string address { get; set; }
            public string lat { get; set; }
            public string _long { get; set; }
            public int? ticket_limit { get; set; }
            public DateTime published_at { get; set; }
            public DateTime updated_at { get; set; }
            public Group group { get; set; }
            public string banner { get; set; }
            public string description { get; set; }
            public string public_url { get; set; }
            public int participants { get; set; }
            public int waitlisted { get; set; }
        }

        public Event _event { get; set; }
        
    }
}
