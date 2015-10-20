using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITStudySearch.Models
{
    class FilterConnpassData
    {
        public void FilterData(ConnpassJson connpassResult, ObservableCollection<AllEventsInfo> allEventsInfo, HashSet<string> ngWordsList, HashSet<string> cities)
        {
            if (connpassResult != null)
            {
                var connpassInfo = from evnt in connpassResult.events
                                   join city in cities on SpecifyCity.GetCity(evnt.address) equals city
                                   where evnt.started_at <= DateTime.Now.AddMonths(5)
                                   where evnt.started_at > DateTime.Now
                                   where ngWordsList.All(word => !evnt.title.Contains(word))
                                   select new AllEventsInfo
                                   {
                                       Site = "site_connpass.png",
                                       Title = evnt.title,
                                       Event_uri = evnt.event_url,
                                       Start_at = evnt.started_at,
                                       End_at = evnt.ended_at,
                                       Description = evnt.description,
                                       Overview = HtmlToString.GetString(evnt.description, 50),
                                       Address = evnt.address,
                                       City = SpecifyCity.GetCity(evnt.address),
                                       Accepted = evnt.accepted,
                                       Limit = evnt.limit,
                                       Organizer = (evnt.series == null ? evnt.owner_display_name : evnt.series.title),
                                   };
                foreach (var item in connpassInfo)
                {
                    allEventsInfo.Add(item);
                }
            }
        }
    }
}
