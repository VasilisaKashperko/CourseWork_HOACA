﻿using GalaSoft.MvvmLight.Ioc;
using HOAChairmanAssistant.Helpers.Navigation;
using HOAChairmanAssistant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HOAChairmanAssistant.Pages.Houses
{
    /// <summary>
    /// Логика взаимодействия для AboutHousePage.xaml
    /// </summary>
    public partial class AboutHousePage : Page
    {
        public AboutHousePage()
        {
            DataContext = new AboutHouseViewModel(SimpleIoc.Default.GetInstance<IFrameNavigationService>());
            InitializeComponent();
        }
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            if (e.Delta < 0)
            {
                scrollViewer.LineDown();
            }
            else
            {
                scrollViewer.LineUp();
            }
            e.Handled = true;
        }
    }
}
