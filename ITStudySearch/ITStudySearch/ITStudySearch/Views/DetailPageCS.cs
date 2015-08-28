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
                Style = Application.Current.Resources["TitleLabel"] as Style,
            };
            titleLabel.SetBinding(Label.TextProperty, "Title");

            var dateLabel = new Label
            {
                Style = Application.Current.Resources["SubColoredLabel"] as Style,
            };
            dateLabel.SetBinding(Label.TextProperty,
                new Binding("Start_at", stringFormat: "日時： {0:yyyy/M/d HH:mm} ～"));
            var numberLabel = new Label
            {
                Text = "人数： ",
                Style = Application.Current.Resources["SubColoredLabel"] as Style,
                YAlign = TextAlignment.End,
            };
            var acceptLabel = new Label
            {
                FontSize = 20,
                TextColor = Color.FromHex("aa3333"),
                YAlign = TextAlignment.End,
            };
            acceptLabel.SetBinding(Label.TextProperty,
                new Binding("Accepted", stringFormat: "{0} "));
            var limitLabel = new Label
            {
                Style = Application.Current.Resources["SubColoredLabel"] as Style,
                YAlign = TextAlignment.End,
            };
            limitLabel.SetBinding(Label.TextProperty, "Limit", stringFormat: " / {0}");
            var addressLabel = new Label
            {
                Style = Application.Current.Resources["SubColoredLabel"] as Style,
                LineBreakMode = LineBreakMode.TailTruncation,
            };
            addressLabel.SetBinding(Label.TextProperty, "Address", stringFormat: "場所： {0}");
            var organizerLabel = new Label
            {
                Style = Application.Current.Resources["SubColoredLabel"] as Style,
            };
            organizerLabel.SetBinding(Label.TextProperty, "Organizer", stringFormat: "主催者： {0}");
            var siteImage = new Image
            {
                WidthRequest = 40,
            };
            siteImage.SetBinding(Image.SourceProperty, "Site");
            var urlLabel = new Label
            {
                FontSize = 20,
                LineBreakMode = LineBreakMode.TailTruncation,
                TextColor = Color.FromHex("425fc9"),
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
                    Spacing = 15,
                    Children = {
                            titleLabel,
                            new BoxView
                            {
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
