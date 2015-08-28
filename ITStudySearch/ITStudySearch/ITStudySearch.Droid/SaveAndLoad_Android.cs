using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using ITStudySearch.Droid;

[assembly: Dependency(typeof(SaveAndLoad_Android))]

namespace ITStudySearch.Droid
{
    class SaveAndLoad_Android : ISaveAndLoad
    {
        public void SaveData(string filename, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            // File.WriteAllText ですべて上書きします。AppendAllText だと追加するようです。
            System.IO.File.WriteAllText(filePath, text);
        }
        public string LoadData(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, filename);
            // ファイルが無ければ null を返します。
            return (System.IO.File.Exists(filePath)) ? System.IO.File.ReadAllText(filePath) : null;
        }
    }
}