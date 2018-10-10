using GalaSoft.MvvmLight;
using SimpleWifi;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;
using WiFiBF.Service.Interface;
using System.Collections.Generic;

namespace WiFiBF.ViewModel
{
    /// <summary>
    /// MainWindow class
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IWifiService _wifiService;
        private int _attackProgressPercentage;
        private string _dictionaryFileName;
        private bool _isAttackStarted;
        private int _numOfWords;
        private ObservableCollection<AccessPoint> _accessPoints;
        private AccessPoint _selectedAccessPoint;

        // wifi list
        // selected wifi
        private string _wordListText;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewModel(IWifiService wifiService)
        {
            _wifiService = wifiService;
            Task.Factory.StartNew(() => UpdateAvailableAccessPoints());
        }

        /// <summary>
        /// Attack progress percentage
        /// Use case: Progress bar
        /// </summary>
        public int AttackProgressPercentage
        {
            get { return _attackProgressPercentage; }
            set { Set(ref _attackProgressPercentage, value); }
        }

        /// <summary>
        /// Dictionary file name
        /// </summary>
        public string DictionaryFileName
        {
            get { return _dictionaryFileName; }
            set { Set(ref _dictionaryFileName, value); }
        }

        /// <summary>
        /// Is wifi attack started
        /// </summary>
        public bool IsAttackStarted
        {
            get { return _isAttackStarted; }
            set { Set(ref _isAttackStarted, value); }
        }

        /// <summary>
        /// Num of words to combine from word list during attack
        /// </summary>
        public int NumOfWords
        {
            get { return _numOfWords; }
            set { Set(ref _numOfWords, value); }
        }

        /// <summary>
        /// Word list textbox content
        /// </summary>
        public string WordListText
        {
            get { return _wordListText; }
            set { Set(ref _wordListText, value); }
        }

        public ObservableCollection<AccessPoint> AccessPoints
        {
            get { return _accessPoints; }
            set { Set(ref _accessPoints, value); }
        }

        public AccessPoint SelectedAccessPoint
        {
            get { return _selectedAccessPoint; }
            set { Set(ref _selectedAccessPoint, value); }
        }

        private async Task UpdateAvailableAccessPoints()
        {
            while(true)
            {
                GetAvailableAccessPoints();
                // TO DO: get delay from app.config
                await Task.Delay(5000);
            }
        }

        private void GetAvailableAccessPoints()
        {
            var newAccessPoints = _wifiService.GetAvailableAccessPoints();
            if (SelectedAccessPoint != null)
            {
                SelectedAccessPoint = newAccessPoints.Where(x => x.Name.Equals(SelectedAccessPoint.Name)).ToList().First();
            }
            AccessPoints = new ObservableCollection<AccessPoint>(newAccessPoints);
        }

    }
}