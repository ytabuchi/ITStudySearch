﻿using System;
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

            #region 右側
            var titleLabel = new Label
            {
                TextColor = Color.FromHex("554575"),
                FontSize = 20,
            };
            titleLabel.SetBinding(Label.TextProperty, "Title");


            var timeLabel = new Label
            {
                TextColor = Color.FromHex("999999"),
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalTextAlignment = TextAlignment.End
            };
            timeLabel.SetBinding(Label.TextProperty,
                new Binding("Start_at", stringFormat: "時間： {0:HH:mm}～"));

            var numberLabel = new Label
            {
                Text = "人数： ",
                TextColor = Color.FromHex("999999"),
                HorizontalOptions = LayoutOptions.End,
                VerticalTextAlignment = TextAlignment.End,
            };
            //numberLabel.SetDynamicResource(VisualElement.StyleProperty, "SubTitleLabel");

            var acceptLabel = new Label
            {
                FontSize = 20,
                TextColor = Color.FromHex("aa3333"),
                HorizontalOptions = LayoutOptions.End,
                VerticalTextAlignment = TextAlignment.End,
            };
            acceptLabel.SetBinding(Label.TextProperty,
                new Binding("Accepted", stringFormat: "{0} "));
            var limitLabel = new Label
            {
                TextColor = Color.FromHex("999999"),
                HorizontalOptions = LayoutOptions.End,
                VerticalTextAlignment = TextAlignment.End,
            };
            limitLabel.SetBinding(Label.TextProperty, "Limit", stringFormat: " / {0}");

            //var addressLabel = new Label
            //{
            //    Style = Application.Current.Resources["SubColoredLabel"] as Style,
            //    LineBreakMode = LineBreakMode.TailTruncation,
            //};
            //addressLabel.SetBinding(Label.TextProperty, "Address");

            var contentLabel = new Label { };
            //contentLabel.SetBinding(Label.TextProperty,
            //    new Binding("description", converter: new HtmlToPlainConverter(), converterParameter: "100"));
            contentLabel.SetBinding(Label.TextProperty, "Overview");

            var rightStack = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
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
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    timeLabel,
                                    numberLabel,
                                    acceptLabel,
                                    limitLabel,
                                }
                            },
                            //addressLabel,
                            new BoxView
                            {
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                Color = Color.FromHex("e2e2e2"),
                                HeightRequest = 1,
                            },
                            contentLabel,
                        },
            };
            #endregion


            #region 左側

            #region 日付Box
            // b3a0db
            var dMonth = new Label
            {
                TextColor = Color.FromHex("FFFFFF"),
                BackgroundColor = Color.FromHex("C0CA33"), // ColorAccent
                FontSize = 14,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            dMonth.SetBinding(Label.TextProperty,
                new Binding("Start_at", stringFormat: "{0:MM}"));
            var dDay = new Label
            {
                TextColor = Color.FromHex("555555"),
                BackgroundColor = Color.FromHex("ececec"),
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            dDay.SetBinding(Label.TextProperty,
                new Binding("Start_at", stringFormat: "{0:dd}"));
            var dWeekDay = new Label
            {
                TextColor = Color.FromHex("555555"),
                BackgroundColor = Color.FromHex("E3E3E3"),
                FontSize = 12,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
            };
            dWeekDay.SetBinding(Label.TextProperty,
                new Binding("Start_at", stringFormat: "（{0:ddd}）"));

            var dateGrid = new Grid
            {
                Padding = new Thickness(1, 1, 1, 1),
                RowSpacing = 1,
                ColumnSpacing = 1,
                BackgroundColor = Color.FromHex("DEDEDE"),
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
                //TextColor = Color.FromHex("444"),
                FontSize = 14,
                HorizontalTextAlignment = TextAlignment.Center,
            };
            cityLabel.SetBinding(Label.TextProperty, "City");

            var siteImage = new Image
            {
                WidthRequest = 40,
            };
            siteImage.SetBinding(Image.SourceProperty, "Site");

            #endregion

            var leftStack = new StackLayout
            {
                Spacing = 15,
                Children =
                {
                    dateGrid,
                    cityLabel,
                    siteImage,
                }
            };
            #endregion

            var cell = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = 10,
                Children = {
                    leftStack,
                    rightStack
                }
            };

            this.View = cell;
        }
    }
}
