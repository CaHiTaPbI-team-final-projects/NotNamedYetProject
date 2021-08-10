using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Security.Cryptography;

namespace WithoutName.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged 
    {


        private string _login;
        private string _password;
        ServerViewModel SVM { get; set; }
        
        public UserViewModel(ServerViewModel SV)
        {
            SVM = SV;
          
            
        }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }


        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        private RelayCommand _addUser;
        public RelayCommand AddUser
        {
            get
            {
                return _addUser ?? (_addUser = new RelayCommand(obj =>
                {
                    
                    //Params a = new Params();
                    //a.t = new List<string>() { "ADD_USER", "login", "password" }; 

                    //string response = SVM.CommandToServer(a);
                    //if (response != null)
                    //    MessageBox.Show("Registration Succesfully");
                }));
            }
        }

        private RelayCommand _authUser;
        public RelayCommand AuthUser
        {
            get
            {
                return _authUser ?? (_authUser = new RelayCommand(obj =>
                {

                    MessageBox.Show($"{Login} {Password}");
                    //Params a = new Params();
                    //a.t = new List<string>() { "LOGIN_USER", "login", "password" };

                    //string response = SVM.CommandToServer(a);
                    //if (response != null)
                    //    MessageBox.Show("Authoriztion Succesfully");
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
