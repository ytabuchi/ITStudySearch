using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.ComponentModel;
using Newtonsoft.Json;
using Xamarin.Forms;
using ITStudySearch.Models;
using ITStudySearch.ViewModels;
using System.Threading.Tasks;

namespace ITStudySearch.Views
{
    public class StartPageCS : ContentPage
    {
        bool fetchFlag; // 通常フェッチ は true
        int n = 0;
        GetConnpassJson gcj = new GetConnpassJson();
        GetAtndJson gaj = new GetAtndJson();
        GetDoorkeeperJson gdj = new GetDoorkeeperJson();
        GetZusaarJson gzj = new GetZusaarJson();

        FilterConnpassData fcd = new FilterConnpassData();
        FilterAtndData fad = new FilterAtndData();
        FilterDoorkeeperData fdd = new FilterDoorkeeperData();
        FilterZusaarData fzd = new FilterZusaarData();

        HashSet<string> cities;
        NGWords ngWords;
        HashSet<string> ngWordsList;
        //List<string> ngWords;
        AreaSettingPageViewModel vm;
        //ObservableCollection<AllEventsInfo> allEventsInfo = new ObservableCollection<AllEventsInfo>();
        public ObservableCollection<AllEventsInfo> allEventsInfo { get; set; }

        DatePicker dateFrom;
        DatePicker dateTo;
        ListView list;
        StackLayout dateLayer;
        SearchBar searchLayer;
        ContentView waitingLayout;

        public StartPageCS()
        {
            this.allEventsInfo = new ObservableCollection<AllEventsInfo>();
            cities = new HashSet<string>();
            ChooseCity();
            ngWords = new NGWords();
            ngWordsList = new HashSet<string>();

            #region // 日付指定レイヤー dateLayer

            dateFrom = new DatePicker
            {
                Date = DateTime.Now,
                Format = "M/d",
                WidthRequest = Device.OnPlatform(75, 75, 120),
            };
            dateTo = new DatePicker
            {
                Date = DateTime.Now.AddDays(2),
                Format = "M/d",
                WidthRequest = Device.OnPlatform(75, 75, 120),
                MinimumDate = dateFrom.Date,
            };
            dateFrom.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                if (dateFrom.Date > dateTo.Date)
                    dateTo.Date = dateFrom.Date.AddDays(2);
                dateTo.MinimumDate = dateFrom.Date.AddDays(1);
            };
            if (Device.OS == TargetPlatform.Windows)
            {
                dateTo.WidthRequest = 120;
                dateFrom.WidthRequest = 120;
            }
            var searchButton = new Button
            {
                Text = "検索",
                WidthRequest = 100,
                VerticalOptions = LayoutOptions.Center,
            };
            searchButton.Clicked += dateLayer_SearchButton_Clicked;

            dateLayer = new StackLayout
            {
                IsVisible = false,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    dateFrom,
                    new Label { Text = "~", YAlign = TextAlignment.Center },
                    dateTo,
                    searchButton,
                }
            };
            #endregion

            #region // 検索レイヤー searchLayer

            searchLayer = new SearchBar
            {
                IsVisible = false,
                Placeholder = "' 'か','でOR検索、&でAND検索",
            };
            searchLayer.SearchButtonPressed += SearchLayer_SearchButtonPressed;

            #endregion

            // クルクルレイヤー waitingLayout
            waitingLayout = new WaitingLayout();

