using BeatySalon.Models;
using BeatySalon.Views;
using Microsoft.Win32;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeatySalon.ViewModels
{
    internal class EditVM : BindableBase
    {
        private object item;

        public EditVM(object item)
        {
            Item = item;
            EditWindow editWindow = new EditWindow();
            editWindow.DataContext = this;
            editWindow.ShowDialog();
        }

        public object Item { get => item; set => item = value; }
        
        public string SetPicture()
        {
            OpenFileDialog ofn = new OpenFileDialog();
            ofn.Filter = "PNG|*.png|All|*.*|JPG|*.jpg|JPEG|*.jpeg";
            if (ofn.ShowDialog() != false)
            {
                string NewFileName = $"{Environment.CurrentDirectory}/Images/Услуги салона красоты/{ofn.SafeFileName}";
                if (!File.Exists(NewFileName))
                {
                    File.Copy(ofn.FileName, NewFileName);
                }
                return $"Услуги салона красоты/{ofn.SafeFileName}";
            }
            return null;
        }
        public RelayCommand ChangeImage
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    string NewImage = SetPicture();
                    if (NewImage != null)
                    {
                        switch (obj.GetType().Name)
                        {
                            case nameof(Service):
                                ((Service)obj).MainImagePath = NewImage;
                            break;
                            case nameof(ServicePhoto):
                                ((ServicePhoto)obj).PhotoPath = NewImage;
                                break;
                        }
                        RaisePropertyChanged(nameof(Item));
                    }
                });
            }
        }
        public RelayCommand DeleteImage
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    ((ServicePhoto)obj).Delete();
                    RaisePropertyChanged(nameof(Item));
                });
            }
        }
        public RelayCommand ResultMessage
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Session.Context.SaveChanges();
                    ((Window)obj).Close();
                });
            }
        }
    }
}
