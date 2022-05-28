using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using HOAChairmanAssistant.DataLayer.EF;
using HOAChairmanAssistant.Helpers;
using HOAChairmanAssistant.Helpers.Navigation;
using HOAChairmanAssistant.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;


namespace HOAChairmanAssistant.ViewModel
{
    public class AboutHouseViewModel : ViewModelBase
    {
        #region Private Fields
        private IFrameNavigationService _navigationService;
        private HOAChairmanAssistantContext context = new HOAChairmanAssistantContext();
        private ObservableCollection<Porch> porches = new ObservableCollection<Porch>();
        private ObservableCollection<Flat> flats = new ObservableCollection<Flat>();
        private bool isFavorite;
        private User user;
        private House aboutHouse { get; set; }
        private Porch aboutPorch { get; set; }
        private bool isOpenDialog;
        private string message;
        private int porchNumber;
        #endregion

        #region Public Fields
        public House AboutHouse
        {
            get
            {
                return aboutHouse;
            }
            set
            {
                if (aboutHouse == value)
                {
                    return;
                }
                aboutHouse = value;
                RaisePropertyChanged();
            }
        }
        public Porch AboutPorch
        {
            get
            {
                return aboutPorch;
            }
            set
            {
                if (aboutPorch == value)
                {
                    return;
                }
                aboutPorch = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Porch> Porches
        {
            get { return porches; }
            set
            {
                if (porches == value)
                {
                    return;
                }
                porches = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Flat> Flats
        {
            get { return flats; }
            set
            {
                if (flats == value)
                {
                    return;
                }
                flats = value;
                RaisePropertyChanged();
            }
        }

        public int PorchNumber
        {
            get
            {
                return porchNumber;
            }
            set
            {
                if (porchNumber == value)
                {
                    return;
                }
                porchNumber = value;
                RaisePropertyChanged();
            }
        }

        public bool IsFavorite
        {
            get
            {
                return isFavorite;
            }
            set
            {
                if (isFavorite == value)
                {
                    return;
                }
                isFavorite = value;
                RaisePropertyChanged();
            }
        }

        public bool IsOpenDialog
        {
            get
            {
                return isOpenDialog;
            }
            set
            {
                if (isOpenDialog == value)
                {
                    return;
                }
                isOpenDialog = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Message for the dialog  
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                if (message == value)
                {
                    return;
                }
                message = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Commands

        private RelayCommand _housesPageCommand;
        public RelayCommand HousesPageCommand
        {
            get
            {
                return _housesPageCommand
                    ?? (_housesPageCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Houses");
                    }));
            }
        }

        private RelayCommand _loadedpageCommand;
        public RelayCommand LoadedPageCommand
        {
            get
            {
                return _loadedpageCommand
                ?? (_loadedpageCommand = new RelayCommand(
                () =>
                {
                    user = SimpleIoc.Default.GetInstance<MainWindowViewModel>().User;
                    Porches = new ObservableCollection<Porch>(context.Porches.Where(x => x.HouseId == aboutHouse.HouseId).ToList());
                    House house = context.Houses.AsNoTracking().Where(x => x.UserId == user.UserId && x.HouseId == aboutHouse.HouseId).FirstOrDefault();
                }));
            }
        }

        private RelayCommand closeDialogCommand;
        public RelayCommand CloseDialogCommand
        {
            get
            {
                return closeDialogCommand
                    ?? (closeDialogCommand = new RelayCommand(
                    () =>
                    {
                        IsOpenDialog = false;
                    }));
            }
        }

        private RelayCommandParametr _changeDataCommand;
        public RelayCommandParametr ChangeDataCommand
        {
            get
            {
                return _changeDataCommand
                       ?? (_changeDataCommand = new RelayCommandParametr(
                           (obj) =>
                           {
                               AboutPorch = obj as Porch;
                               Porch porch = Porches.Where(x => x.PorchId == aboutPorch.PorchId).FirstOrDefault();
                               Flats = new ObservableCollection<Flat>(context.Flats.Where(x => x.PorchId == porch.PorchId).ToList());
                           }));
            }
        }

        #endregion

        #region ctor
        public AboutHouseViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            AboutHouse = navigationService.Parameter as House;
        }
        #endregion
    }
}
