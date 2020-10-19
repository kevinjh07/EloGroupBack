namespace EloGroupBack.Models
{
    public class LeadOpportunity
    {
        public int LeadId { get; set; }
        public Lead Lead { get; set; }

        public int OpportunityId { get; set; }
        public Opportunity Opportunity { get; set; }
    }
}