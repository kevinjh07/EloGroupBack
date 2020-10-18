using System.Collections.Generic;
using EloGroupBack.Models.Dto;

namespace EloGroupBack.Services
{
    public interface ILeadService
    {
        void SaveLead(LeadDto leadDto);
        IEnumerable<LeadDto> GetLeads();
        void UpdateStatus(int id, int statusId);
    }
}