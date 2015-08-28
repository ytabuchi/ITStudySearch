using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using ITStudySearch.Models;
using ITStudySearch.Views;

namespace ITStudySearch
{
    public class App : Application
    {
        public App()
        {
            #region // スタイル設定
            Application.Current.Resources = new ResourceDictionary();

            var appTitleLabel = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.TextColorProperty, Value = Color.FromHex("554575") }, // 薄紫
                    new Setter { Property = Label.FontSizeProperty, Value = Device.GetNamedSize(NamedSize.Large, typeof(Label)) },
                }
            };
            Application.Current.Resources.Add("TitleLabel", appTitleLabel);

            var SubColoredLabel = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter { Property = Label.TextColorProperty, Value = Color.FromHex("999") }
                }
            };
            Application.Current.Resources.Add("SubColoredLabel", SubColoredLabel);
            #endregion
            //9783bf
            var nav = new NavigationPage(new StartPageCS());
            nav.BarBackgroundColor = Color.FromHex("8c70c1");
            if (Device.OS == TargetPlatform.Windows)
            {
                nav.BarTextColor = Color.Black;
            }
            else
            {
                nav.BarTextColor = Color.White;
            }
            MainPage = nav;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
