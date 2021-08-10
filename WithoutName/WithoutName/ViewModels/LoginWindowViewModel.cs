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
using System.Diagnostics;

namespace WithoutName.ViewModels
{
    public class LoginWindowViewModel : INotifyPropertyChanged
    {
        ServerViewModel SVM { get; set; } = new ServerViewModel();
        //login values
       

        //LoginWindow _loginWindow;


        

        public UserViewModel uvm { get; set; }

        // Data for main window
        public bool isAuthorized { get; set; }
        public User authUser = new User();
        //

        public ICommand Authorize { get; set; }
        public ICommand Register { get; set; }



        public LoginWindowViewModel()
        {   //LoginWindow loginWindow

            uvm = new UserViewModel(SVM);
            isAuthorized = false;
            //Authorize = new RelayCommand(ForceAuthorize, canExecuteMethod);
            //Register = new RelayCommand(ForceRegister, canExecuteMethod);
            //_loginWindow = loginWindow;
            
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


   
        





        //void ForceRegister(object parameter)
        //{
        //    var passwordBox = parameter as PasswordBox;
        //    _passwordReg = passwordBox.Password;
        //    _passwordReg = GetHash(_passwordReg);
        //    User NewUser = new User()
        //    {
        //        Id = 0,
        //        MonthLimit = 0,
        //        Income = 0,
        //        Password = _passwordReg,
        //        Login = _loginReg,


        //        // WIP
        //        /*
        //        Surname = "test",
        //        Name = "test"
        //         */

        //    };
        //    uvm.UsersList.Add(NewUser);
        //    var obj = new object();
        //    uvm.UpdateUser.Execute(obj);


        //}

        //void ForceAuthorize(object parameter)
        //{
        //    var passwordBox = parameter as PasswordBox;
        //    _password = passwordBox.Password;
        //    _password = GetHash(_password);
        //    authUser = uvm.UsersList.Where(c => c.Username == _login).FirstOrDefault();
        //    if (authUser != null && authUser.Password == _password)
        //    {
        //        isAuthorized = true;
        //        _loginWindow.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Authorize Failed!\nIncorrect login or password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}


        //private RelayCommand signInButton_Click;
        //public RelayCommand SignInButton_Click
        //{
        //    get
        //    {
        //        return signInButton_Click ??
        //            (signInButton_Click = new RelayCommand(obj =>
        //            {
        //                _loginWindow.Reg1.Visibility = Visibility.Hidden;
        //                _loginWindow.Log1.Visibility = Visibility.Visible;
        //                _loginWindow.Log2.Visibility = Visibility.Visible;

        //            }));
        //    }
        //}

        //private RelayCommand signUpButton_Click;
        //public RelayCommand SignUpButton_Click
        //{
        //    get
        //    {
        //        return signUpButton_Click ??
        //            (signUpButton_Click = new RelayCommand(obj =>
        //            {
        //                _loginWindow.Reg1.Visibility = Visibility.Visible;
        //                _loginWindow.Log1.Visibility = Visibility.Hidden;
        //                _loginWindow.Log2.Visibility = Visibility.Hidden;

        //            }));
        //    }
        //}

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

        private RelayCommand _loadedEvent;
        public RelayCommand LoadedEvent
        {
            get
            {
                return _loadedEvent ?? (_loadedEvent = new RelayCommand(obj =>
                {
                    ComboBox lang = (ComboBox)obj;
                    if(Properties.Settings.Default.languageCode == "en-US")
                    {
                        lang.SelectedIndex = 0;
                    }
                    else if (Properties.Settings.Default.languageCode == "uk-UA")
                    {
                        lang.SelectedIndex = 1;
                    }
                    else if(Properties.Settings.Default.languageCode == "ru-RU")
                    {
                        lang.SelectedIndex = 2;
                    }
                    
                }));
            }
        }

        private RelayCommand _languageSelection;
        public RelayCommand LanguageSelection
        {
            get
            {
                return _languageSelection ?? (_languageSelection = new RelayCommand(obj =>
                {
                    ComboBox comb = (ComboBox)obj;
                    
                    if(comb.SelectedIndex == 0)
                    {
                        Properties.Settings.Default.languageCode = "en-US";
                    }
                    else if(comb.SelectedIndex == 1)
                    {
                        Properties.Settings.Default.languageCode = "uk-UA";
                    }
                    else if(comb.SelectedIndex == 2)
                    {
                        Properties.Settings.Default.languageCode = "ru-RU";
                    }
                    Properties.Settings.Default.Save();
                    Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }));
            }
        }



        private bool canExecuteMethod(object parameter)
        {
            return true;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
