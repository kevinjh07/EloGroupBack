using System.Collections.Generic;

namespace EloGroupBack.Models
{
    public class Opportunity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ICollection<LeadOpportunity> LeadOpportunities { get; set; }
    }
}    