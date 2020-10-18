namespace EloGroupBack.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public int LeadId { get; set; }

        public Lead Lead { get; set; }
    }
}