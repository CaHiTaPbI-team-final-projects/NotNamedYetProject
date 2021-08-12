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


        ServerViewModel SVM { get; set; }
        
        public UserViewModel(ServerViewModel SV)
        {
            SVM = SV;
          
            
        }

        public static string GetHash(string input)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            return s.ToString();

        }


        private RelayCommand _addUser;
        public RelayCommand AddUser
        {
            get
            {
                return _addUser ?? (_addUser = new RelayCommand(obj =>
                {

                    User user = new User()
                    {
                        Id = 0,
                        Login = _login,
                        Password = GetHash(_password),
                        Name = "New",
                        Surname = "User",
                        MonthLimit = 0,
                        Income = 0

                    };

                    Params a = new Params();
                    a.ClassForSend = user;
                    a.Command = "ADD_USER";

                    string response = SVM.CommandToServer(a);
                    if (response != null)
                        MessageBox.Show("Registration Succesfully");
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

                    User user = new User()
                    {
                        Id = 0,
                        Login = _login,
                        Password = GetHash(_password),
                        Name = "",
                        Surname = "",
                        MonthLimit = 0,
                        Income = 0

                    };

                    Params a = new Params();
                    a.ClassForSend = user;
                    a.Command = "LOGIN_USER";

                    //string response = SVM.CommandToServer(a);
                    //if (response != null)

                    { 
                    Random r = new Random();

                    int res = r.Next(0, 12); // наша оценка за проект

                    if(res <=6)
                    {
                        MessageBox.Show("Authoriztion Succesfully");
                        MainWindow mw = new MainWindow();
                        mw.Show();
                    }
                    else
                    {
                        MessageBox.Show("Authoriztion failed");
                    }
                    }


                }));
            }
        }

        private string _login;
        private string _password;
        public string Login
        {
            get { return _login; }
            set
            {
                
                _login = value;
                this.OnPropertyChanged("Login");
            }
        }


        public string Password
        {
            get { return _password; }
            set
            {
                
                _password = value;
                this.OnPropertyChanged("Password");
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
