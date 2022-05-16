using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HOAChairmanAssistant.DataLayer.EF;
using HOAChairmanAssistant.Helpers;
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
                        Houses = new ObservableCollection<House>(context.Houses.AsNoTracking().ToList());

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

        //private RelayCommandParametr searchCommand;
        //public RelayCommandParametr SearchCommand
        //{
        //    get
        //    {
        //        return searchCommand
        //            ?? (searchCommand = new RelayCommandParametr(
        //            (obj) =>
        //            {
        //                IsVisibleProgressBar = true;
        //                searchedThread = new Thread(() =>
        //                {
        //                    if (String.IsNullOrWhiteSpace(searchField))
        //                    {
        //                        MenuDishes = new ObservableCollection<MenuDish>(context.Dishes.AsNoTracking().ToList());
        //                    }
        //                    else if (!String.IsNullOrWhiteSpace(searchField))
        //                    {
        //                        MenuDishes = new ObservableCollection<MenuDish>(context.Dishes.Where(x => x.MenuDishName.Contains(searchField)));

        //                    }
        //                    SearchField = null;
        //                    IsVisibleProgressBar = false;
        //                });
        //                searchedThread.IsBackground = true;
        //                searchedThread.Start();
        //            }));
        //    }
        //}



        #endregion

        #region ctor
        public HousesViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion
    }
}
