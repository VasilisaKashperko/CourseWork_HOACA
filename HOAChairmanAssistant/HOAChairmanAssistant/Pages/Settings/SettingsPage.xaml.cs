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

namespace HOAChairmanAssistant.Pages.Settings
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public readonly ResourceDictionary dictionary0 = new ResourceDictionary() { Source = new Uri("Helpers/Dictionaries/DictionaryRU.xaml", UriKind.Relative) };
        public readonly ResourceDictionary dictionary1 = new ResourceDictionary() { Source = new Uri("Helpers/Dictionaries/DictionaryEN.xaml", UriKind.Relative) };
        public int language;

        public SettingsPage()
        {
            InitializeComponent();
            DataContext = new SettingsViewModel();
            if (language == 0)
            {
                Resources.MergedDictionaries.Add(dictionary0);
            }
            else
            {
                Resources.MergedDictionaries.Add(dictionary1);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox.SelectedIndex == 0)
            {
                Resources.MergedDictionaries.Remove(dictionary1);

                Resources.MergedDictionaries.Add(dictionary0);

                language = 0;
            }

            if (ComboBox.SelectedIndex == 1)
            {
                Resources.MergedDictionaries.Remove(dictionary0);

                Resources.MergedDictionaries.Add(dictionary1);

                language = 1;
            }
        }
    }
}
