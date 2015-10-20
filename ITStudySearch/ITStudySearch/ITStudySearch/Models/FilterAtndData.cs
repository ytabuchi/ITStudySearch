using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITStudySearch.Models
{
    class FilterAtndData
    {
        public void FilterData(AtndJson atndResult, ObservableCollection<AllEventsInfo> allEventsInfo, HashSet<string> ngWordsList, HashSet<string> cities)
        {
            if (atndResult != null)
            {
                var atndInfo = from evnt in atndResult.events
                               join city in cities on SpecifyCity.GetCity(evnt._event.address) equals city
                               where evnt._event.started_at <= DateTime.Now.AddMonths(5)
                               where evnt._event.started_at > DateTime.Now
                               where ngWordsList.All(word => !evnt._event.title.Contains(word))
                               select new AllEventsInfo
                               {
                                   Site = "site_atnd.png",
                                   Title = evnt._event.title,
                                   Event_uri = evnt._event.event_url,
                                   Start_at = evnt._event.started_at,
                                   End_at = evnt._event.ended_at,
                                   Description = evnt._event.description,
                                   Overview = HtmlToString.GetString(evnt._event.description, 50),
                                   Address = evnt._event.address,
                                   City = SpecifyCity.GetCity(evnt._event.address),
                                   Accepted = evnt._event.accepted,
                                   Limit = evnt._event.limit,
                                   Organizer = evnt._event.owner_nickname,
                               };
                foreach (var item in atndInfo)
                {
                    allEventsInfo.Add(item);
                }
            }
        }
    }
}
