using BeatySalon.ViewModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable

namespace BeatySalon.Models
{
    public partial class ServicePhoto:BindableBase
    {
        private string photoPath;

        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string PhotoPath { get => photoPath; set { photoPath = value; RaisePropertyChanged(); } }
        public void Delete()
        {
            Session.Context.ServicePhotos.Local.Remove(this);
            RaisePropertyChanged("PhotoPath");
            //try
            //{
            //    File.Delete($"{Environment.CurrentDirectory}/Images/{PhotoPath}");
            //} catch(Exception ex) {
            //MessageVM message = new MessageVM();
            //    message.Show("Error", ex.Message, MessageType.JustInfo);
            //}

        }
        public virtual Service Service { get; set; }
    }
}
