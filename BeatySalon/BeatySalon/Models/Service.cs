using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace BeatySalon.Models
{
    public partial class Service
    {
        public Service()
        {
            ClientServices = new HashSet<ClientService>();
            ServicePhotos = new HashSet<ServicePhoto>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public int DurationInSeconds { get; set; }
        public string Description { get; set; }
        public double? Discount { get; set; }
        public string MainImagePath { get; set; }
        [NotMapped]
        public decimal PriceWithDiscount
        {
            get
            {
                decimal discount =decimal.Parse((1-Discount).ToString());
                return Cost * discount;
            }
        }
        public void Delete()
        {
            foreach (var ServicePhoto in ServicePhotos)
            {
                ServicePhoto.Delete();
            }
            if (ClientServices.Count > 0)
            {
                throw new Exception("На эту услуги есть записанные клиенты");
            } else
            {
                Session.Context.Services.Local.Remove(this);
            }
        }
        public virtual ICollection<ClientService> ClientServices { get; set; }
        public virtual ICollection<ServicePhoto> ServicePhotos { get; set; }
    }
}
