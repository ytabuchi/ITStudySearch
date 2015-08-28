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
                var doorkeeperInfo = (from x in doorkeeperResult
                                      join city in cities on SpecifyCity.GetCity(x._event.address) equals city
                                      where x._event.starts_at <= DateTime.Now.AddMonths(5)
                                      where x._event.starts_at > DateTime.Now
                                      where ngWordsList.Any(z => !x._event.title.Contains(z))
                                      select new AllEventsInfo
                                      {
                                          Site = "site_doorkeeper.png",
                                          Title = x._event.title,
                                          Event_uri = x._event.public_url,
                                          Start_at = x._event.starts_at,
                                          End_at = x._event.ends_at,
                                          Description = x._event.description,
                                          Overview = HtmlToString.GetString(x._event.description, 50),
                                          Address = x._event.address,
                                          City = SpecifyCity.GetCity(x._event.address),
                                          Accepted = x._event.participants,
                                          Limit = x._event.ticket_limit,
                                          Organizer = x._event.@group.name,
                                      });
                foreach (var item in doorkeeperInfo)
                {
                    allEventsInfo.Add(item);
                }
            }
        }
    }
}
