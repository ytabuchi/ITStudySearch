using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ITStudySearch.ViewModels
{
    public class AreaSettingPageViewModel : INotifyPropertyChanged
    {

        #region 北海道エリア

        private bool _hokkaidoValue;

        public bool HokkaidoValue
        {
            get { return _hokkaidoValue; }
            set
            {
                if (_hokkaidoValue != value)
                {
                    _hokkaidoValue = value;
                    OnPropertyChanged("HokkaidoValue");
                }
            }
        }

        #endregion

        #region 東北エリア

        private bool _aomoriValue;

        public bool AomoriValue
        {
            get { return _aomoriValue; }
            set
            {
                if (_aomoriValue != value)
                {
                    _aomoriValue = value;
                    OnPropertyChanged("AomoriValue");
                }
            }
        }

        private bool _iwateValue;

        public bool IwateValue
        {
            get { return _iwateValue; }
            set
            {
                if (_iwateValue != value)
                {
                    _iwateValue = value;
                    OnPropertyChanged("IwateValue");
                }
            }
        }

        private bool _miyagiValue;

        public bool MiyagiValue
        {
            get { return _miyagiValue; }
            set
            {
                if (_miyagiValue != value)
                {
                    _miyagiValue = value;
                    OnPropertyChanged("MiyagiValue");
                }
            }
        }

        private bool _akitaValue;

        public bool AkitaValue
        {
            get { return _akitaValue; }
            set
            {
                if (_akitaValue != value)
                {
                    _akitaValue = value;
                    OnPropertyChanged("AkitaValue");
                }
            }
        }

        private bool _yamagataValue;

        public bool YamagataValue
        {
            get { return _yamagataValue; }
            set
            {
                if (_yamagataValue != value)
                {
                    _yamagataValue = value;
                    OnPropertyChanged("YamagataValue");
                }
            }
        }

        private bool _fukushimaValue;

        public bool FukushimaValue
        {
            get { return _fukushimaValue; }
            set
            {
                if (_fukushimaValue != value)
                {
                    _fukushimaValue = value;
                    OnPropertyChanged("FukushimaValue");
                }
            }
        }

        //private bool _areaTohokuValue;

        //public bool AreaTohokuValue
        //{
        //    get { return _areaTohokuValue; }
        //    set
        //    {
        //        if (_areaTohokuValue != value)
        //        {
        //            _areaTohokuValue = value;
        //            OnPropertyChanged("AreaTohokuValue");
        //        }
        //        if (_aomoriValue != value)
        //        {
        //            _aomoriValue = value;
        //            OnPropertyChanged("AomoriValue");
        //        }
        //        if (_iwateValue != value)
        //        {
        //            _iwateValue = value;
        //            OnPropertyChanged("IwateValue");
        //        }
        //        if (_miyagiValue != value)
        //        {
        //            _miyagiValue = value;
        //            OnPropertyChanged("MiyagiValue");
        //        }
        //        if (_akitaValue != value)
        //        {
        //            _akitaValue = value;
        //            OnPropertyChanged("AkitaValue");
        //        }
        //        if (_yamagataValue != value)
        //        {
        //            _yamagataValue = value;
        //            OnPropertyChanged("YamagataValue");
        //        }
        //        if (_fukushimaValue != value)
        //        {
        //            _fukushimaValue = value;
        //            OnPropertyChanged("FukushimaValue");
        //        }
        //    }
        //}

        #endregion

        #region 関東エリア

        private bool _ibarakiValue;

        public bool IbarakiValue
        {
            get { return _ibarakiValue; }
            set
            {
                if (_ibarakiValue != value)
                {
                    _ibarakiValue = value;
                    OnPropertyChanged("IbarakiValue");
                }
            }
        }

        private bool _tochigiValue;

        public bool TochigiValue
        {
            get { return _tochigiValue; }
            set
            {
                if (_tochigiValue != value)
                {
                    _tochigiValue = value;
                    OnPropertyChanged("TochigiValue");
                }
            }
        }

        private bool _gunmaValue;

        public bool GunmaValue
        {
            get { return _gunmaValue; }
            set
            {
                if (_gunmaValue != value)
                {
                    _gunmaValue = value;
                    OnPropertyChanged("GunmaValue");
                }
            }
        }

        private bool _saitamaValue;

        public bool SaitamaValue
        {
            get { return _saitamaValue; }
            set
            {
                if (_saitamaValue != value)
                {
                    _saitamaValue = value;
                    OnPropertyChanged("SaitamaValue");
                }
            }
        }

        private bool _chibaValue;

        public bool ChibaValue
        {
            get { return _chibaValue; }
            set
            {
                if (_chibaValue != value)
                {
                    _chibaValue = value;
                    OnPropertyChanged("ChibaValue");
                }
            }
        }

        private bool _tokyoValue = true;

        public bool TokyoValue
        {
            get { return _tokyoValue; }
            set
            {
                if (_tokyoValue != value)
                {
                    _tokyoValue = value;
                    OnPropertyChanged("TokyoValue");
                }
            }
        }

        private bool _kanagawaValue;

        public bool KanagawaValue
        {
            get { return _kanagawaValue; }
            set
            {
                if (_kanagawaValue != value)
                {
                    _kanagawaValue = value;
                    OnPropertyChanged("KanagawaValue");
                }
            }
        }

        //private bool _areaKantoValue;

        //public bool AreaKantoValue
        //{
        //    get { return _areaKantoValue; }
        //    set
        //    {
        //        if (_areaKantoValue != value)
        //        {
        //            _areaKantoValue = value;
        //            OnPropertyChanged("AreaKantoValue");
        //        }
        //        if (_ibarakiValue != value)
        //        {
        //            _ibarakiValue = value;
        //            OnPropertyChanged("IbarakiValue");
        //        }
        //        if (_tochigiValue != value)
        //        {
        //            _tochigiValue = value;
        //            OnPropertyChanged("TochigiValue");
        //        }
        //        if (_gunmaValue != value)
        //        {
        //            _gunmaValue = value;
        //            OnPropertyChanged("GunmaValue");
        //        }
        //        if (_saitamaValue != value)
        //        {
        //            _saitamaValue = value;
        //            OnPropertyChanged("SaitamaValue");
        //        }
        //        if (_chibaValue != value)
        //        {
        //            _chibaValue = value;
        //            OnPropertyChanged("ChibaValue");
        //        }
        //        if (_tokyoValue != value)
        //        {
        //            _tokyoValue = value;
        //            OnPropertyChanged("TokyoValue");
        //        }
        //        if (_kanagawaValue != value)
        //        {
        //            _kanagawaValue = value;
        //            OnPropertyChanged("KanagawaValue");
        //        }
        //    }
        //}

        #endregion

        #region 中部エリア

        private bool _niigataValue;

        public bool NiigataValue
        {
            get { return _niigataValue; }
            set
            {
                if (_niigataValue != value)
                {
                    _niigataValue = value;
                    OnPropertyChanged("NiigataValue");
                }
            }
        }

        private bool _toyamaValue;

        public bool ToyamaValue
        {
            get { return _toyamaValue; }
            set
            {
                if (_toyamaValue != value)
                {
                    _toyamaValue = value;
                    OnPropertyChanged("ToyamaValue");
                }
            }
        }

        private bool _ishikawaValue;

        public bool IshikawaValue
        {
            get { return _ishikawaValue; }
            set
            {
                if (_ishikawaValue != value)
                {
                    _ishikawaValue = value;
                    OnPropertyChanged("IshikawaValue");
                }
            }
        }

        private bool _fukuiValue;

        public bool FukuiValue
        {
            get { return _fukuiValue; }
            set
            {
                if (_fukuiValue != value)
                {
                    _fukuiValue = value;
                    OnPropertyChanged("FukuiValue");
                }
            }
        }

        private bool _yamanashiValue;

        public bool YamanashiValue
        {
            get { return _yamanashiValue; }
            set
            {
                if (_yamanashiValue != value)
                {
                    _yamanashiValue = value;
                    OnPropertyChanged("YamanashiValue");
                }
            }
        }

        private bool _naganoValue;

        public bool NaganoValue
        {
            get { return _naganoValue; }
            set
            {
                if (_naganoValue != value)
                {
                    _naganoValue = value;
                    OnPropertyChanged("NaganoValue");
                }
            }
        }

        private bool _gifuValue;

        public bool GifuValue
        {
            get { return _gifuValue; }
            set
            {
                if (_gifuValue != value)
                {
                    _gifuValue = value;
                    OnPropertyChanged("GifuValue");
                }
            }
        }

        private bool _shizuokaValue;

        public bool ShizuokaValue
        {
            get { return _shizuokaValue; }
            set
            {
                if (_shizuokaValue != value)
                {
                    _shizuokaValue = value;
                    OnPropertyChanged("ShizuokaValue");
                }
            }
        }

        private bool _aichiValue;

        public bool AichiValue
        {
            get { return _aichiValue; }
            set
            {
                if (_aichiValue != value)
                {
                    _aichiValue = value;
                    OnPropertyChanged("AichiValue");
                }
            }
        }

        //private bool _areaChubuValue;

        //public bool AreaChubuValue
        //{
        //    get { return _areaChubuValue; }
        //    set
        //    {
        //        if (_areaChubuValue != value)
        //        {
        //            _areaChubuValue = value;
        //            OnPropertyChanged("AreaChubuValue");
        //        }
        //        if (_niigataValue != value)
        //        {
        //            _niigataValue = value;
        //            OnPropertyChanged("NiigataValue");
        //        }
        //        if (_toyamaValue != value)
        //        {
        //            _toyamaValue = value;
        //            OnPropertyChanged("ToyamaValue");
        //        }
        //        if (_ishikawaValue != value)
        //        {
        //            _ishikawaValue = value;
        //            OnPropertyChanged("IshikawaValue");
        //        }
        //        if (_fukuiValue != value)
        //        {
        //            _fukuiValue = value;
        //            OnPropertyChanged("FukuiValue");
        //        }
        //        if (_yamanashiValue != value)
        //        {
        //            _yamanashiValue = value;
        //            OnPropertyChanged("YamanashiValue");
        //        }
        //        if (_naganoValue != value)
        //        {
        //            _naganoValue = value;
        //            OnPropertyChanged("NaganoValue");
        //        }
        //        if (_gifuValue != value)
        //        {
        //            _gifuValue = value;
        //            OnPropertyChanged("GifuValue");
        //        }
        //        if (_shizuokaValue != value)
        //        {
        //            _shizuokaValue = value;
        //            OnPropertyChanged("ShizuokaValue");
        //        }
        //        if (_aichiValue != value)
        //        {
        //            _aichiValue = value;
        //            OnPropertyChanged("AichiValue");
        //        }
        //    }
        //}

        #endregion

        #region 近畿エリア

        private bool _mieValue;

        public bool MieValue
        {
            get { return _mieValue; }
            set
            {
                if (_mieValue != value)
                {
                    _mieValue = value;
                    OnPropertyChanged("MieValue");
                }
            }
        }

        private bool _shigaValue;

        public bool ShigaValue
        {
            get { return _shigaValue; }
            set
            {
                if (_shigaValue != value)
                {
                    _shigaValue = value;
                    OnPropertyChanged("ShigaValue");
                }
            }
        }

        private bool _kyotoValue;

        public bool KyotoValue
        {
            get { return _kyotoValue; }
            set
            {
                if (_kyotoValue != value)
                {
                    _kyotoValue = value;
                    OnPropertyChanged("KyotoValue");
                }
            }
        }

        private bool _osakaValue;

        public bool OsakaValue
        {
            get { return _osakaValue; }
            set
            {
                if (_osakaValue != value)
                {
                    _osakaValue = value;
                    OnPropertyChanged("OsakaValue");
                }
            }
        }

        private bool _hyogoValue;

        public bool HyogoValue
        {
            get { return _hyogoValue; }
            set
            {
                if (_hyogoValue != value)
                {
                    _hyogoValue = value;
                    OnPropertyChanged("HyogoValue");
                }
            }
        }

        private bool _naraValue;

        public bool NaraValue
        {
            get { return _naraValue; }
            set
            {
                if (_naraValue != value)
                {
                    _naraValue = value;
                    OnPropertyChanged("NaraValue");
                }
            }
        }

        private bool _wakayamaValue;

        public bool WakayamaValue
        {
            get { return _wakayamaValue; }
            set
            {
                if (_wakayamaValue != value)
                {
                    _wakayamaValue = value;
                    OnPropertyChanged("WakayamaValue");
                }
            }
        }

        //private bool _areaKinkiValue;

        //public bool AreaKinkiValue
        //{
        //    get { return _areaKinkiValue; }
        //    set
        //    {
        //        if (_areaKinkiValue != value)
        //        {
        //            _areaKinkiValue = value;
        //            OnPropertyChanged("AreaKinkiValue");
        //        }
        //        if (_mieValue != value)
        //        {
        //            _mieValue = value;
        //            OnPropertyChanged("MieValue");
        //        }
        //        if (_shigaValue != value)
        //        {
        //            _shigaValue = value;
        //            OnPropertyChanged("ShigaValue");
        //        }
        //        if (_kyotoValue != value)
        //        {
        //            _kyotoValue = value;
        //            OnPropertyChanged("KyotoValue");
        //        }
        //        if (_osakaValue != value)
        //        {
        //            _osakaValue = value;
        //            OnPropertyChanged("OsakaValue");
        //        }
        //        if (_hyogoValue != value)
        //        {
        //            _hyogoValue = value;
        //            OnPropertyChanged("HyogoValue");
        //        }
        //        if (_naraValue != value)
        //        {
        //            _naraValue = value;
        //            OnPropertyChanged("NaraValue");
        //        }
        //        if (_wakayamaValue != value)
        //        {
        //            _wakayamaValue = value;
        //            OnPropertyChanged("WakayamaValue");
        //        }
        //    }
        //}

        #endregion

        #region 中国エリア

        private bool _tottoriValue;

        public bool TottoriValue
        {
            get { return _tottoriValue; }
            set
            {
                if (_tottoriValue != value)
                {
                    _tottoriValue = value;
                    OnPropertyChanged("TottoriValue");
                }
            }
        }

        private bool _shimaneValue;

        public bool ShimaneValue
        {
            get { return _shimaneValue; }
            set
            {
                if (_shimaneValue != value)
                {
                    _shimaneValue = value;
                    OnPropertyChanged("ShimaneValue");
                }
            }
        }

        private bool _okayamaValue;

        public bool OkayamaValue
        {
            get { return _okayamaValue; }
            set
            {
                if (_okayamaValue != value)
                {
                    _okayamaValue = value;
                    OnPropertyChanged("OkayamaValue");
                }
            }
        }

        private bool _hiroshimaValue;

        public bool HiroshimaValue
        {
            get { return _hiroshimaValue; }
            set
            {
                if (_hiroshimaValue != value)
                {
                    _hiroshimaValue = value;
                    OnPropertyChanged("HiroshimaValue");
                }
            }
        }

        private bool _yamaguchiValue;

        public bool YamaguchiValue
        {
            get { return _yamaguchiValue; }
            set
            {
                if (_yamaguchiValue != value)
                {
                    _yamaguchiValue = value;
                    OnPropertyChanged("YamaguchiValue");
                }
            }
        }

        //private bool _areaChugokuValue;

        //public bool AreaChugokuValue
        //{
        //    get { return _areaChugokuValue; }
        //    set
        //    {
        //        if (_areaChugokuValue != value)
        //        {
        //            _areaChugokuValue = value;
        //            OnPropertyChanged("AreaChugokuValue");
        //        }
        //        if (_tottoriValue != value)
        //        {
        //            _tottoriValue = value;
        //            OnPropertyChanged("TottoriValue");
        //        }
        //        if (_shimaneValue != value)
        //        {
        //            _shimaneValue = value;
        //            OnPropertyChanged("ShimaneValue");
        //        }
        //        if (_okayamaValue != value)
        //        {
        //            _okayamaValue = value;
        //            OnPropertyChanged("OkayamaValue");
        //        }
        //        if (_hiroshimaValue != value)
        //        {
        //            _hiroshimaValue = value;
        //            OnPropertyChanged("HiroshimaValue");
        //        }
        //        if (_yamaguchiValue != value)
        //        {
        //            _yamaguchiValue = value;
        //            OnPropertyChanged("YamaguchiValue");
        //        }
        //    }
        //}

        #endregion

        #region 四国エリア

        private bool _tokushimaValue;

        public bool TokushimaValue
        {
            get { return _tokushimaValue; }
            set
            {
                if (_tokushimaValue != value)
                {
                    _tokushimaValue = value;
                    OnPropertyChanged("TokushimaValue");
                }
            }
        }

        private bool _kagawaValue;

        public bool KagawaValue
        {
            get { return _kagawaValue; }
            set
            {
                if (_kagawaValue != value)
                {
                    _kagawaValue = value;
                    OnPropertyChanged("KagawaValue");
                }
            }
        }

        private bool _ehimeValue;

        public bool EhimeValue
        {
            get { return _ehimeValue; }
            set
            {
                if (_ehimeValue != value)
                {
                    _ehimeValue = value;
                    OnPropertyChanged("EhimeValue");
                }
            }
        }

        private bool _kochiValue;

        public bool KochiValue
        {
            get { return _kochiValue; }
            set
            {
                if (_kochiValue != value)
                {
                    _kochiValue = value;
                    OnPropertyChanged("KochiValue");
                }
            }
        }

        //private bool _areaShikokuValue;

        //public bool AreaShikokuValue
        //{
        //    get { return _areaShikokuValue; }
        //    set
        //    {
        //        if (_areaShikokuValue != value)
        //        {
        //            _areaShikokuValue = value;
        //            OnPropertyChanged("AreaShikokuValue");
        //        }
        //        if (_tokushimaValue != value)
        //        {
        //            _tokushimaValue = value;
        //            OnPropertyChanged("TokushimaValue");
        //        }
        //        if (_kagawaValue != value)
        //        {
        //            _kagawaValue = value;
        //            OnPropertyChanged("KagawaValue");
        //        }
        //        if (_ehimeValue != value)
        //        {
        //            _ehimeValue = value;
        //            OnPropertyChanged("EhimeValue");
        //        }
        //        if (_kochiValue != value)
        //        {
        //            _kochiValue = value;
        //            OnPropertyChanged("KochiValue");
        //        }
        //    }
        //}

        #endregion

        #region 九州エリア

        private bool _fukuokaValue;

        public bool FukuokaValue
        {
            get { return _fukuokaValue; }
            set
            {
                if (_fukuokaValue != value)
                {
                    _fukuokaValue = value;
                    OnPropertyChanged("FukuokaValue");
                }
            }
        }

        private bool _sagaValue;

        public bool SagaValue
        {
            get { return _sagaValue; }
            set
            {
                if (_sagaValue != value)
                {
                    _sagaValue = value;
                    OnPropertyChanged("SagaValue");
                }
            }
        }

        private bool _nagasakiValue;

        public bool NagasakiValue
        {
            get { return _nagasakiValue; }
            set
            {
                if (_nagasakiValue != value)
                {
                    _nagasakiValue = value;
                    OnPropertyChanged("NagasakiValue");
                }
            }
        }

        private bool _kumamotoValue;

        public bool KumamotoValue
        {
            get { return _kumamotoValue; }
            set
            {
                if (_kumamotoValue != value)
                {
                    _kumamotoValue = value;
                    OnPropertyChanged("KumamotoValue");
                }
            }
        }

        private bool _oitaValue;

        public bool OitaValue
        {
            get { return _oitaValue; }
            set
            {
                if (_oitaValue != value)
                {
                    _oitaValue = value;
                    OnPropertyChanged("OitaValue");
                }
            }
        }

        private bool _miyazakiValue;

        public bool MiyazakiValue
        {
            get { return _miyazakiValue; }
            set
            {
                if (_miyazakiValue != value)
                {
                    _miyazakiValue = value;
                    OnPropertyChanged("MiyazakiValue");
                }
            }
        }

        private bool _kagoshimaValue;

        public bool KagoshimaValue
        {
            get { return _kagoshimaValue; }
            set
            {
                if (_kagoshimaValue != value)
                {
                    _kagoshimaValue = value;
                    OnPropertyChanged("KagoshimaValue");
                }
            }
        }

        //private bool _areaKyushuValue;

        //public bool AreaKyushuValue
        //{
        //    get { return _areaKyushuValue; }
        //    set
        //    {
        //        if (_areaKyushuValue != value)
        //        {
        //            _areaKyushuValue = value;
        //            OnPropertyChanged("AreaKyushuValue");
        //        }
        //        if (_fukuokaValue != value)
        //        {
        //            _fukuokaValue = value;
        //            OnPropertyChanged("FukuokaValue");
        //        }
        //        if (_sagaValue != value)
        //        {
        //            _sagaValue = value;
        //            OnPropertyChanged("SagaValue");
        //        }
        //        if (_nagasakiValue != value)
        //        {
        //            _nagasakiValue = value;
        //            OnPropertyChanged("NagasakiValue");
        //        }
        //        if (_kumamotoValue != value)
        //        {
        //            _kumamotoValue = value;
        //            OnPropertyChanged("KumamotoValue");
        //        }
        //        if (_oitaValue != value)
        //        {
        //            _oitaValue = value;
        //            OnPropertyChanged("OitaValue");
        //        }
        //        if (_miyazakiValue != value)
        //        {
        //            _miyazakiValue = value;
        //            OnPropertyChanged("MiyazakiValue");
        //        }
        //        if (_kagoshimaValue != value)
        //        {
        //            _kagoshimaValue = value;
        //            OnPropertyChanged("KagoshimaValue");
        //        }
        //    }
        //}

        #endregion

        #region 沖縄エリア

        private bool _okinawaValue;

        public bool OkinawaValue
        {
            get { return _okinawaValue; }
            set
            {
                if (_okinawaValue != value)
                {
                    _okinawaValue = value;
                    OnPropertyChanged("OkinawaValue");
                }
            }
        }

        #endregion

        //private bool _allValue;

        //public bool AllValue
        //{
        //    get { return _allValue; }
        //    set
        //    {
        //        if (_allValue != value)
        //        {
        //            _allValue = value;
        //            OnPropertyChanged("AllValue");
        //        }
        //        if (_hokkaidoValue != value)
        //        {
        //            _hokkaidoValue = value;
        //            OnPropertyChanged("HokkaidoValue");
        //        }
        //        if (_aomoriValue != value)
        //        {
        //            _aomoriValue = value;
        //            OnPropertyChanged("AomoriValue");
        //        }
        //        if (_iwateValue != value)
        //        {
        //            _iwateValue = value;
        //            OnPropertyChanged("IwateValue");
        //        }
        //        if (_miyagiValue != value)
        //        {
        //            _miyagiValue = value;
        //            OnPropertyChanged("MiyagiValue");
        //        }
        //        if (_akitaValue != value)
        //        {
        //            _akitaValue = value;
        //            OnPropertyChanged("AkitaValue");
        //        }
        //        if (_yamagataValue != value)
        //        {
        //            _yamagataValue = value;
        //            OnPropertyChanged("YamagataValue");
        //        }
        //        if (_fukushimaValue != value)
        //        {
        //            _fukushimaValue = value;
        //            OnPropertyChanged("FukushimaValue");
        //        }
        //        if (_ibarakiValue != value)
        //        {
        //            _ibarakiValue = value;
        //            OnPropertyChanged("IbarakiValue");
        //        }
        //        if (_tochigiValue != value)
        //        {
        //            _tochigiValue = value;
        //            OnPropertyChanged("TochigiValue");
        //        }
        //        if (_gunmaValue != value)
        //        {
        //            _gunmaValue = value;
        //            OnPropertyChanged("GunmaValue");
        //        }
        //        if (_saitamaValue != value)
        //        {
        //            _saitamaValue = value;
        //            OnPropertyChanged("SaitamaValue");
        //        }
        //        if (_chibaValue != value)
        //        {
        //            _chibaValue = value;
        //            OnPropertyChanged("ChibaValue");
        //        }
        //        if (_tokyoValue != value)
        //        {
        //            _tokyoValue = value;
        //            OnPropertyChanged("TokyoValue");
        //        }
        //        if (_kanagawaValue != value)
        //        {
        //            _kanagawaValue = value;
        //            OnPropertyChanged("KanagawaValue");
        //        }
        //        if (_niigataValue != value)
        //        {
        //            _niigataValue = value;
        //            OnPropertyChanged("NiigataValue");
        //        }
        //        if (_toyamaValue != value)
        //        {
        //            _toyamaValue = value;
        //            OnPropertyChanged("ToyamaValue");
        //        }
        //        if (_ishikawaValue != value)
        //        {
        //            _ishikawaValue = value;
        //            OnPropertyChanged("IshikawaValue");
        //        }
        //        if (_fukuiValue != value)
        //        {
        //            _fukuiValue = value;
        //            OnPropertyChanged("FukuiValue");
        //        }
        //        if (_yamanashiValue != value)
        //        {
        //            _yamanashiValue = value;
        //            OnPropertyChanged("YamanashiValue");
        //        }
        //        if (_naganoValue != value)
        //        {
        //            _naganoValue = value;
        //            OnPropertyChanged("NaganoValue");
        //        }
        //        if (_gifuValue != value)
        //        {
        //            _gifuValue = value;
        //            OnPropertyChanged("GifuValue");
        //        }
        //        if (_shizuokaValue != value)
        //        {
        //            _shizuokaValue = value;
        //            OnPropertyChanged("ShizuokaValue");
        //        }
        //        if (_aichiValue != value)
        //        {
        //            _aichiValue = value;
        //            OnPropertyChanged("AichiValue");
        //        }
        //        if (_mieValue != value)
        //        {
        //            _mieValue = value;
        //            OnPropertyChanged("MieValue");
        //        }
        //        if (_shigaValue != value)
        //        {
        //            _shigaValue = value;
        //            OnPropertyChanged("ShigaValue");
        //        }
        //        if (_kyotoValue != value)
        //        {
        //            _kyotoValue = value;
        //            OnPropertyChanged("KyotoValue");
        //        }
        //        if (_osakaValue != value)
        //        {
        //            _osakaValue = value;
        //            OnPropertyChanged("OsakaValue");
        //        }
        //        if (_hyogoValue != value)
        //        {
        //            _hyogoValue = value;
        //            OnPropertyChanged("HyogoValue");
        //        }
        //        if (_naraValue != value)
        //        {
        //            _naraValue = value;
        //            OnPropertyChanged("NaraValue");
        //        }
        //        if (_wakayamaValue != value)
        //        {
        //            _wakayamaValue = value;
        //            OnPropertyChanged("WakayamaValue");
        //        }
        //        if (_tottoriValue != value)
        //        {
        //            _tottoriValue = value;
        //            OnPropertyChanged("TottoriValue");
        //        }
        //        if (_shimaneValue != value)
        //        {
        //            _shimaneValue = value;
        //            OnPropertyChanged("ShimaneValue");
        //        }
        //        if (_okayamaValue != value)
        //        {
        //            _okayamaValue = value;
        //            OnPropertyChanged("OkayamaValue");
        //        }
        //        if (_hiroshimaValue != value)
        //        {
        //            _hiroshimaValue = value;
        //            OnPropertyChanged("HiroshimaValue");
        //        }
        //        if (_yamaguchiValue != value)
        //        {
        //            _yamaguchiValue = value;
        //            OnPropertyChanged("YamaguchiValue");
        //        }
        //        if (_tokushimaValue != value)
        //        {
        //            _tokushimaValue = value;
        //            OnPropertyChanged("TokushimaValue");
        //        }
        //        if (_kagawaValue != value)
        //        {
        //            _kagawaValue = value;
        //            OnPropertyChanged("KagawaValue");
        //        }
        //        if (_ehimeValue != value)
        //        {
        //            _ehimeValue = value;
        //            OnPropertyChanged("EhimeValue");
        //        }
        //        if (_kochiValue != value)
        //        {
        //            _kochiValue = value;
        //            OnPropertyChanged("KochiValue");
        //        }
        //        if (_fukuokaValue != value)
        //        {
        //            _fukuokaValue = value;
        //            OnPropertyChanged("FukuokaValue");
        //        }
        //        if (_sagaValue != value)
        //        {
        //            _sagaValue = value;
        //            OnPropertyChanged("SagaValue");
        //        }
        //        if (_nagasakiValue != value)
        //        {
        //            _nagasakiValue = value;
        //            OnPropertyChanged("NagasakiValue");
        //        }
        //        if (_kumamotoValue != value)
        //        {
        //            _kumamotoValue = value;
        //            OnPropertyChanged("KumamotoValue");
        //        }
        //        if (_oitaValue != value)
        //        {
        //            _oitaValue = value;
        //            OnPropertyChanged("OitaValue");
        //        }
        //        if (_miyazakiValue != value)
        //        {
        //            _miyazakiValue = value;
        //            OnPropertyChanged("MiyazakiValue");
        //        }
        //        if (_kagoshimaValue != value)
        //        {
        //            _kagoshimaValue = value;
        //            OnPropertyChanged("KagoshimaValue");
        //        }
        //        if (_okinawaValue != value)
        //        {
        //            _okinawaValue = value;
        //            OnPropertyChanged("OkinawaValue");
        //        }
        //    }
        //}


        private bool _otherValue;

        public bool OtherValue
        {
            get { return _otherValue; }
            set
            {
                if (_otherValue != value)
                {
                    _otherValue = value;
                    OnPropertyChanged("OtherValue");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));


            }
        }

    }
}
