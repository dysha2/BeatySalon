using BeatySalon.Views;
using BeatySalon.Views.MessageBox;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static BeatySalon.ViewModels.MessageVM;

namespace BeatySalon.ViewModels
{
    internal class AuthorizationVM : BindableBase
    {
        private string _password;

        private bool _isAdmin = false;

        public string Password { get => _password;
            set
            {
                if (value == "0000")
                {
                    _password = value;
                    _isAdmin = true;
                }
                else
                {
                    MessageVM messageVM = new MessageVM();
                    messageVM.Show("Ошибка", "Введён неправильный пароль", MessageType.JustInfo);
                }
            }
        }

        public void GoIn(bool IsAdmin)
        {
            Session.IsAdmin = IsAdmin;
            MainWindow NewWindow = new MainWindow();
            NewWindow.Show();
        }

        public RelayCommand LetsIn
        {
            get
            {
                return new RelayCommand(obj =>
                    {
                        var window = obj as Window;
                        GoIn(_isAdmin);
                        window.Close();
                    }
                );
            }
        }
    }
}
