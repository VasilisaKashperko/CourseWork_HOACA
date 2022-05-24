using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using HOAChairmanAssistant.DataLayer.EF;
using HOAChairmanAssistant.Helpers.Navigation;
using HOAChairmanAssistant.Model;
using System.Linq;
using System.Threading;


namespace HOAChairmanAssistant.ViewModel
{
    public class AboutHouseViewModel : ViewModelBase
    {
        #region Private Fields
        private IFrameNavigationService _navigationService;
        private HOAChairmanAssistantContext context = new HOAChairmanAssistantContext();
        private bool isFavorite;
        private User user;
        private House aboutHouse { get; set; }
        private bool isOpenDialog;
        private string message;
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

        //private RelayCommandParametr addToFavoriteCommand;
        //public RelayCommandParametr AddToFavoriteCommand
        //{
        //    get
        //    {
        //        return addToFavoriteCommand
        //            ?? (addToFavoriteCommand = new RelayCommandParametr(
        //            (x) =>
        //            {
        //                Thread temp;
        //                if (!IsFavorite)
        //                {
        //                    FavoriteDish favorite = new FavoriteDish()
        //                    {
        //                        UserId = user.UserId,
        //                        MenuDishId = MenuDish.MenuDishId
        //                    };
        //                    temp = new Thread(() =>
        //                    {

        //                        context.FavoriteDishes.Add(favorite);
        //                        context.SaveChanges();
        //                        IsFavorite = true;
        //                        Message = "Блюдо добавлено в избранные!";
        //                        IsOpenDialog = true;

        //                    });
        //                }
        //                else
        //                {
        //                    temp = new Thread(() =>
        //                    {
        //                        FavoriteDish favdish = context.FavoriteDishes.Where(x1 => x1.UserId == user.UserId && x1.MenuDishId == menuDish.MenuDishId).First();
        //                        if (favdish != null)
        //                        {
        //                            context.FavoriteDishes.Remove(favdish);
        //                        }
        //                        context.SaveChanges();
        //                        Message = "Блюдо удалено из избранных!";
        //                        IsOpenDialog = true;
        //                        IsFavorite = false;
        //                    });
        //                }
        //                temp.IsBackground = true;
        //                temp.Start();
        //            }));
        //    }
        //}

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
                    House house = context.Houses.AsNoTracking().Where(x => x.UserId == user.UserId && x.HouseId == aboutHouse.HouseId).FirstOrDefault(); // house
                    IsFavorite = house != null ? true : false;
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
