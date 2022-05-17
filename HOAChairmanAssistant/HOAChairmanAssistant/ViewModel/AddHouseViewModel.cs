﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Threading;
using System.Drawing;
using GalaSoft.MvvmLight.Command;
using HOAChairmanAssistant.Helpers.Navigation;
using HOAChairmanAssistant.DataLayer.EF;
using HOAChairmanAssistant.Helpers;
using HOAChairmanAssistant.Model;
using GalaSoft.MvvmLight.Ioc;

namespace HOAChairmanAssistant.ViewModel
{
    class AddHouseViewModel : ViewModelBase
    {
        #region Private Fields 

        private IFrameNavigationService _navigationService;
        private HOAChairmanAssistantContext context = new HOAChairmanAssistantContext();
        private string country;
        private string city;
        private string district;
        private string street;
        private int houseNumber;
        private int housingNumber;
        private int numberOfFlats;
        private int numberOfPorches;
        private bool isVisibleProgressBar;
        private bool isOpenDialog;
        private string message;

        #endregion

        #region Public Fields

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if (country == value)
                {
                    return;
                }

                country = value;
                RaisePropertyChanged();
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (city == value)
                {
                    return;
                }

                city = value;
                RaisePropertyChanged();
            }
        }

        public string District
        {
            get
            {
                return district;
            }
            set
            {
                if (district == value)
                {
                    return;
                }
                district = value;
                RaisePropertyChanged();
            }
        }

        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                if (street == value)
                {
                    return;
                }
                street = value;
                RaisePropertyChanged();
            }
        }

        public int HouseNumber
        {
            get
            {
                return houseNumber;
            }
            set
            {
                if (houseNumber == value)
                {
                    return;
                }
                houseNumber = value;
                RaisePropertyChanged();
            }
        }

        public int HousingNumber
        {
            get
            {
                return housingNumber;
            }
            set
            {
                if (housingNumber == value)
                {
                    return;
                }
                housingNumber = value;
                RaisePropertyChanged();
            }
        }

        public int NumberOfFlats
        {
            get
            {
                return numberOfFlats;
            }
            set
            {
                if (numberOfFlats == value)
                {
                    return;
                }
                numberOfFlats = value;
                RaisePropertyChanged();
            }
        }

        public int NumberOfPorches
        {
            get
            {
                return numberOfPorches;
            }
            set
            {
                if (numberOfPorches == value)
                {
                    return;
                }
                numberOfPorches = value;
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
        #endregion

        #region Commands

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

        private RelayCommandParametr addHouseCommand;
        public RelayCommandParametr AddHouseCommand
        {
            get
            {
                return addHouseCommand
                    ?? (addHouseCommand = new RelayCommandParametr(
                    (obj) =>
                    {
                        if (!String.IsNullOrWhiteSpace(Country) && !String.IsNullOrWhiteSpace(City))
                        {
                            IsVisibleProgressBar = true;
                            ThreadPool.QueueUserWorkItem(
                            (o) =>
                            {
                                var user = SimpleIoc.Default.GetInstance<MainWindowViewModel>().User;
                                Address address = new Address(Country, City, District, Street, HouseNumber, HousingNumber);
                                House house = new House()
                                {
                                NumberOfFlats = numberOfFlats,
                                NumberOfPorches = numberOfPorches,
                                AddressId = address.AddressId,
                                UserId = user.UserId
                                };
                                context.Addresses.Add(address);
                                context.Houses.Add(house);
                                context.SaveChanges();
                                IsVisibleProgressBar = false;
                                Message = "Дом успешно добавлен!";
                                IsOpenDialog = true;
                                Country = City = District = Street = string.Empty;
                                HouseNumber = HousingNumber = NumberOfFlats = NumberOfPorches = 0;
                            });
                        }

                    },
                    (x) => !String.IsNullOrWhiteSpace(country)));
            }
        }

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
        #endregion

        #region ctor
        public AddHouseViewModel(IFrameNavigationService navigationService)
        {

            _navigationService = navigationService;
            if (!IsVisibleProgressBar)
            {
                Country = String.Empty;
                District = String.Empty;
                City = String.Empty;
                Street = String.Empty;
            }

        }
        #endregion
    }
}