            list = new ListView
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(typeof(EventCell)), // PostCell テンプレート
                ItemsSource = allEventsInfo,
            };
            list.ItemTapped += list_ItemTapped;
            list.ItemAppearing += List_ItemAppearing;

            #region ToolbarItems

            ToolbarItems.Add(new ToolbarItem
            {
                Icon = "Search.png",
                Text = "絞り込み検索",
                Command = new Command(() =>
                {
                    this.dateLayer.IsVisible = false;
                    if (this.searchLayer.IsVisible)
                    {
                        this.searchLayer.IsVisible = false;
                    }
                    else
                    {
                        searchLayer.IsVisible = true;
                    }
                })
            });
            ToolbarItems.Add(new ToolbarItem
            {
                Icon = "Calendar.png",
                Text = "日付選択",
                Command = new Command(() =>
                {
                    this.searchLayer.IsVisible = false;
                    if (this.dateLayer.IsVisible)
                    {
                        this.dateLayer.IsVisible = false;
                    }
                    else
                    {
                        this.dateLayer.IsVisible = true;
                    }
                })
            });
            ToolbarItems.Add(new ToolbarItem
            {
                Icon = "Setting.png",
                Text = "設定",
                Command = new Command(() =>
                {
                    // 各種データを初期化して次のページへ
                    n = 0;
                    allEventsInfo.Clear();
                    list.ItemsSource = allEventsInfo;
                    // ここまで
                    Navigation.PushAsync(new SettingPageCS());
                }),
            });

            #endregion

            Title = " IT 勉強会検索";
            Content = new StackLayout
            {
                Children = {
                    searchLayer,
                    dateLayer,
                    list,
                    waitingLayout,
                },
            };
        }


        /// <summary>
        /// ページ表示時に allEventInfo にデータが無ければ取得します。
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
#if DEBUG
            System.Diagnostics.Debug.WriteLine("StartPage Appearing");
