using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ITStudySearch.ViewModels;

namespace ITStudySearch.Models
{
    class GetAllEventsInfo
    {
//        GetAtndJson gaj = new GetAtndJson();
//        GetConnpassJson gcj = new GetConnpassJson();
//        GetDoorkeeperJson gdj = new GetDoorkeeperJson();
//        AreaSettingPageViewModel vm;

//        async Task<List<AllEventsInfo>> GetAllEventsInfoAsync(DateTime from, DateTime to)
//        {

//            var ConnpassTask = gcj.GetConnpassJsonAsync(from, to);
//            var AtndTask = gaj.GetAtndJsonAsync(from, to);
//            var DoorkeeperTask = gdj.GetDoorkeeperJsonAsync(from, to);

//            var connpassResult = await ConnpassTask;
//            var atndResult = await AtndTask;
//            var doorkeeperResult = await DoorkeeperTask;

//#if DEBUG
//            System.Diagnostics.Debug.WriteLine(connpassResult != null ? $"Connpass OK: {connpassResult.events.Count}件" : "Connpass NG");
//            System.Diagnostics.Debug.WriteLine(atndResult != null ? $"Atnd OK: {atndResult.events.Count}件" : "Atnd NG");
//            System.Diagnostics.Debug.WriteLine(doorkeeperResult != null ? $"Doorkeeper OK: {doorkeeperResult.Count}件" : "Doorkeeper NG");
//#endif

//            ChooseCity();


//            if (atndResult == null || connpassResult == null || doorkeeperResult == null)
//                await App.Current.MainPage.DisplayAlert("Error", "何かのサイトでエラーです", "OK");


//            #region フェッチデータ


//            if (connpassResult != null)
//            {
//                var connpassInfo = (from x in connpassResult.events
//                                    where cities.Any(y => SpecifyCity.GetCity(x.address) == y)
//                                    select new AllEventsInfo
//                                    {
//                                        site = "connpass100.png",
//                                        title = x.title,
//                                        event_uri = x.event_url,
//                                        start_at = x.started_at,
//                                        end_at = x.ended_at,
//                                        description = x.description,
//                                        address = x.address,
//                                        city = SpecifyCity.GetCity(x.address),
//                                        accepted = x.accepted,
//                                        limit = x.limit,
//                                    }).ToList();
//                allEventsInfo.AddRange(connpassInfo);
//            }

//            if (atndResult != null)
//            {
//                var atndInfo = (from x in atndResult.events
//                                where !(x._event.title.Contains("恋活") ||
//                                x._event.title.Contains("婚活") ||
//                                x._event.title.Contains("パーティ") ||
//                                x._event.title.Contains("Party") ||
//                                x._event.title.Contains("副業") ||
//                                x._event.title.Contains("起業") ||
//                                x._event.title.Contains("グルメ"))
//                                where cities.Any(y => SpecifyCity.GetCity(x._event.address) == y)
//                                select new AllEventsInfo
//                                {
//                                    site = "atnd100.png",
//                                    title = x._event.title,
//                                    event_uri = x._event.event_url,
//                                    start_at = x._event.started_at,
//                                    end_at = x._event.ended_at,
//                                    description = x._event.description,
//                                    address = x._event.address,
//                                    city = SpecifyCity.GetCity(x._event.address),
//                                    accepted = x._event.accepted,
//                                    limit = x._event.limit,
//                                }).ToList();
//                allEventsInfo.AddRange(atndInfo);
//            }

//            if (doorkeeperResult != null)
//            {
//                var doorkeeperInfo = (from x in doorkeeperResult
//                                      where cities.Any(y => SpecifyCity.GetCity(x._event.address) == y)
//                                      select new AllEventsInfo
//                                      {
//                                          site = "doorkeeper100.png",
//                                          title = x._event.title,
//                                          event_uri = x._event.public_url,
//                                          start_at = x._event.starts_at,
//                                          end_at = x._event.ends_at,
//                                          description = x._event.description,
//                                          address = x._event.address,
//                                          city = SpecifyCity.GetCity(x._event.address),
//                                          accepted = x._event.participants,
//                                          limit = x._event.ticket_limit,
//                                      }).ToList();
//                allEventsInfo.AddRange(doorkeeperInfo);
//            }

//#if DEBUG
//            System.Diagnostics.Debug.WriteLine($"All Event: {allEventsInfo.Count()}件");
//#endif

//            if (allEventsInfo != null)
//            {
//                allEventsInfo = allEventsInfo.OrderBy(e => e.start_at).ToList();
//                return allEventsInfo;
//            }
//            else
//            {
//                return null;
//            }


//            #endregion

//        }

//        void ChooseCity()
//        {
//            var data = DependencyService.Get<ISaveAndLoad>().LoadData("settings.json");
//            vm = data == null ? new AreaSettingPageViewModel() : JsonConvert.DeserializeObject<AreaSettingPageViewModel>(data);

//            cities = new List<string>();

//            #region 長すぎる…

//            if (vm.HokkaidoValue)
//                cities.Add("北海道");
//            if (vm.AomoriValue)
//                cities.Add("青森県");
//            if (vm.IwateValue)
//                cities.Add("岩手県");
//            if (vm.MiyagiValue)
//                cities.Add("宮城県");
//            if (vm.AkitaValue)
//                cities.Add("秋田県");
//            if (vm.YamagataValue)
//                cities.Add("山形県");
//            if (vm.FukushimaValue)
//                cities.Add("福島県");
//            if (vm.IbarakiValue)
//                cities.Add("茨城県");
//            if (vm.TochigiValue)
//                cities.Add("栃木県");
//            if (vm.GunmaValue)
//                cities.Add("群馬県");
//            if (vm.SaitamaValue)
//                cities.Add("埼玉県");
//            if (vm.ChibaValue)
//                cities.Add("千葉県");
//            if (vm.TokyoValue)
//                cities.Add("東京都");
//            if (vm.KanagawaValue)
//                cities.Add("神奈川県");
//            if (vm.NiigataValue)
//                cities.Add("新潟県");
//            if (vm.ToyamaValue)
//                cities.Add("富山県");
//            if (vm.IshikawaValue)
//                cities.Add("石川県");
//            if (vm.FukuiValue)
//                cities.Add("福井県");
//            if (vm.YamanashiValue)
//                cities.Add("山梨県");
//            if (vm.NaganoValue)
//                cities.Add("長野県");
//            if (vm.GifuValue)
//                cities.Add("岐阜県");
//            if (vm.ShizuokaValue)
//                cities.Add("静岡県");
//            if (vm.AichiValue)
//                cities.Add("愛知県");
//            if (vm.MieValue)
//                cities.Add("三重県");
//            if (vm.ShigaValue)
//                cities.Add("志賀県");
//            if (vm.KyotoValue)
//                cities.Add("京都府");
//            if (vm.OsakaValue)
//                cities.Add("大阪府");
//            if (vm.HyogoValue)
//                cities.Add("兵庫県");
//            if (vm.NaraValue)
//                cities.Add("奈良県");
//            if (vm.WakayamaValue)
//                cities.Add("和歌山県");
//            if (vm.TottoriValue)
//                cities.Add("鳥取県");
//            if (vm.ShimaneValue)
//                cities.Add("島根県");
//            if (vm.OkayamaValue)
//                cities.Add("岡山県");
//            if (vm.HiroshimaValue)
//                cities.Add("広島県");
//            if (vm.YamaguchiValue)
//                cities.Add("山口県");
//            if (vm.TokushimaValue)
//                cities.Add("徳島県");
//            if (vm.KagawaValue)
//                cities.Add("香川県");
//            if (vm.EhimeValue)
//                cities.Add("愛媛県");
//            if (vm.KochiValue)
//                cities.Add("高知県");
//            if (vm.FukuokaValue)
//                cities.Add("福岡県");
//            if (vm.SagaValue)
//                cities.Add("佐賀県");
//            if (vm.NagasakiValue)
//                cities.Add("長崎県");
//            if (vm.KumamotoValue)
//                cities.Add("熊本県");
//            if (vm.OitaValue)
//                cities.Add("大分県");
//            if (vm.MiyazakiValue)
//                cities.Add("宮崎県");
//            if (vm.KagoshimaValue)
//                cities.Add("鹿児島県");
//            if (vm.OkinawaValue)
//                cities.Add("沖縄県");
//            if (vm.OtherValue)
//                cities.Add("その他");
//            #endregion
//        }
    }
}
