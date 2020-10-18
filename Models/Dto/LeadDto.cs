using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EloGroupBack.Models.Dto
{
    public class LeadDto
    {
        [Required]
        [MaxLength(120)]
        public string CustomerName { get; set; }

		[Required]
        [MaxLength(12)]
        public string CustomerPhone { get; set; }
        
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        public IEnumerable<OpportunityDto> Opportunities { get; set; }
    }
}