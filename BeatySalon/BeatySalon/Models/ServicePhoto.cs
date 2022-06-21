using System;
using System.Collections.Generic;

#nullable disable

namespace BeatySalon.Models
{
    public partial class ServicePhoto
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string PhotoPath { get; set; }
        public void Delete()
        {
            Session.Context.ServicePhotos.Local.Remove(this);
        }
        public virtual Service Service { get; set; }
    }
}
