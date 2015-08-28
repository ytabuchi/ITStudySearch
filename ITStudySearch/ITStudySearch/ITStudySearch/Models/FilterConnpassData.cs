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
                var connpassInfo = (from x in connpassResult.events
                                    join city in cities on SpecifyCity.GetCity(x.address) equals city
                                    where x.started_at <= DateTime.Now.AddMonths(5)
                                    where x.started_at > DateTime.Now
                                    where ngWordsList.Any(z => !x.title.Contains(z))
                                    select new AllEventsInfo
                                    {
                                        Site = "site_connpass.png",
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
                                        Organizer = (x.series == null ? x.owner_display_name : x.series.title),
                                    });
                foreach (var item in connpassInfo)
                {
                    allEventsInfo.Add(item);
                }
            }
        }
    }
}
