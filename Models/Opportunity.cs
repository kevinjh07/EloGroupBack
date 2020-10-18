namespace EloGroupBack.Models
{
    public class Opportunity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int LeadId { get; set; }

        public Lead Lead { get; set; }
    }
}    