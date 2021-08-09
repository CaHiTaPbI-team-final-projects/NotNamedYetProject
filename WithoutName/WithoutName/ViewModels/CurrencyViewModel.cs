using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using WithoutName.Commands;
using WithoutName.Models;
using WithoutName.Views;
using System.Windows;
using WithoutName.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace WithoutName.ViewModels
{
    public class CurrencyViewModel : INotifyPropertyChanged
    {

        ServerViewModel SVM { get; set; }
        public ObservableCollection<Currency> Currencies { get; set; }

        CurrencyViewModel(ServerViewModel SV)
        {
            SVM = SV;
            Currencies = new ObservableCollection<Currency>();
        }



        private Currency _selectedCurrency;
        public Currency SelectedCurrency
        {
            get { return _selectedCurrency; }
            set
            {
                _selectedCurrency = value;


                OnPropertyChanged("SelectedCurrency");
            }
        }







        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
