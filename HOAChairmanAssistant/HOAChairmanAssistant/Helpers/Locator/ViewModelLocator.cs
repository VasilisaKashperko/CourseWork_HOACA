using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using HOAChairmanAssistant.Helpers.Navigation;
using HOAChairmanAssistant.ViewModel;
using System;

namespace HOAChairmanAssistant.Helpers.Locator
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<LoginWindowViewModel>();
            SimpleIoc.Default.Register<MainWindowViewModel>();
            //SimpleIoc.Default.Register<AdminViewModel>();
            //SimpleIoc.Default.Register<CookViewModel>();
            SetupNavigation();
        }

        private static void SetupNavigation()
        {
            var navigationService = new FrameNavigationService();
            navigationService.Configure("Login", new Uri("../Pages/Login/LoginPage.xaml", UriKind.Relative));
            navigationService.Configure("Registration", new Uri("../Pages/Login/RegistrationPage.xaml", UriKind.Relative));
            navigationService.Configure("Houses", new Uri("../Pages/Houses/HousesPage.xaml", UriKind.Relative));
            navigationService.Configure("AddHousePage", new Uri("../Pages/Houses/AddHousePage.xaml", UriKind.Relative));
            navigationService.Configure("Information", new Uri("../Pages/Information/InformationPage.xaml", UriKind.Relative));
            navigationService.Configure("Reservation", new Uri("../Pages/Menu/ReservationPage.xaml", UriKind.Relative));
            navigationService.Configure("Feedback", new Uri("../Pages/Menu/FeedbackPage.xaml", UriKind.Relative));
            navigationService.Configure("Favourites", new Uri("../Pages/Menu/FavouritesPage.xaml", UriKind.Relative));
            navigationService.Configure("Admin", new Uri("../Pages/Menu/AdminPage.xaml", UriKind.Relative));
            navigationService.Configure("Cook", new Uri("../Pages/Menu/CookPage.xaml", UriKind.Relative));
            navigationService.Configure("AddMenuDish", new Uri("../Pages/Admin/AddMenuDishPage.xaml", UriKind.Relative));
            navigationService.Configure("AddNewsBlock", new Uri("../Pages/Admin/AddNewsBlockPage.xaml", UriKind.Relative));
            navigationService.Configure("ReservedTables", new Uri("../Pages/Admin/ReservedTablesPage.xaml", UriKind.Relative));
            navigationService.Configure("OrderingProduct", new Uri("../Pages/Cook/OrderingProductPage.xaml", UriKind.Relative));
            navigationService.Configure("Warehouse", new Uri("../Pages/Cook/WarehousePage.xaml", UriKind.Relative));
            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);
        }

        public MainWindowViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }


        public LoginWindowViewModel LoginWindowViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginWindowViewModel>();
            }
        }

        //public AdminViewModel AdminViewModel
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<AdminViewModel>();
        //    }
        //}

        //public CookViewModel CookViewModel
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<CookViewModel>();
        //    }
        //}

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}
