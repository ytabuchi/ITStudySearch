using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using ITStudySearch.WinPhone;

[assembly: Dependency(typeof(SaveAndLoad_WinPhone))]

namespace ITStudySearch.WinPhone
{
    class SaveAndLoad_WinPhone : ISaveAndLoad
    {
        public async void SaveData(string filename, string text)
        {
            var local = Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting).AsTask().ConfigureAwait(false);
            using (StreamWriter writer = new StreamWriter(await file.OpenStreamForWriteAsync()))
            {
                writer.Write(text);
            }
        }

        public string LoadData(string filename)
        {
            var task = LoadDataAsync(filename);
            task.Wait(); // HACK: to keep Interface return types simple (sorry!)
            return task.Result;
        }
        async Task<string> LoadDataAsync(string filename)
        {
            string text = "";
            try
            {
                var local = Windows.Storage.ApplicationData.Current.LocalFolder;
                var file = await local.GetFileAsync(filename).AsTask().ConfigureAwait(false);
                using (StreamReader reader = new StreamReader(await file.OpenStreamForReadAsync()))
                {
                    text = reader.ReadToEnd();
                    return text;
                }
            }
            catch (Exception)
            {
                // ファイルが無い場合は "" を返します
                return text;
            }
        }
    }
}
