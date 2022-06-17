using System;
using System.Collections.Generic;

#nullable disable

namespace BeatySalon.Models
{
    public partial class DocumentByService
    {
        public int Id { get; set; }
        public int ClientServiceId { get; set; }
        public string DocumentPath { get; set; }

        public virtual ClientService ClientService { get; set; }
    }
}
