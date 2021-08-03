using System;
using System.Collections.Generic;
using System.Diagnostics;
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



namespace WithoutName
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (leng.SelectedIndex == 0)
                Properties.Settings.Default.languageCode = "en-US";
            else if (leng.SelectedIndex == 1)
                Properties.Settings.Default.languageCode = "ru-RU";
            else if (leng.SelectedIndex == 2)
                Properties.Settings.Default.languageCode = "uk-UA";
            Properties.Settings.Default.Save();
            


            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();

        }


    }
}
