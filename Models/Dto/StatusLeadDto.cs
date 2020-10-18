namespace EloGroupBack.Models.Dto
{
    public class StatusLeadDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public StatusLeadDto(string description)
        {
            Description = description;
        }

        public StatusLeadDto()
        {
        }
    }
}