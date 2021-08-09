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
    public class TransactionViewModel : INotifyPropertyChanged
    {



        ServerViewModel SVM { get; set; }

        TransactionViewModel(ServerViewModel SV)
        {
            SVM = SV;
        }


        RelayCommand _addTransaction;
        RelayCommand AddTransaction
        {
            get
            {
                return _addTransaction ?? (_addTransaction = new RelayCommand(obj =>
                {
                    string response = SVM.CommandToServer("ADD_TRANSACTION", "USERID", "SUM","CATEGORYID","CURRENCYID");
                    if (response != null)
                        MessageBox.Show("Transaction Added");
                }));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
