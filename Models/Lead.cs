using System;
using System.Collections.Generic;

namespace EloGroupBack.Models
{
    public class Lead
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }

        public int StatusId { get; set; }

        public StatusLead Status { get; set; }

        public Customer Customer { get; set; }

        public ICollection<Opportunity> Opportunities { get; set; }
    }
}