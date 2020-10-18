using System.ComponentModel.DataAnnotations;

namespace EloGroupBack.Models.Dto
{
    public class UserDto
    {
        [Required]
        [MaxLength(120)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}