using BeatySalon.Views.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BeatySalon.ViewModels
{
    public enum MessageType
    {
        JustInfo,
        YesNo
    }
    internal class MessageVM
    {
        
        private string _message;
        private string _title;
        private MessageType _type;
        private MessageBoxResult _result;
        private MessageBoxWindow _MessageBoxWindow;

        public MessageVM()
        {
            _MessageBoxWindow = new MessageBoxWindow();
            _MessageBoxWindow.DataContext = this;
            _title = "Error";
        }

        public string Message 
        { 
            get => _message; 
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                    _message = value;
            }
        }
        public string Title 
        { 
            get => _title; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                     _title = value;
            }
        }
        public MessageType Type
        {
            get => _type;
            set
            {
                _type = value;
            }
        }
        public MessageBoxResult Show(string title, string message, MessageType type)
        {
            Title = title;
            Message = message; 
            Type = type;
            _MessageBoxWindow.ShowDialog();
            return _result;
        }

        public RelayCommand ResultMessage
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    _result = (MessageBoxResult)int.Parse(obj.ToString());
                    _MessageBoxWindow.Close();
                }
                );
            }
        }
    }
}
