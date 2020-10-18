using System.Collections.Generic;

namespace EloGroupBack.Models.Dto
{
    public class LeadDto
    {
        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }

        public IEnumerable<OpportunityDto> Opportunities { get; set; }
    }
}