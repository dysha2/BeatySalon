using System;
using System.Collections.Generic;

#nullable disable

namespace BeatySalon.Models
{
    public partial class AttachedProduct
    {
        public int MainProductId { get; set; }
        public int AttachedProductId { get; set; }

        public virtual Product AttachedProductNavigation { get; set; }
        public virtual Product MainProduct { get; set; }
    }
}
