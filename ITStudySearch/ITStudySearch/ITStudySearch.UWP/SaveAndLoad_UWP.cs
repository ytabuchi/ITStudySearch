using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ITStudySearch.UWP;
using Windows.Storage;
using System.IO;

[assembly: Dependency(typeof(SaveAndLoad_UWP))]

namespace ITStudySearch.UWP
{
    class SaveAndLoad_UWP : ISaveAndLoad
    {
        public async void SaveData(string filename, string text)
        {
            var local = Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting).AsTask().ConfigureAwait(false); // DeadLock 回避の TIPS
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
            string text = null;
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
            catch (Exception e)
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"Load Error: Message:{e.Message}");
#endif
                return text;
            }
        }
    }
}
