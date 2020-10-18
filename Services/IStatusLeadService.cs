using EloGroupBack.Models.Dto;

namespace EloGroupBack.Services
{
    public interface IStatusLeadService
    {
        bool StatusLeadExists(string description);
        void SaveStatusLead(StatusLeadDto statusLeadDto);
        int GetIdByDescription(string clienteEmPotencial);
    }
}