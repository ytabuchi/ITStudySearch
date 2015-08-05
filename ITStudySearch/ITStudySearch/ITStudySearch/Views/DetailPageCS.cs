using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using ITStudySearch.Models;
using ITStudySearch.Converters;

namespace ITStudySearch.Views
{
    public class DetailPageCS : ContentPage
    {
        public DetailPageCS(AllEventsInfo items)
        {
            this.BindingContext = items;

            // Tap 時の動作
            var tap = new TapGestureRecognizer();
            tap.Tapped += (sender, e) =>
            {
                // ブラウザで Uri を開く
                Device.OpenUri(new Uri(((Label)sender).Text));
            };

            var titleLabel = new Label
            {
                TextColor = Color.FromHex("22638e"),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            titleLabel.SetBinding(Label.TextProperty, "title");

            var dateLabel = new Label
            {
                TextColor = Color.FromHex("777"),
            };
            dateLabel.SetBinding(Label.TextProperty,
                new Binding("start_at", stringFormat: "日時： {0:yyyy/M/d HH:mm} ～"));

            var numberLabel = new Label
            {
                Text = "人数： ",
                TextColor = Color.FromHex("777"),
                YAlign = TextAlignment.End,
            };
            var acceptLabel = new Label
            {
                FontSize = 20,
                TextColor = Color.FromHex("aa3333"),
                YAlign = TextAlignment.End,
            };
            acceptLabel.SetBinding(Label.TextProperty,
                new Binding("accepted", stringFormat: "{0} "));
            var limitLabel = new Label
            {
                TextColor = Color.FromHex("777"),
                YAlign = TextAlignment.End,
            };
            limitLabel.SetBinding(Label.TextProperty, "limit", stringFormat: " / {0}");

            var addressLabel = new Label
            {
                TextColor = Color.FromHex("777"),
                LineBreakMode = LineBreakMode.TailTruncation,
            };
            addressLabel.SetBinding(Label.TextProperty, "address", stringFormat: "場所： {0}");

            var siteImage = new Image
            {
                WidthRequest = 40,
            };
            siteImage.SetBinding(Image.SourceProperty, "site");

            var urlLabel = new Label
            {
                FontSize = 20,
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = Color.FromHex("425fc9"),
            };
            urlLabel.SetBinding(Label.TextProperty, "event_uri");
            urlLabel.GestureRecognizers.Add(tap);

            var contentLabel = new Label
            {
                TextColor = Color.FromHex("444"),
            };
            contentLabel.SetBinding(Label.TextProperty,
                new Binding("description", converter: new HtmlToPlainConverter()));


            Title = items.title;
            Content = new ScrollView
            {
                Padding = 15,
                Content = new StackLayout
                {
                    Spacing = 15,
                    Children = {
                            titleLabel,
                            new BoxView
                            {
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Color = Color.FromHex("e2e2e2"),
                                HeightRequest = 1,
                            },
                            dateLabel,
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    numberLabel,
                                    acceptLabel,
                                    limitLabel,
                                }
                            },
                            addressLabel,
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    siteImage,
                                    urlLabel,
                                }
                            },
                            new BoxView
                            {
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Color = Color.FromHex("e2e2e2"),
                                HeightRequest = 1,
                            },
                            contentLabel,
                    },
                },
            };
        }
    }
}
