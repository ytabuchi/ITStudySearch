using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITStudySearch.Models
{
    class GetAllJson
    {
//        public async Task<ObservableCollection<AllEventsInfo>> GetJsonData(DateTime from, DateTime to)
//        {
//            flag = false;
//            var ConnpassTask = gcj.GetConnpassJsonAsync(from, to);
//            var AtndTask = gaj.GetAtndJsonAsync(from, to);
//            var DoorkeeperTask = gdj.GetDoorkeeperJsonAsync(from, to);
//            var ZusaarTask = gzj.GetZusaarJsonAsync(from, to);

//            var connpassResult = await ConnpassTask;
//            var atndResult = await AtndTask;
//            var doorkeeperResult = await DoorkeeperTask;
//            var zusaarResult = await ZusaarTask;

//            // if (atndResult == null || connpassResult == null || doorkeeperResult == null)
//            if (atndResult == null && connpassResult == null && doorkeeperResult == null && zusaarResult == null)
//                await this.DisplayAlert("Error", "すべてのサイトが死んでるかネットワークエラーです。\nネットワークの設定を確認してみてください。", "OK");
//#if DEBUG
//            System.Diagnostics.Debug.WriteLine(connpassResult != null ? $"[DateTime]Connpass OK: {connpassResult.events.Count}件" : "[DateTime]Connpass NG");
//            System.Diagnostics.Debug.WriteLine(atndResult != null ? $"[DateTime]Atnd OK: {atndResult.events.Count}件" : "[DateTime]Atnd NG");
//            System.Diagnostics.Debug.WriteLine(doorkeeperResult != null ? $"[DateTime]Doorkeeper OK: {doorkeeperResult.Count}件" : "[DateTime]Doorkeeper NG");
//            System.Diagnostics.Debug.WriteLine(zusaarResult != null ? $"[DateTime]Zusaar OK: {zusaarResult._event.Count}件" : "[DateTime]Zusaar NG");
//#endif

//            #region フェッチデータ
//            fcd.FilterData(connpassResult, allEventsInfo, ngWordsList, cities);
//            fad.FilterData(atndResult, allEventsInfo, ngWordsList, cities);
//            fdd.FilterData(doorkeeperResult, allEventsInfo, ngWordsList, cities);
//            fzd.FilterData(zusaarResult, allEventsInfo, ngWordsList, cities);

//#if DEBUG
//            System.Diagnostics.Debug.WriteLine($"All Event: {allEventsInfo.Count()}件");
//#endif

//            if (allEventsInfo != null)
//            {
//                allEventsInfo = new ObservableCollection<AllEventsInfo>(allEventsInfo.OrderBy(e => e.Start_at));
//                return allEventsInfo;
//            }
//            else
//            {
//                return null;
//            }
//            #endregion
//        }
    }
}
