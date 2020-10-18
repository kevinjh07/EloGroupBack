using EloGroupBack.Models.Dto;

namespace EloGroupBack.Services
{
    public interface ILeadService
    {
        void SaveLead(LeadDto leadDto);
    }
}