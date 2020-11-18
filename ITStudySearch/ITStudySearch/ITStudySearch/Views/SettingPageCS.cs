using System;
using Xamarin.Forms;

namespace ITStudySearch.Views
{
    public class SettingPageCS : ContentPage
    {
        public SettingPageCS()
        {
            #region // ライセンス
            
            #endregion

            var areaSetting = new ImageCell
            {
                ImageSource = "AreaSetting.png",
                Text = "地域設定",
                //TextColor = Device.OnPlatform(Color.Default, Color.FromHex("666"), Color.Default),
                //Detail = "検索対象の都道府県を選択してください。",
                Command = new Command(async () => await Navigation.PushAsync(new AreaSettingPageXaml())),
            };
            // TODO: NG Word をカンマ区切りで作成しフィルタ対象にする
            // 2015/8/30: NGWords.cs 完成
            var ngSetting = new ImageCell
            {
                ImageSource = "NGSetting.png",
                Text = "NGワード設定",
                //TextColor = Device.OnPlatform(Color.Default, Color.FromHex("666"), Color.Default),
                //Command = new Command(async () => await DisplayAlert("NG ワード", "現バージョンでは固定で\n\n恋活, 婚活, カップル, コンパ, お見合い, 合コン, 街コン, パーティ, Party, 副業, 起業, グルメ\n\nを NG ワードにしています。", "OK")),
                Command = new Command(async () => await Navigation.PushAsync(new NGWordsSettingPageCS())),
            };

            //var test = new TableSection();
            //test.Title = "Settings";

            var tv = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection("設定")
                    {
                        areaSetting,
                        ngSetting,
                    },
                    new TableSection("ヘルプ")
                    {
                        new TextCell
                        {
                            Text = "使い方(これから書く)",
                            //Command = new Command(() => Device.OpenUri(new Uri("http://ytabuchi.hatenablog.com/entry/itstudysearch-help"))),
                        },
                        new TextCell {
                            Text = "プライバシーポリシー",
                            Command = new Command(() => Device.OpenUri(new Uri("http://ytabuchi.hatenablog.com/entry/privacypolicies"))),
                        },
                        new TextCell {
                            Text = "著作権情報",
                            Command = new Command(() => Navigation.PushAsync(new LicensePageCS())),
                        },
                    },
                    new TableSection("アプリケーション情報")
                    {
                        new ViewCell
                        {
                            View = new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Padding = new Thickness(19, 0),
                                Children =
                                {
                                    new Label
                                    {
                                        Text = "アプリケーション名",
                                        VerticalTextAlignment = TextAlignment.Center,
                                    },
                                    new Label
                                    {
                                        Text = "IT勉強会検索",
                                        VerticalTextAlignment = TextAlignment.Center,
                                        HorizontalOptions = LayoutOptions.EndAndExpand,
                                    },
                                }
                            }
                        },
                        new ViewCell
                        {
                            View = new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Padding = new Thickness(19, 0),
                                Children =
                                {
                                    new Label
                                    {
                                        Text = "バージョン",
                                        VerticalTextAlignment = TextAlignment.Center,
                                    },
                                    new Label
                                    {
                                        Text = "v 0.0.2",
                                        VerticalTextAlignment = TextAlignment.Center,
                                        HorizontalOptions = LayoutOptions.EndAndExpand,
                                    },
                                }
                            }
                        },
                        new ViewCell
                        {
                            View = new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Padding = new Thickness(19, 0),
                                Children =
                                {
                                    new Label
                                    {
                                        Text = "作成者",
                                        VerticalTextAlignment = TextAlignment.Center,
                                    },
                                    new Label
                                    {
                                        Text = "Yoshito Tabuchi",
                                        VerticalTextAlignment = TextAlignment.Center,
                                        HorizontalOptions = LayoutOptions.EndAndExpand,
                                    },
                                }
                            },
                        },


                    }
                }
            };

            Title = "このアプリについて";
            Content = tv;
        }
    }
}
