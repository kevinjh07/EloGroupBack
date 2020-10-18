namespace EloGroupBack.Models
{
    public class Opportunity
    {
        public int Id { get; set; }

        public int LeadId { get; set; }

        public Lead Lead { get; set; }
    }
}