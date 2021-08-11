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
using System.Collections.Generic;

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
                    
                    Params a = new Params();
                    

                    Transaction transaction = new Transaction()
                    {
                        UserId = 0,
                        Amount = 0,
                        CategoryId = 0,
                        CurrencyId = 0
                    };
                    a.ClassForSend = transaction;
                    a.Command = "ADD_TRANSACTION";

                    string response = SVM.CommandToServer(a);
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
