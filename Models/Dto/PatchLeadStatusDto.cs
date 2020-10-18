using System.ComponentModel.DataAnnotations;

namespace EloGroupBack.Models.Dto
{
    public class PatchLeadStatusDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int StatusId { get; set; }
    }
}