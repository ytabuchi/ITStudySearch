using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITStudySearch.Models
{
    class FilterZusaarData
    {
        public void FilterData(ZusaarJson zusaarResult, ObservableCollection<AllEventsInfo> allEventsInfo, HashSet<string> ngWordsList, HashSet<string> cities)
        {
            if (zusaarResult != null)
            {
                var zusaaarInfo = from evnt in zusaarResult._event
                                  where evnt.started_at <= DateTime.Now.AddMonths(5)
                                  where evnt.started_at > DateTime.Now
                                  join city in cities on SpecifyCity.GetCity(evnt.address) equals city
                                  where ngWordsList.All(word => !evnt.title.Contains(word))
                                  select new AllEventsInfo
                                  {
                                      Site = "site_zusaar.png",
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
                                      Organizer = evnt.owner_nickname,
                                  };
                foreach (var item in zusaaarInfo)
                {
                    allEventsInfo.Add(item);
                }
            }
        }
    }
}
