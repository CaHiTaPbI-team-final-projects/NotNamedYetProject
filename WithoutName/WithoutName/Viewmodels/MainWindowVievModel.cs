using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WithoutName.Commands;
using WithoutName.Views;
using System.Windows;

namespace WithoutName.ViewModels
{
    public class MainWindowVievModel
    {


        private RelayCommand _dragEvent;
        public RelayCommand DragEvent
        {
            get
            {
                return _dragEvent ?? (_dragEvent = new RelayCommand(obj =>
                {
                    Window win = (Window)obj;
                    win.DragMove();
                }));
            }
        }

        private RelayCommand _exit;
        public RelayCommand Exit
        {
            get
            {
                return _exit ?? (_exit = new RelayCommand(obj =>
                {
                    Window win = (Window)obj;
                    win.Close();
                }));
            }
        }


        private RelayCommand _tab1;

        public RelayCommand Tab1 
        {
            get
            {
                return _tab1 ?? (_tab1 = new RelayCommand(obj =>
                {
                    MainWindow mainWindow  = (MainWindow)obj;
                    mainWindow.Tab1Grid.Visibility = Visibility.Visible;
                    mainWindow.Tab2Grid.Visibility = Visibility.Hidden;
                }));
            }
        }


        private RelayCommand _tab2;

        public RelayCommand Tab2
        {
            get
            {
                return _tab2 ?? (_tab2 = new RelayCommand(obj =>
                {
                    MainWindow mainWindow = (MainWindow)obj;
                    mainWindow.Tab1Grid.Visibility = Visibility.Hidden;
                    mainWindow.Tab2Grid.Visibility = Visibility.Visible;
                }));
            }
        }
    }
}