#endif
            if (allEventsInfo.Count == 0)
            {
                waitingLayout.IsVisible = true;

                ngWordsList = ngWords.GetNGWordsSet();
                ChooseCity();
                allEventsInfo = await GetJsonData(n);
                if (allEventsInfo == null)
                    await DisplayAlert("Error", "すべてのサイトが死んでるかネットワークエラーです。\nネットワークの設定を確認してみてください。", "OK");
                n++;
                list.ItemsSource = allEventsInfo;
                waitingLayout.IsVisible = false;
            }
        }

        /// <summary>
        /// ListView の最後が表示されたら追加分を取得するメソッドです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void List_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (allEventsInfo.Last() == e.Item as AllEventsInfo && fetchFlag)
            {
                waitingLayout.IsVisible = true;

                allEventsInfo = await GetJsonData(n);
                if (allEventsInfo == null)
                    await DisplayAlert("Error", "すべてのサイトが死んでるかネットワークエラーです。\nネットワークの設定を確認してみてください。", "OK");
                n++;
                list.ItemsSource = allEventsInfo;

                waitingLayout.IsVisible = false;
            }

        }

        /// <summary>
        /// 日付レイヤーの SearchButton クリック時のメソッドです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void dateLayer_SearchButton_Clicked(object sender, EventArgs e)
        {
            dateLayer.IsVisible = false;
            allEventsInfo.Clear();

            waitingLayout.IsVisible = true;
            allEventsInfo = await GetJsonData(dateFrom.Date, dateTo.Date);
            if (allEventsInfo == null)
                await DisplayAlert("Error", "すべてのサイトが死んでるかネットワークエラーです。\nネットワークの設定を確認してみてください。", "OK");
            list.ItemsSource = allEventsInfo;
            waitingLayout.IsVisible = false;
        }

        /// <summary>
        /// 検索レイヤーの SearchButton クリック時のメソッドです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SearchLayer_SearchButtonPressed(object sender, EventArgs e)
        {
            this.searchLayer.IsVisible = false;
            allEventsInfo.Clear();

            waitingLayout.IsVisible = true;
            allEventsInfo = await GetJsonData(searchLayer.Text);
            if (allEventsInfo == null)
                await DisplayAlert("Error", "すべてのサイトが死んでるかネットワークエラーです。\nネットワークの設定を確認してみてください。", "OK");
            list.ItemsSource = allEventsInfo;
            waitingLayout.IsVisible = false;
        }


        /// <summary>
        /// Json データをパラメーターを指定せずに 25件ずつ取得していきます。
        /// </summary>
        /// <param name="n">1回取得毎にインクリメント</param>
        /// <returns></returns>
        private async Task<ObservableCollection<AllEventsInfo>> GetJsonData(int n)
        {
            int count = allEventsInfo.Count();
#if DEBUG
            System.Diagnostics.Debug.WriteLine(count);
#endif
            fetchFlag = true;
            var ConnpassTask = gcj.GetConnpassJsonAsync(1 + n * 25);
            var AtndTask = gaj.GetAtndJsonAsync(1 + n * 25);
            var DoorkeeperTask = gdj.GetDoorkeeperJsonAsync(1 + n);
            var ZusaarTask = gzj.GetZusaarJsonAsync(1 + n * 25);

            var connpassResult = await ConnpassTask;
            var atndResult = await AtndTask;
            var doorkeeperResult = await DoorkeeperTask;
            var zusaarResult = await ZusaarTask;

            if (atndResult == null && connpassResult == null && doorkeeperResult == null && zusaarResult == null)
                return null;
#if DEBUG
            System.Diagnostics.Debug.WriteLine(connpassResult != null ? $"Connpass OK: {connpassResult.events.Count}件" : "Connpass NG");
            System.Diagnostics.Debug.WriteLine(atndResult != null ? $"Atnd OK: {atndResult.events.Count}件" : "Atnd NG");
            System.Diagnostics.Debug.WriteLine(doorkeeperResult != null ? $"Doorkeeper OK: {doorkeeperResult.Count}件" : "Doorkeeper NG");
            System.Diagnostics.Debug.WriteLine(zusaarResult != null ? $"Zusaar OK: {zusaarResult._event.Count}件" : "Zusaar NG");
#endif

            fcd.FilterData(connpassResult, allEventsInfo, ngWordsList, cities);
            fad.FilterData(atndResult, allEventsInfo, ngWordsList, cities);
            fdd.FilterData(doorkeeperResult, allEventsInfo, ngWordsList, cities);
            fzd.FilterData(zusaarResult, allEventsInfo, ngWordsList, cities);

#if DEBUG
            System.Diagnostics.Debug.WriteLine($"All Events: {allEventsInfo.Count()}件");
#endif
            if (allEventsInfo.Count() != count)
            {
                if (allEventsInfo != null)
                {
                    allEventsInfo = new ObservableCollection<AllEventsInfo>(allEventsInfo.OrderBy(e => e.Start_at));
                    return allEventsInfo;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                fetchFlag = false;
                await DisplayAlert("注意", "これ以上はデータが無いようです。", "OK");
                return allEventsInfo;
            }
        }

        /// <summary>
        /// 指定日付のイベントを取得するメソッドです。
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private async Task<ObservableCollection<AllEventsInfo>> GetJsonData(DateTime from, DateTime to)
        {
            fetchFlag = false; // データ追加なし
            var ConnpassTask = gcj.GetConnpassJsonAsync(from, to);
            var AtndTask = gaj.GetAtndJsonAsync(from, to);
            var DoorkeeperTask = gdj.GetDoorkeeperJsonAsync(from, to);
            var ZusaarTask = gzj.GetZusaarJsonAsync(from, to);

            var connpassResult = await ConnpassTask;
            var atndResult = await AtndTask;
            var doorkeeperResult = await DoorkeeperTask;
            var zusaarResult = await ZusaarTask;

            if (atndResult == null && connpassResult == null && doorkeeperResult == null && zusaarResult == null)
                return null;
#if DEBUG
            System.Diagnostics.Debug.WriteLine(connpassResult != null ? $"[DateTime]Connpass OK: {connpassResult.events.Count}件" : "[DateTime]Connpass NG");
            System.Diagnostics.Debug.WriteLine(atndResult != null ? $"[DateTime]Atnd OK: {atndResult.events.Count}件" : "[DateTime]Atnd NG");
            System.Diagnostics.Debug.WriteLine(doorkeeperResult != null ? $"[DateTime]Doorkeeper OK: {doorkeeperResult.Count}件" : "[DateTime]Doorkeeper NG");
            System.Diagnostics.Debug.WriteLine(zusaarResult != null ? $"[DateTime]Zusaar OK: {zusaarResult._event.Count}件" : "[DateTime]Zusaar NG");
#endif

            fcd.FilterData(connpassResult, allEventsInfo, ngWordsList, cities);
            fad.FilterData(atndResult, allEventsInfo, ngWordsList, cities);
            fdd.FilterData(doorkeeperResult, allEventsInfo, ngWordsList, cities);
            fzd.FilterData(zusaarResult, allEventsInfo, ngWordsList, cities);

#if DEBUG
            System.Diagnostics.Debug.WriteLine($"All Event: {allEventsInfo.Count()}件");
#endif

            if (allEventsInfo != null)
            {
                allEventsInfo = new ObservableCollection<AllEventsInfo>(allEventsInfo.OrderBy(e => e.Start_at));
                return allEventsInfo;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 検索ワードを含むイベントを取得するメソッドです。
        /// </summary>
        /// <param name="searchWords"></param>
        /// <returns></returns>
        private async Task<ObservableCollection<AllEventsInfo>> GetJsonData(string searchWords)
        {
            fetchFlag = false; // データ追加なし
            var ConnpassTask = gcj.GetConnpassJsonAsync(searchWords);
            var AtndTask = gaj.GetAtndJsonAsync(searchWords);
            var DoorkeeperTask = gdj.GetDoorkeeperJsonAsync(searchWords);
            var ZusaarTask = gzj.GetZusaarJsonAsync(searchWords);

            var connpassResult = await ConnpassTask;
            var atndResult = await AtndTask;
            var doorkeeperResult = await DoorkeeperTask;
            var zusaarResult = await ZusaarTask;

            if (atndResult == null && connpassResult == null && doorkeeperResult == null && zusaarResult == null)
                return null;
#if DEBUG
            System.Diagnostics.Debug.WriteLine(connpassResult != null ? $"[Search]Connpass OK: {connpassResult.events.Count}件" : "[DateTime]Connpass NG");
            System.Diagnostics.Debug.WriteLine(atndResult != null ? $"[Search]Atnd OK: {atndResult.events.Count}件" : "[DateTime]Atnd NG");
            System.Diagnostics.Debug.WriteLine(doorkeeperResult != null ? $"[Search]Doorkeeper OK: {doorkeeperResult.Count}件" : "[DateTime]Doorkeeper NG");
            System.Diagnostics.Debug.WriteLine(zusaarResult != null ? $"[Search]Zusaar OK: {zusaarResult._event.Count}件" : "[DateTime]Zusaar NG");
#endif

            #region フェッチデータ
            fcd.FilterData(connpassResult, allEventsInfo, ngWordsList, cities);
            fad.FilterData(atndResult, allEventsInfo, ngWordsList, cities);
            fdd.FilterData(doorkeeperResult, allEventsInfo, ngWordsList, cities);
            fzd.FilterData(zusaarResult, allEventsInfo, ngWordsList, cities);

#if DEBUG
            System.Diagnostics.Debug.WriteLine($"All Event: {allEventsInfo.Count()}件");
#endif

            if (allEventsInfo != null)
            {
                allEventsInfo = new ObservableCollection<AllEventsInfo>(allEventsInfo.OrderBy(e => e.Start_at));
                return allEventsInfo;
            }
            else
            {
                return null;
            }
            #endregion

        }


        /// <summary>
        /// ListView の Item Tap メソッドです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void list_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            list.SelectedItem = null;
            await Navigation.PushAsync(new DetailPageCS(e.Item as AllEventsInfo));
        }

        /// <summary>
        /// 抽出対象になっている都道府県を HashSet に入れるメソッドです。
        /// </summary>
        void ChooseCity()
        {
            cities.Clear();
            var data = DependencyService.Get<ISaveAndLoad>().LoadData("settings.json");
            //if (string.IsNullOrEmpty(data) || data == "null")
            //    vm = new AreaSettingPageViewModel();
            //else
            //    vm = JsonConvert.DeserializeObject<AreaSettingPageViewModel>(data);
            vm = (string.IsNullOrEmpty(data) || data == "null") ? new AreaSettingPageViewModel() : JsonConvert.DeserializeObject<AreaSettingPageViewModel>(data);

            #region 長すぎる…

            if (vm.HokkaidoValue)
                cities.Add("北海道");
            if (vm.AomoriValue)
                cities.Add("青森県");
            if (vm.IwateValue)
                cities.Add("岩手県");
            if (vm.MiyagiValue)
                cities.Add("宮城県");
            if (vm.AkitaValue)
                cities.Add("秋田県");
            if (vm.YamagataValue)
                cities.Add("山形県");
            if (vm.FukushimaValue)
                cities.Add("福島県");
            if (vm.IbarakiValue)
                cities.Add("茨城県");
            if (vm.TochigiValue)
                cities.Add("栃木県");
            if (vm.GunmaValue)
                cities.Add("群馬県");
            if (vm.SaitamaValue)
                cities.Add("埼玉県");
            if (vm.ChibaValue)
                cities.Add("千葉県");
            if (vm.TokyoValue)
                cities.Add("東京都");
            if (vm.KanagawaValue)
                cities.Add("神奈川県");
            if (vm.NiigataValue)
                cities.Add("新潟県");
            if (vm.ToyamaValue)
                cities.Add("富山県");
            if (vm.IshikawaValue)
                cities.Add("石川県");
            if (vm.FukuiValue)
                cities.Add("福井県");
            if (vm.YamanashiValue)
                cities.Add("山梨県");
            if (vm.NaganoValue)
                cities.Add("長野県");
            if (vm.GifuValue)
                cities.Add("岐阜県");
            if (vm.ShizuokaValue)
                cities.Add("静岡県");
            if (vm.AichiValue)
                cities.Add("愛知県");
            if (vm.MieValue)
                cities.Add("三重県");
            if (vm.ShigaValue)
                cities.Add("志賀県");
            if (vm.KyotoValue)
                cities.Add("京都府");
            if (vm.OsakaValue)
                cities.Add("大阪府");
            if (vm.HyogoValue)
                cities.Add("兵庫県");
            if (vm.NaraValue)
                cities.Add("奈良県");
            if (vm.WakayamaValue)
                cities.Add("和歌山県");
            if (vm.TottoriValue)
                cities.Add("鳥取県");
            if (vm.ShimaneValue)
                cities.Add("島根県");
            if (vm.OkayamaValue)
                cities.Add("岡山県");
            if (vm.HiroshimaValue)
                cities.Add("広島県");
            if (vm.YamaguchiValue)
                cities.Add("山口県");
            if (vm.TokushimaValue)
                cities.Add("徳島県");
            if (vm.KagawaValue)
                cities.Add("香川県");
            if (vm.EhimeValue)
                cities.Add("愛媛県");
            if (vm.KochiValue)
                cities.Add("高知県");
            if (vm.FukuokaValue)
                cities.Add("福岡県");
            if (vm.SagaValue)
                cities.Add("佐賀県");
            if (vm.NagasakiValue)
                cities.Add("長崎県");
            if (vm.KumamotoValue)
                cities.Add("熊本県");
            if (vm.OitaValue)
                cities.Add("大分県");
            if (vm.MiyazakiValue)
                cities.Add("宮崎県");
            if (vm.KagoshimaValue)
                cities.Add("鹿児島県");
            if (vm.OkinawaValue)
                cities.Add("沖縄県");
            if (vm.OtherValue)
                cities.Add("その他");
            #endregion
#if DEBUG
            foreach (var item in cities)
            {
                System.Diagnostics.Debug.WriteLine("Cities: " + item);
            }
#endif
        }

    }
}
