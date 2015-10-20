using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITStudySearch.Models
{
    class FilterDoorkeeperData
    {
        public void FilterData(List<DoorkeeperJson> doorkeeperResult, ObservableCollection<AllEventsInfo> allEventsInfo, HashSet<string> ngWordsList, HashSet<string> cities)
        {
            if (doorkeeperResult != null)
            {
                var doorkeeperInfo = from evnt in doorkeeperResult
                                     join city in cities on SpecifyCity.GetCity(evnt._event.address) equals city
                                     where evnt._event.starts_at <= DateTime.Now.AddMonths(5)
                                     where evnt._event.starts_at > DateTime.Now
                                     where ngWordsList.All(word => !evnt._event.title.Contains(word))
                                     select new AllEventsInfo
                                     {
                                         Site = "site_doorkeeper.png",
                                         Title = evnt._event.title,
                                         Event_uri = evnt._event.public_url,
                                         Start_at = evnt._event.starts_at,
                                         End_at = evnt._event.ends_at,
                                         Description = evnt._event.description,
                                         Overview = HtmlToString.GetString(evnt._event.description, 50),
                                         Address = evnt._event.address,
                                         City = SpecifyCity.GetCity(evnt._event.address),
                                         Accepted = evnt._event.participants,
                                         Limit = evnt._event.ticket_limit,
                                         Organizer = evnt._event.@group.name,
                                     };
                foreach (var item in doorkeeperInfo)
                {
                    allEventsInfo.Add(item);
                }
            }
        }
    }
}
