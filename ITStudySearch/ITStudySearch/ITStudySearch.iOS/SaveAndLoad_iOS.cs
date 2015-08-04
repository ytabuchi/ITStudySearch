using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Xamarin.Forms;
using ITStudySearch.iOS;

[assembly: Dependency(typeof(SaveAndLoad_iOS))]

namespace ITStudySearch.iOS
{
    public class SaveAndLoad_iOS : ISaveAndLoad
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
        public bool ClearData(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, filename);
            System.IO.File.Delete(filePath);
            // ファイルが削除出来ていれば true, そうでなければ false を返します。
            return (System.IO.File.Exists(filePath)) ? false : true;
        }
    }
}

