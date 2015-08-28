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
                var atndInfo = (from x in atndResult.events
                                join city in cities on SpecifyCity.GetCity(x._event.address) equals city
                                where x._event.started_at <= DateTime.Now.AddMonths(5)
                                where x._event.started_at > DateTime.Now
                                where ngWordsList.Any(word => !x._event.title.Contains(word))
                                select new AllEventsInfo
                                {
                                    Site = "site_atnd.png",
                                    Title = x._event.title,
                                    Event_uri = x._event.event_url,
                                    Start_at = x._event.started_at,
                                    End_at = x._event.ended_at,
                                    Description = x._event.description,
                                    Overview = HtmlToString.GetString(x._event.description, 50),
                                    Address = x._event.address,
                                    City = SpecifyCity.GetCity(x._event.address),
                                    Accepted = x._event.accepted,
                                    Limit = x._event.limit,
                                    Organizer = x._event.owner_nickname,
                                });
                foreach (var item in atndInfo)
                {
                    allEventsInfo.Add(item);
                }
            }
        }
    }
}
