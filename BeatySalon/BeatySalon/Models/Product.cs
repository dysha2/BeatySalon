using System;
using System.Collections.Generic;

#nullable disable

namespace BeatySalon.Models
{
    public partial class Product
    {
        public Product()
        {
            AttachedProductAttachedProductNavigations = new HashSet<AttachedProduct>();
            AttachedProductMainProducts = new HashSet<AttachedProduct>();
            ProductPhotos = new HashSet<ProductPhoto>();
            ProductSales = new HashSet<ProductSale>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public string MainImagePath { get; set; }
        public bool IsActive { get; set; }
        public int? ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<AttachedProduct> AttachedProductAttachedProductNavigations { get; set; }
        public virtual ICollection<AttachedProduct> AttachedProductMainProducts { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }
        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}
