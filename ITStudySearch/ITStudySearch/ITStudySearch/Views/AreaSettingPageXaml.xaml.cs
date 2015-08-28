using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using ITStudySearch.ViewModels;
using System.ComponentModel;

namespace ITStudySearch.Views
{
    public partial class AreaSettingPageXaml : ContentPage
    {
        public AreaSettingPageViewModel vm { get; private set; }

        public AreaSettingPageXaml()
        {
            // json データがあれば読み込み、デシリアライズして vm に設定します。
            var data = DependencyService.Get<ISaveAndLoad>().LoadData("settings.json");
            this.vm = string.IsNullOrEmpty(data) ? new AreaSettingPageViewModel() : JsonConvert.DeserializeObject<AreaSettingPageViewModel>(data);
            this.BindingContext = vm;

            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SaveDataToJson(vm);
#if DEBUG
            System.Diagnostics.Debug.WriteLine("Disappering");
#endif
        }

        /// <summary>
        /// vm のインスタンスを json にシリアライズして保存するメソッドです。
        /// </summary>
        private void SaveDataToJson(AreaSettingPageViewModel vm)
        {
            var json = JsonConvert.SerializeObject(vm);
            DependencyService.Get<ISaveAndLoad>().SaveData("settings.json", json);
        }

        #region 一括設定の Switch を Toggle した時に各地域の全県の vm を変更するメソッド群です。

        private void ToggleAreaTohokuValues(object sender, EventArgs e)
        {
            if (((SwitchCell)sender).On)
            {
                vm.AomoriValue = true;
                vm.IwateValue = true;
                vm.MiyagiValue = true;
                vm.AkitaValue = true;
                vm.YamagataValue = true;
                vm.FukushimaValue = true;
            }
            else
            {
                vm.AomoriValue = false;
                vm.IwateValue = false;
                vm.MiyagiValue = false;
                vm.AkitaValue = false;
                vm.YamagataValue = false;
                vm.FukushimaValue = false;
            }
            this.BindingContext = vm;
        }

        private void ToggleAreaKantoValues(object sender, EventArgs e)
        {
            if (((SwitchCell)sender).On)
            {
                vm.IbarakiValue = true;
                vm.TochigiValue = true;
                vm.GunmaValue = true;
                vm.SaitamaValue = true;
                vm.ChibaValue = true;
                vm.TokyoValue = true;
                vm.KanagawaValue = true;
            }
            else
            {
                vm.IbarakiValue = false;
                vm.TochigiValue = false;
                vm.GunmaValue = false;
                vm.SaitamaValue = false;
                vm.ChibaValue = false;
                vm.TokyoValue = false;
                vm.KanagawaValue = false;
            }
            this.BindingContext = vm;
        }

        private void ToggleAreaChubuValues(object sender, EventArgs e)
        {
            if (((SwitchCell)sender).On)
            {
                vm.NiigataValue = true;
                vm.ToyamaValue = true;
                vm.IshikawaValue = true;
                vm.FukuiValue = true;
                vm.YamanashiValue = true;
                vm.NaganoValue = true;
                vm.GifuValue = true;
                vm.ShizuokaValue = true;
                vm.AichiValue = true;
            }
            else
            {
                vm.NiigataValue = false;
                vm.ToyamaValue = false;
                vm.IshikawaValue = false;
                vm.FukuiValue = false;
                vm.YamanashiValue = false;
                vm.NaganoValue = false;
                vm.GifuValue = false;
                vm.ShizuokaValue = false;
                vm.AichiValue = false;
            }
            this.BindingContext = vm;
        }

        private void ToggleAreaKinkiValues(object sender, EventArgs e)
        {
            if (((SwitchCell)sender).On)
            {
                vm.MieValue = true;
                vm.ShigaValue = true;
                vm.KyotoValue = true;
                vm.OsakaValue = true;
                vm.HyogoValue = true;
                vm.NaraValue = true;
                vm.WakayamaValue = true;
            }
            else
            {
                vm.MieValue = false;
                vm.ShigaValue = false;
                vm.KyotoValue = false;
                vm.OsakaValue = false;
                vm.HyogoValue = false;
                vm.NaraValue = false;
                vm.WakayamaValue = false;
            }
            this.BindingContext = vm;
        }

        private void ToggleAreaChugokuValues(object sender, EventArgs e)
        {
            if (((SwitchCell)sender).On)
            {
                vm.TottoriValue = true;
                vm.ShimaneValue = true;
                vm.OkayamaValue = true;
                vm.HiroshimaValue = true;
                vm.YamaguchiValue = true;
            }
            else
            {
                vm.TottoriValue = false;
                vm.ShimaneValue = false;
                vm.OkayamaValue = false;
                vm.HiroshimaValue = false;
                vm.YamaguchiValue = false;
            }
            this.BindingContext = vm;
        }

        private void ToggleAreaShikokuValues(object sender, EventArgs e)
        {
            if (((SwitchCell)sender).On)
            {
                vm.TokushimaValue = true;
                vm.KagawaValue = true;
                vm.EhimeValue = true;
                vm.KochiValue = true;
            }
            else
            {
                vm.TokushimaValue = false;
                vm.KagawaValue = false;
                vm.EhimeValue = false;
                vm.KochiValue = false;
            }
            this.BindingContext = vm;
        }

        private void ToggleAreaKyushuValues(object sender, EventArgs e)
        {
            if (((SwitchCell)sender).On)
            {
                vm.FukuokaValue = true;
                vm.SagaValue = true;
                vm.NagasakiValue = true;
                vm.KumamotoValue = true;
                vm.OitaValue = true;
                vm.MiyazakiValue = true;
                vm.KagoshimaValue = true;
            }
            else
            {
                vm.FukuokaValue = false;
                vm.SagaValue = false;
                vm.NagasakiValue = false;
                vm.KumamotoValue = false;
                vm.OitaValue = false;
                vm.MiyazakiValue = false;
                vm.KagoshimaValue = false;
            }
            this.BindingContext = vm;
        }

#endregion

    }
}
