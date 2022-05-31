using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using HOAChairmanAssistant.Helpers.Locator;
using HOAChairmanAssistant.Helpers.MessageWindow;
using HOAChairmanAssistant.Model;
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
using System.Windows.Shapes;

namespace HOAChairmanAssistant.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
            Messenger.Default.Register<OpenWindowMessage>(
              this,
              message =>
              {
                  if (message.Type == WindowType.kMain)
                  {
                      var modalWindowVM = SimpleIoc.Default.GetInstance<MainWindowViewModel>();
                      modalWindowVM.User = message.Argument;
                      modalWindowVM.IsAccountant = modalWindowVM.User.Role == UserRole.Accountant;
                      var mainWindow = new MainWindow();
                      mainWindow.Show();
                      this.Close();
                  }
              });
        }

        private void LoginWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
