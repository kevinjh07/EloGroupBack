using System;
using System.Linq;
using AutoMapper;
using EloGroupBack.Context;
using EloGroupBack.Models;
using EloGroupBack.Models.Dto;

namespace EloGroupBack.Services
{
    public class StatusLeadService : IStatusLeadService
    {
        private readonly ApplicationContext _context;

        private readonly IMapper _mapper;

        public StatusLeadService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public bool StatusLeadExists(string description)
        {
            return _context.StatusLeads.Any(sl => string.Compare(description, sl.Description,
                StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public void SaveStatusLead(StatusLeadDto statusLeadDto)
        {
            var statusLead = _mapper.Map<StatusLead>(statusLeadDto);
            _context.StatusLeads.Add(statusLead);
            _context.SaveChanges();
        }

        public int GetIdByDescription(string description)
        {
            return _context.StatusLeads.Where(sl => sl.Description == description)
                .Select(sl => sl.Id)
                .SingleOrDefault();
        }
    }
}