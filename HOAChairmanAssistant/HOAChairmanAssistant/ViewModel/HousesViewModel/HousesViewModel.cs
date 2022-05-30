using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HOAChairmanAssistant.DataLayer.EF;
using HOAChairmanAssistant.Helpers;
using HOAChairmanAssistant.Helpers.GlobalData;
using HOAChairmanAssistant.Helpers.Navigation;
using HOAChairmanAssistant.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace HOAChairmanAssistant.ViewModel
{
    public class HousesViewModel : ViewModelBase
    {
        #region Private Fields

        private HOAChairmanAssistantContext context = new HOAChairmanAssistantContext();
        private IFrameNavigationService _navigationService;
        private ObservableCollection<House> houses = new ObservableCollection<House>();
        private string searchField;
        private string street;
        private string userName;
        private string accountantName;
        private string accountantSurname;
        private bool isVisibleProgressBar;
        //private Thread searchedThread;

        #endregion

        #region Public Fields

        public ObservableCollection<House> Houses
        {
            get { return houses; }
            set
            {
                if (houses == value)
                {
                    return;
                }
                houses = value;
                RaisePropertyChanged();
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = GlobalData.UserName;
            }
        }

        public string Street
        {
            get { return street; }
            set
            {
                if (street == value)
                {
                    return;
                }
                street = context.Addresses.Select(c => c.Street).FirstOrDefault();
                RaisePropertyChanged();
            }
        }

        public string AccountantSurname
        {
            get { return accountantSurname; }
            set
            {
                if (accountantSurname == value)
                {
                    return;
                }
                var user = context.Users.Where(x => x.UserId == GlobalData.UserId).FirstOrDefault();
                accountantSurname = user.Accountant.Surname;
                RaisePropertyChanged();
            }
        }

        public string AccountantName
        {
            get { return accountantName; }
            set
            {
                if (accountantName == value)
                {
                    return;
                }
                var user = context.Users.Where(x => x.UserId == GlobalData.UserId).FirstOrDefault();
                accountantName = user.Accountant.Name;
                RaisePropertyChanged();
            }
        }

        public bool IsVisibleProgressBar
        {
            get
            {
                return isVisibleProgressBar;
            }
            set
            {
                if (isVisibleProgressBar == value)
                {
                    return;
                }
                isVisibleProgressBar = value;
                RaisePropertyChanged();
            }
        }

        public string SearchField
        {
            get
            {
                return searchField;
            }
            set
            {
                if (searchField == value)
                {
                    return;
                }

                searchField = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands

        private RelayCommandParametr loadedCommand;
        public RelayCommandParametr LoadedCommand
        {
            get
            {
                return loadedCommand
                    ?? (loadedCommand = new RelayCommandParametr(
                    obj =>
                    {
                        Houses = new ObservableCollection<House>(context.Houses.Where(u => u.UserId == GlobalData.UserId).ToList());
                    }));
            }
        }

        private RelayCommandParametr _aboutHouseCommand;
        public RelayCommandParametr AboutHouseCommand
        {
            get
            {
                return _aboutHouseCommand
                       ?? (_aboutHouseCommand = new RelayCommandParametr(
                           (obj) =>
                           {
                               _navigationService.NavigateTo("AboutHouse", obj);
                           }));
            }
        }

        private RelayCommand _addHousePageCommand;
        public RelayCommand AddHousePageCommand
        {
            get
            {
                return _addHousePageCommand
                    ?? (_addHousePageCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("AddHousePage");
                    }));
            }
        }

        private RelayCommand addAccountantCommand;
        public RelayCommand AddAccountantCommand
        {
            get
            {
                return addAccountantCommand
                    ?? (addAccountantCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("AddAccountantPage");
                    }));
            }
        }

        private RelayCommand changeAccountantCommand;
        public RelayCommand ChangeAccountantCommand
        {
            get
            {
                return changeAccountantCommand
                    ?? (changeAccountantCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("ChangeAccountantPage");
                    }));
            }
        }

        #endregion

        #region ctor
        public HousesViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}
