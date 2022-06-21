using BeatySalon.Views;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
