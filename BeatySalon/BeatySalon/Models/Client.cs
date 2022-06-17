using System;
using System.Collections.Generic;

#nullable disable

namespace BeatySalon.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientServices = new HashSet<ClientService>();
            TagOfClients = new HashSet<TagOfClient>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GenderCode { get; set; }
        public string PhotoPath { get; set; }

        public virtual Gender GenderCodeNavigation { get; set; }
        public virtual ICollection<ClientService> ClientServices { get; set; }
        public virtual ICollection<TagOfClient> TagOfClients { get; set; }
    }
}
