using System;
using AutoMapper;
using EloGroupBack.Context;
using EloGroupBack.Models;
using EloGroupBack.Models.Dto;

namespace EloGroupBack.Services
{
    public class LeadService : ILeadService
    {
        private readonly ApplicationContext _context;

        private readonly IMapper _mapper;

        private readonly IStatusLeadService _statusLeadService;

        public LeadService(ApplicationContext context, IMapper mapper, IStatusLeadService statusLeadService)
        {
            _context = context;
            _mapper = mapper;
            _statusLeadService = statusLeadService;
        }


        public void SaveLead(LeadDto leadDto)
        {
            var lead = _mapper.Map<Lead>(leadDto);
            lead.StatusId = _statusLeadService.GetIdByDescription("Cliente em Potencial");
            lead.Date = DateTime.Now;
            _context.Leads.Add(lead);
            _context.SaveChanges();
        }
    }
}