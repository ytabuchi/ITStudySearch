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
                TextColor = Color.FromHex("554575"),
                FontSize = 20
            };
            titleLabel.SetBinding(Label.TextProperty, "Title");

            var dateLabel = new Label
            {
                TextColor = Color.FromHex("999999"),
            };
            dateLabel.SetBinding(Label.TextProperty,
                new Binding("Start_at", stringFormat: "日時： {0:yyyy/M/d HH:mm} ～"));
            var endLabel = new Label
            {
                TextColor = Color.FromHex("999999"),
            };
            endLabel.SetBinding(Label.TextProperty,
                new Binding("End_at", stringFormat: "{0:HH:mm}"));
            var numberLabel = new Label
            {
                Text = "人数： ",
                TextColor = Color.FromHex("999999"),
                VerticalTextAlignment = TextAlignment.End,
            };
            var acceptLabel = new Label
            {
                FontSize = 20,
                TextColor = Color.FromHex("aa3333"),
                VerticalTextAlignment = TextAlignment.End,
            };
            acceptLabel.SetBinding(Label.TextProperty,
                new Binding("Accepted", stringFormat: "{0} "));
            var limitLabel = new Label
            {
                TextColor = Color.FromHex("999999"),
                VerticalTextAlignment = TextAlignment.End,
            };
            limitLabel.SetBinding(Label.TextProperty, "Limit", stringFormat: " / {0}");
            var addressLabel = new Label
            {
                TextColor = Color.FromHex("999999"),
            };
            addressLabel.SetBinding(Label.TextProperty, "Address", stringFormat: "場所： {0}");
            var organizerLabel = new Label
            {
                TextColor = Color.FromHex("999999"),
            };
            organizerLabel.SetBinding(Label.TextProperty, "Organizer", stringFormat: "主催者： {0}");
            var siteImage = new Image
            {
                WidthRequest = 40,
            };
            siteImage.SetBinding(Image.SourceProperty, "Site");
            var urlLabel = new Label
            {
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = Color.FromHex("3152C6"),
            };
            urlLabel.SetBinding(Label.TextProperty, "Event_uri");
            urlLabel.GestureRecognizers.Add(tap);

            var contentLabel = new Label { };
            contentLabel.SetBinding(Label.TextProperty,
                new Binding("Description", converter: new HtmlToPlainConverter()));

            Title = items.Title;
            Content = new ScrollView
            {
                Padding = 15,
                Content = new StackLayout
                {
                    Spacing = 10,
                    Children = {
                            titleLabel,
                            new BoxView
                            {
                                Color = Color.FromHex("e2e2e2"),
                                HeightRequest = 1,
                            },
                            new StackLayout {
                                Orientation = StackOrientation.Horizontal,
                                Children = {
                                    dateLabel,
                                    endLabel,
                                },
                            },
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
                            organizerLabel,
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
