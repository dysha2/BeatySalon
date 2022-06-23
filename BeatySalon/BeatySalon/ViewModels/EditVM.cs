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
        private EditWindow editWindow;

        public EditVM(object item)
        {
            Item = item;
            editWindow = new EditWindow();
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
                    //editWindow.Close();
                    //editWindow = new EditWindow();
                    ((ServicePhoto)obj).Delete();
                    //((Service)Item);
                    //editWindow.DataContext = this;
                    //editWindow.ShowDialog();
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
        public RelayCommand AddImage
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    ServicePhoto servicePhoto = new ServicePhoto()
                    {
                        Service = (Service)Item,
                        PhotoPath = "Услуги салона красоты\\null.jpg"
                    };
                    editWindow.Close();
                    editWindow = new EditWindow();
                    Session.Context.ServicePhotos.Local.Add(servicePhoto);
                    editWindow.DataContext = this;
                    editWindow.ShowDialog();
                });
            }
        }
    }
}
