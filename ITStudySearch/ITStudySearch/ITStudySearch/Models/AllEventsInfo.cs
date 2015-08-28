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
        public string Site { get; set; }
        public string Title { get; set; }
        public string Event_uri { get; set; }
        public DateTime Start_at { get; set; }
        public DateTime? End_at { get; set; }
        public string Description { get; set; }
        public string Overview { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Accepted { get; set; }
        public int? Limit { get; set; }
        public string Organizer { get; set; }
    }
}
