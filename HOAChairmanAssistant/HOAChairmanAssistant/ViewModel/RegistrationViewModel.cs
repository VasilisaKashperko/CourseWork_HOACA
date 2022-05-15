﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using HOAChairmanAssistant.DataLayer.EF;
using HOAChairmanAssistant.Helpers;
using HOAChairmanAssistant.Helpers.MessageWindow;
using HOAChairmanAssistant.Helpers.Navigation;
using HOAChairmanAssistant.Model;
using System.Linq;
using System.Threading;

namespace HOAChairmanAssistant.ViewModel
{
    public class RegistrationViewModel : ViewModelBase
    {
        #region Private Fields

        private IFrameNavigationService _navigationService;
        private HOAChairmanAssistantContext context = new HOAChairmanAssistantContext();
        private string surname;
        private string name;
        private string patromynic;
        private string login;
        private string password;
        private string message;
        /// <summary>
        /// Is request to DB is send ?
        /// </summary>
        private bool isVisibleProgressBar;
        private bool isOpenDialog;

        #endregion

        #region Public Fields

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (surname == value)
                {
                    return;
                }
                surname = value;
                RaisePropertyChanged();
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name == value)
                {
                    return;
                }
                name = value;
                RaisePropertyChanged();
            }
        }

        public string Patronymic
        {
            get
            {
                return patromynic;
            }
            set
            {
                if (patromynic == value)
                {
                    return;
                }
                patromynic = value;
                RaisePropertyChanged();
            }
        }

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                if (login == value)
                {
                    return;
                }
                login = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password == value)
                {
                    return;
                }
                password = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Is request to DB is send ?
        /// </summary>
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
        /// <summary>
        /// Is Open Dialog 
        /// </summary>
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
        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand
                    ?? (_loginCommand = new RelayCommand(
                    () =>
                    {

                        _navigationService.NavigateTo("Login");

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

        private RelayCommandParametr _registerCommand;
        public RelayCommandParametr RegisterCommand
        {
            get
            {
                return _registerCommand
                    ?? (_registerCommand = new RelayCommandParametr(
                    (x) =>
                    {
                        IsVisibleProgressBar = true;
                        ThreadPool.QueueUserWorkItem(
                        o =>
                        {
                            if (context.Users.FirstOrDefault(x1 => x1.Login == login) != null)
                            {
                                IsVisibleProgressBar = false; 
                                Message = "Пользователь с таким логином уже зарегистрирован.";
                                IsOpenDialog = true;
                            }
                            // добавление валидации
                            else if (Login != null && Password != null && Name != null && Surname != null)
                            {
                                string hashPass = User.getHash(Password);
                                User user = new User(Surname, Name, Patronymic, Login, hashPass);
                                context.Users.Add(user);
                                context.SaveChanges();
                                DispatcherHelper.CheckBeginInvokeOnUI(
                                    () =>
                                    {
                                        Messenger.Default.Send<OpenWindowMessage>(
                                        new OpenWindowMessage() { Type = WindowType.kMain, Argument = user });
                                    }
                                    );
                            }
                            else
                            {
                                IsVisibleProgressBar = false;
                                Message = "Некорректно введены данные.";
                                IsOpenDialog = true;
                            }
                        }
                    );
                    },
                    (x1) =>
                    Name?.Length > 0 && Login?.Length > 0 && Surname?.Length > 0 && Patronymic?.Length > 0 && Password?.Length > 0));
            }
        }

        #endregion

        #region ctor
        public RegistrationViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        #endregion
    }
}
