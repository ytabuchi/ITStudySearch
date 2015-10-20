using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using ITStudySearch.Models;
using Xamarin.Forms;

namespace ITStudySearch.Views
{
    public class NGWordsSettingPageCS : ContentPage
    {
        NGWords ngWords = new NGWords();
        Entry entry;

        public NGWordsSettingPageCS()
        {
            entry = new Entry
            {
                Placeholder = "サンプル,入力方法"
            };

            Padding = 20;
            Title = "NGワード設定";
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = @"
標準 NG ワード
「恋活, 婚活, カップル, コンパ, お見合い, 合コン, 街コン, パーティ, Party, 副業, 起業, グルメ」
に追加する場合は以下に「,」区切りでワードを入力してください。
" },
                    entry,
                    new Button
                    {
                        Text = "クリア",
                        Command = new Command(() => entry.Text = ""),
                    },
                    new Button
                    {
                        Text = "保存しないで閉じる",
                        Command = new Command(async () => await Navigation.PopAsync()),
                    },
                    new Button
                    {
                        Text = "保存して閉じる",
                        Command = new Command(async () =>
                        {
                            ngWords.SetNGWordsSet(entry.Text);
                            await Navigation.PopAsync();
                        }),
                    },
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            entry.Text = ngWords.GetAddedNGWords();
        }
    }
}
