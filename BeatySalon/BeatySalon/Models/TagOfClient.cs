using System;
using System.Collections.Generic;

#nullable disable

namespace BeatySalon.Models
{
    public partial class TagOfClient
    {
        public int ClientId { get; set; }
        public int TagId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
