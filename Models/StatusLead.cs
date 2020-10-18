using System.Collections.Generic;

namespace EloGroupBack.Models
{
    public class StatusLead
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ICollection<Lead> Leads { get; set; }
    }
}