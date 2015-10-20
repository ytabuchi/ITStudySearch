using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ITStudySearch.Models
{
    class NGWords
    {
        private readonly string[] _ngArray = { "恋活", "婚活", "パーティ", "party", "副業", "起業", "グルメ", "カップル", "コンパ", "見合い", "合コン", "街コン" };
 
        public HashSet<string> GetNGWordsSet()
        {
            var _ngWords = new HashSet<string>(_ngArray);
            var data = DependencyService.Get<ISaveAndLoad>().LoadData("ngwords.csv");
            if (string.IsNullOrEmpty(data) || data == "null")
            {
                return _ngWords;
            }
            else
            {
                string[] strArray = data.TrimEnd(',', ' ').Split(',');
                foreach (var item in strArray)
                {
                    _ngWords.Add(item);
                }
#if DEBUG
                System.Diagnostics.Debug.WriteLine($"NGワード: {_ngWords.Count} 件(標準12件)");
#endif
                return _ngWords;
            }
        }

        public string GetAddedNGWords()
        {
            var addedData = GetNGWordsSet();
            addedData.ExceptWith(_ngArray);
            return string.Join(",", addedData);
        }

        public void SetNGWordsSet(string str)
        {
            var data = str.TrimEnd(',', ' ');
            DependencyService.Get<ISaveAndLoad>().SaveData("ngwords.csv", data);
        }
    }
}
