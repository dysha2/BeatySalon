using BeatySalon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BeatySalon.Selectors
{
    internal class DatatypeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ServiceEdit { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return ServiceEdit;
            switch (item.GetType().Name)
            {
                case nameof(Service): return ServiceEdit;
                default: return ServiceEdit;
            }
        }
    }
}
