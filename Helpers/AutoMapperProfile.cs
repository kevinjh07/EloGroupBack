using AutoMapper;
using EloGroupBack.Models;
using EloGroupBack.Models.Dto;

namespace EloGroupBack.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Lead, LeadDto>();
            CreateMap<LeadDto, Lead>();
            CreateMap<Opportunity, OpportunityDto>();
            CreateMap<OpportunityDto, Opportunity>();
        }
    }
}