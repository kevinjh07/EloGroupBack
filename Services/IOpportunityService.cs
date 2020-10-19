using System.Collections.Generic;
using EloGroupBack.Models.Dto;

namespace EloGroupBack.Services
{
    public interface IOpportunityService
    {
        void SaveOpportunity(OpportunityDto opportunityDto);
        bool OpportunityExists(string description);
        IEnumerable<OpportunityDto> GetOpportunities();
    }
}