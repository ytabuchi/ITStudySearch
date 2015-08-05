using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ITStudySearch.Converters;

namespace ITStudySearch.Views
{
    class EventCell : ViewCell
    {
        public EventCell()
        {

            var titleLabel = new Label
            {
                TextColor = Color.FromHex("22638e"),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            titleLabel.SetBinding(Label.TextProperty, "title");


            var timeLabel = new Label
            {
                TextColor = Color.FromHex("777"),
                HorizontalOptions = LayoutOptions.StartAndExpand,
                YAlign = TextAlignment.End
            };
            timeLabel.SetBinding(Label.TextProperty,
                new Binding("start_at", stringFormat: "時間： {0:HH:mm}～"));

            var numberLabel = new Label
            {
                Text = "人数： ",
                TextColor = Color.FromHex("777"),
                HorizontalOptions = LayoutOptions.End,
                YAlign = TextAlignment.End,
            };
            var acceptLabel = new Label
            {
                FontSize = 20,
                TextColor = Color.FromHex("aa3333"),
                HorizontalOptions = LayoutOptions.End,
                YAlign = TextAlignment.End,
            };
            acceptLabel.SetBinding(Label.TextProperty,
                new Binding("accepted", stringFormat: "{0} "));
            var limitLabel = new Label
            {
                TextColor = Color.FromHex("777"),
                HorizontalOptions = LayoutOptions.End,
                YAlign = TextAlignment.End,
            };
            limitLabel.SetBinding(Label.TextProperty, "limit", stringFormat: " / {0}");

            var addressLabel = new Label
            {
                TextColor = Color.FromHex("777"),
                LineBreakMode = LineBreakMode.TailTruncation,
            };
            addressLabel.SetBinding(Label.TextProperty, "address");

            var contentLabel = new Label
            {
                TextColor = Color.FromHex("444"),
            };
            contentLabel.SetBinding(Label.TextProperty,
                new Binding("description", converter: new HtmlToPlainConverter(), converterParameter: "100"));
            //contentLabel.SetBinding(Label.TextProperty, "overview");



            #region 左側の日付Box

            var dMonth = new Label
            {
                TextColor = Color.FromHex("fff"),
                BackgroundColor = Color.FromHex("76bded"),
                FontSize = 14,
                XAlign = TextAlignment.Center,
            };
            dMonth.SetBinding(Label.TextProperty,
                new Binding("start_at", stringFormat: "{0:MM}"));
            var dDay = new Label
            {
                TextColor = Color.FromHex("555"),
                BackgroundColor = Color.FromHex("ececec"),
                FontSize = 30,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };
            dDay.SetBinding(Label.TextProperty,
                new Binding("start_at", stringFormat: "{0:dd}"));
            var dWeekDay = new Label
            {
                TextColor = Color.FromHex("333"),
                BackgroundColor = Color.FromHex("e3e3e3"),
                FontSize = 12,
                XAlign = TextAlignment.Center,
            };
            dWeekDay.SetBinding(Label.TextProperty,
                new Binding("start_at", stringFormat: "（{0:ddd}）"));

            var dateGrid = new Grid
            {
                Padding = new Thickness(1, 1, 1, 1),
                RowSpacing = 1,
                ColumnSpacing = 1,
                BackgroundColor = Color.FromHex("dedede"),
                VerticalOptions = LayoutOptions.Start,
                RowDefinitions = {
                    new RowDefinition { Height = new GridLength (20, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength (45, GridUnitType.Absolute) },
                    new RowDefinition { Height = new GridLength (18, GridUnitType.Absolute) },
                },
                ColumnDefinitions = {
                    new ColumnDefinition { Width = new GridLength (45, GridUnitType.Absolute) },
                },
            };
            dateGrid.Children.Add(dMonth, 0, 0);
            dateGrid.Children.Add(dDay, 0, 1);
            dateGrid.Children.Add(dWeekDay, 0, 2);

            #endregion

            #region 左側その下

            var cityLabel = new Label
            {
                TextColor = Color.FromHex("444"),
                FontSize = 14,
                XAlign = TextAlignment.Center,
            };
            cityLabel.SetBinding(Label.TextProperty, "city");

            var siteImage = new Image
            {
                WidthRequest = 40,
            };
            siteImage.SetBinding(Image.SourceProperty, "site");

            #endregion

            var cell = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = 10,
                Children = {
                    new StackLayout
                    {
                        Spacing = 15,
                        Children =
                        {
                            dateGrid,
                            cityLabel,
                            siteImage,
                        }
                    },
                    new StackLayout
                    {
                        Padding = new Thickness(10, 0, 10, 5),
                        Spacing = 10,
                        Children = {
                            titleLabel,
                            new BoxView
                            {
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Color = Color.FromHex("e2e2e2"),
                                HeightRequest = 1,
                            },
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    timeLabel,
                                    numberLabel,
                                    acceptLabel,
                                    limitLabel,
                                }
                            },
                            addressLabel,
                            new BoxView
                            {
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Color = Color.FromHex("e2e2e2"),
                                HeightRequest = 1,
                            },
                            contentLabel,
                        },
                    },
                }
            };

            this.View = cell;
        }
    }
}
