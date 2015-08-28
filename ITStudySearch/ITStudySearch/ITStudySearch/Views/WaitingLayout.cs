using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ITStudySearch.Views
{
    public class WaitingLayout : ContentView
    {
        public WaitingLayout()
        {
            IsVisible = false;
            Content = new StackLayout
            {
                Padding = 20,
                Children =
                    {
                        new ActivityIndicator
                        {
                            IsRunning = true,
                            Color = Color.FromHex("554575"),
                        },
                        new Label
                        {
                            Text = "Jsonデータを読み込んでいます...",
                            XAlign = TextAlignment.Center,
                        },
                    }
            };
        }
    }
}
