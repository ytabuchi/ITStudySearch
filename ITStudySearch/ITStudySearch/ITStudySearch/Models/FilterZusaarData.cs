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
                var zusaaarInfo = (from x in zusaarResult._event
                                   where x.started_at <= DateTime.Now.AddMonths(5)
                                   where x.started_at > DateTime.Now
                                   join city in cities on SpecifyCity.GetCity(x.address) equals city
                                   where ngWordsList.Any(word => !x.title.Contains(word))
                                   select new AllEventsInfo
                                   {
                                       Site = "site_zusaar.png",
                                       Title = x.title,
                                       Event_uri = x.event_url,
                                       Start_at = x.started_at,
                                       End_at = x.ended_at,
                                       Description = x.description,
                                       Overview = HtmlToString.GetString(x.description, 50),
                                       Address = x.address,
                                       City = SpecifyCity.GetCity(x.address),
                                       Accepted = x.accepted,
                                       Limit = x.limit,
                                       Organizer = x.owner_nickname,
                                   });
                foreach (var item in zusaaarInfo)
                {
                    allEventsInfo.Add(item);
                }
            }
        }
    }
}
