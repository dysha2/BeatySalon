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
using BeatySalon.Views;
using System.Windows;

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
            _Clients = Session.Context.Clients.Local.ToObservableCollection();
            _filter = 5;
            SetServices(_filter);
            Clients = new ListCollectionView(_Clients);
        }

        #region Fields
        private ClientServiceWindow clientServiceWindow;
        private int _filter;
        private string searchString;
        private bool sortMode;
        private string[] FilterVariants;
        private Service _selectedService=null;
        private ObservableCollection<Service> _Services;
        private ObservableCollection<Client> _Clients;
        #endregion

        #region Properties
        public DateTime Date { get; set; }
        public int Minutes { get; set; }
        public int Hours { get; set; }
        public bool IsAdmin { get; set; }
        public ListCollectionView Clients { get; set; }
        public ClientService ClientService { get; set; }
        public Service SelectedService
        {
            get => _selectedService;
            set
            {
                _selectedService = value;
                if (value != null)
                {
                    ClientServiceWindow clientServiceWindow = new ClientServiceWindow();
                    clientServiceWindow.DataContext = this;
                    ClientService = new ClientService();
                    ClientService.Service = SelectedService;
                    Date = DateTime.Today;
                    clientServiceWindow.ShowDialog();
                }
                RaisePropertyChanged();
            }
        }
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
        private RelayCommand _SaveChanges;
        private RelayCommand _AddClientService;

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
                     SetServices(_filter);
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
        public RelayCommand SaveChanges
        {
            get
            {
                return _SaveChanges ?? (_SaveChanges = new RelayCommand(obj =>
                {
                    MessageVM message = new MessageVM();
                    try
                    {
                        Session.Context.SaveChanges();
                        message.Show("Успех", "Изменения сохранены в базу", MessageType.JustInfo);
                    } catch (Exception ex)
                    {
                        message.Show("Error", ex.Message, MessageType.JustInfo);
                    }
                }));
            }
        }
        public RelayCommand AddClientService
        {
            get 
            {
                return _AddClientService ?? (_AddClientService = new RelayCommand(obj =>
                {
                    Date=Date.AddHours(Hours);
                    Date=Date.AddMinutes(Minutes);
                    ClientService.StartTime = Date;
                    Session.Context.ClientServices.Add(ClientService);
                    Session.Context.SaveChanges();
                    ((Window)obj).Close();
                }));
            }
        }        
        #endregion
    }
}
