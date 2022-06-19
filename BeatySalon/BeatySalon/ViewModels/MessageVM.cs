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
    internal class MessageVM
    {
        public enum MessageType
        {
            JustInfo
        } 
        private string _message;
        private string _title;
        private MessageType _type;
        private List<Button> _buttons;
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
                if (value != null)
                    _type = value;
                else _type = MessageType.JustInfo;
            }
        }
        public List<Button> Buttons
        {
            get => _buttons;    
        }
        private void ToFillList()
        {
            if (_type == MessageType.JustInfo)
            {
                Button OKbutton = new Button()
                {
                    Command = Close,
                    Content = "ОК",
                };
                _buttons = new List<Button>()
                {
                    OKbutton,
                };
            }
        }

        public void MessageBoxShow()
        {
            MessageBoxWindow NewWindow = new MessageBoxWindow();
            NewWindow.DataContext = this;
            NewWindow.Show();
        }

        public void ToShowMessageBoxWindow(string title, string message, MessageType type)
        {
            Title = title;
            Message = message; 
            Type = type;
            MessageBoxShow();
        }

        public RelayCommand Close
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    var window = obj as Window;
                    window.Close();
                }
                );
            }
        }
    }
}
