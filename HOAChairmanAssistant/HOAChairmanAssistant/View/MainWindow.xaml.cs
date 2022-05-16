using HOAChairmanAssistant.Pages;
using HOAChairmanAssistant.UserControls;
using HOAChairmanAssistant.ViewModel;
using System;
using System.Windows;
//using EfDbApp.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HOAChairmanAssistant.DataLayer.EF;
using GalaSoft.MvvmLight.Ioc;
using HOAChairmanAssistant.Helpers.Navigation;
using System.Threading;
using HOAChairmanAssistant.Pages.Houses;
using GalaSoft.MvvmLight.Messaging;
using HOAChairmanAssistant.Helpers.MessageWindow;
using GalaSoft.MvvmLight.Threading;

namespace HOAChairmanAssistant.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ResourceDictionary dictionary1 = new ResourceDictionary() { Source = new Uri("Helpers/Dictionaries/DictionaryRU.xaml", UriKind.Relative) };
        private readonly ResourceDictionary dictionary2 = new ResourceDictionary() { Source = new Uri("Helpers/Dictionaries/DictionaryEN.xaml", UriKind.Relative) };
        public MainWindow()
        {
            DataContext = new MainWindowViewModel(SimpleIoc.Default.GetInstance<IFrameNavigationService>());
            Resources.MergedDictionaries.Add(dictionary1);
            InitializeComponent();
        }
        private void ButtonShutDown_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void MoveCursorMenu(int index)
        {
            TransitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new HousesPage());
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

    }
}
