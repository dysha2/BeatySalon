using System;
using System.Collections.Generic;

#nullable disable

namespace BeatySalon.Models
{
    public partial class Tag
    {
        public Tag()
        {
            TagOfClients = new HashSet<TagOfClient>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }

        public virtual ICollection<TagOfClient> TagOfClients { get; set; }
    }
}
