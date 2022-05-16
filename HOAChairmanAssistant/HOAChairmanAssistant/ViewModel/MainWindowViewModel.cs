using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using HOAChairmanAssistant.Helpers.MessageWindow;
using HOAChairmanAssistant.Helpers.Navigation;
using HOAChairmanAssistant.Model;

namespace HOAChairmanAssistant.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Private Fields
        private User user;
        private bool isAdmin;
        private bool isCook;
        private bool isOpenDialog;
        private IFrameNavigationService _navigationService;
        #endregion

        #region Public Fields

        public User User
        {
            get
            {
                return user;
            }
            set
            {
                if (user == value)
                {
                    return;
                }
                user = value;
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

        public bool IsChairman
        {
            get
            {
                return isAdmin;
            }
            set
            {
                if (isAdmin == value)
                {
                    return;
                }
                isAdmin = value;
                RaisePropertyChanged();
            }
        }

        public bool IsAccountant
        {
            get
            {
                return isCook;
            }
            set
            {
                if (isCook == value)
                {
                    return;
                }
                isCook = value;
                RaisePropertyChanged();
            }
        }

        public string Message { get; internal set; }
        #endregion

        #region Commands
        private RelayCommand _loginpageCommand;
        public RelayCommand LoginPageCommand
        {
            get
            {
                return _loginpageCommand
                    ?? (_loginpageCommand = new RelayCommand(
                    () =>
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(
                        () =>
                        {
                            _navigationService.NavigateTo("Login");
                        });
                        
                    }));
            }
        }

        private RelayCommand _housesCommand;
        public RelayCommand HousesCommand
        {
            get
            {
                return _housesCommand
                    ?? (_housesCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Houses");
                    }));
            }
        }

        private RelayCommand _menuCommand;
        public RelayCommand MenuCommand
        {
            get
            {
                return _menuCommand
                    ?? (_menuCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Menu");
                    }));
            }
        }

        private RelayCommand _reservationCommand;
        public RelayCommand ReservationCommand
        {
            get
            {
                return _reservationCommand
                       ?? (_reservationCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Reservation");
                           }));
            }
        }

        private RelayCommand _feedbackCommand;
        public RelayCommand FeedbackCommand
        {
            get
            {
                return _feedbackCommand
                       ?? (_feedbackCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Feedback");
                           }));
            }
        }

        private RelayCommand _favouritesCommand;
        public RelayCommand FavouritesCommand
        {
            get
            {
                return _favouritesCommand
                       ?? (_favouritesCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Favourites");
                           }));
            }
        }

        private RelayCommand _adminCommand;
        public RelayCommand AdminCommand
        {
            get
            {
                return _adminCommand
                       ?? (_adminCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Admin");
                           }));
            }
        }

        private RelayCommand _cookCommand;
        public RelayCommand CookCommand
        {
            get
            {
                return _cookCommand
                       ?? (_cookCommand = new RelayCommand(
                           () =>
                           {
                               _navigationService.NavigateTo("Cook");
                           }));
            }
        }

        private RelayCommand closeDialodCommand;
        public RelayCommand CloseDialodCommand
        {
            get
            {
                return closeDialodCommand
                    ?? (closeDialodCommand = new RelayCommand(
                    () =>
                    {
                        IsOpenDialog = false;
                    }));
            }
        }

        #endregion

        #region ctor

        public MainWindowViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion
    }
}
