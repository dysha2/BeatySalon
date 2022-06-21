using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BeatySalon.Models;
using Prism.Mvvm;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace BeatySalon.ViewModels
{
    public class MainVM : BindableBase
    {
        public MainVM()
        {
            FilterVariants = new string[]
            {
                "0 0,05",
                "0,05 0,15",
                "0,15 0,3",
                "0,3 0,7",
                "0,7 1",
                "0 1"
            };
            IsAdmin = Session.IsAdmin;
            _Services = Session.Context.Services.Local.ToObservableCollection();
            _filter = 5;
            SetServices(_filter);
        }

        #region Fields
        private int _filter;
        private string searchString;
        private bool sortMode;
        private string[] FilterVariants;
        private ObservableCollection<Service> _Services;
        #endregion

        #region Properties
        public bool IsAdmin { get; set; }
        public int ServicesCount
        {
            get
            {
                return _Services.Count();
            }
        }
        public string SearchString { get => searchString;
            set { searchString = value; SearchServices(); } }
        public ListCollectionView Services { get; set; }
        public bool SortMode
        {
            get => sortMode;
            set
            {
                sortMode = value;
                SetSortDescription();
            }
        }
        #endregion

        #region Methods
        private void SetServices(int FilterMode)
        {
            _filter = FilterMode;
            var filter = FilterVariants[FilterMode].Split(' ');
            var services = _Services.Where(x => x.Discount >= Double.Parse(filter[0]) && x.Discount < Double.Parse(filter[1]));
            Services = new ListCollectionView(services.ToList());
            SetSortDescription();
            RaisePropertyChanged(nameof(Services));
        }
        private void SetSortDescription()
        {
            Services.SortDescriptions.Clear();
            ListSortDirection listSortDirection;
            if (SortMode)
                listSortDirection = ListSortDirection.Descending;
            else
                listSortDirection = ListSortDirection.Ascending;
            Services.SortDescriptions.Add(new SortDescription("PriceWithDiscount", listSortDirection));
        }
        private void SearchServices()
        {
            Services.Filter = obj => ((Service)obj).Title.Contains(SearchString, StringComparison.OrdinalIgnoreCase);
            RaisePropertyChanged(nameof(Services));
        }
        #endregion

        #region Commands
        private RelayCommand _SetFilter;
        private RelayCommand _DeleteService;
        private RelayCommand _EditService;

        public RelayCommand SetFilter
        {
            get
            {
                return _SetFilter ?? (_SetFilter = new RelayCommand(obj =>
                {
                    SetServices(int.Parse(obj.ToString()));
                }));
            }
        }
        public RelayCommand EditService
        {
            get
            {
                return _EditService ?? (_EditService = new RelayCommand(obj =>
                 {
                     EditVM editVM = new EditVM(obj);
                 }));
            }
        }
        public RelayCommand DeleteService
        {
            get
            {
                return _DeleteService ?? (_DeleteService = new RelayCommand(obj =>
                {
                    MessageVM messageVM = new MessageVM();
                    var Service = obj as Service;
                    if (Service.ServicePhotos.Count() > 0)
                    {
                        var result = messageVM.Show("Пердуперждение", 
                            "Для этого сервиса имеются дополнительные фотографии. Продолжить удаление?", 
                            MessageType.YesNo);
                        if (result == System.Windows.MessageBoxResult.No)
                        {
                            return; 
                        }
                    }
                    try
                    {
                        Service.Delete();
                        SetServices(_filter);
                    }
                    catch (Exception ex)
                    {
                        messageVM.Show("Ошибка", ex.Message, MessageType.JustInfo);
                    }
                }));
            }
        }
        #endregion
    }
}
