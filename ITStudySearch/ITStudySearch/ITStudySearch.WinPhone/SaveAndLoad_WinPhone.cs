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
        public string LoadData(string filename)
        {
            var task = LoadDataAsync(filename);
            task.Wait(); // HACK: to keep Interface return types simple (sorry!)
            return task.Result;
        }
        async Task<string> LoadDataAsync(string filename)
        {
            var local = Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                var file = await local.GetItemAsync(filename);
                using (StreamReader streamReader = new StreamReader(file.Path))
                {
                    var text = streamReader.ReadToEnd();
                    return text;
                }
            }
            catch (FileNotFoundException e)
            {
                return "";
            }


            //if (local != null)
            //{
            //    var file = await local.GetItemAsync(filename);
            //    using (StreamReader streamReader = new StreamReader(file.Path))
            //    {
            //        var text = streamReader.ReadToEnd();
            //        return text;
            //    }
            //}
            //return "";
        }
        public async void SaveData(string filename, string text)
        {
            var local = Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            using (StreamWriter writer = new StreamWriter(await file.OpenStreamForWriteAsync()))
            {
                writer.Write(text);
            }
        }

        public bool ClearData(string filename)
        {
            var task = ClearDataAsync(filename);
            task.Wait(); // HACK: to keep Interface return types simple (sorry!)
            return task.Result;
        }

        public async Task<bool> ClearDataAsync(string filename)
        {
            var local = Windows.Storage.ApplicationData.Current.LocalFolder;
            await local.DeleteAsync();

            // ファイルが削除されているか？をGetFileAsyncがFileNotFoundExceptionを返すか？でチェックするのもダサいですよね。。
            try
            {
                var file = await local.GetFileAsync(filename);
            }
            catch (FileNotFoundException)
            {
                return true;
            }
            return false;
        }
    }
}
