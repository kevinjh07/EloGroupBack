using System.ComponentModel.DataAnnotations;

namespace EloGroupBack.Models.Dto
{
    public class OpportunityDto
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}