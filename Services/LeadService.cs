using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EloGroupBack.Context;
using EloGroupBack.Exceptions;
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

        public IEnumerable<LeadDto> GetLeads()
        {
            return _context.Leads.Select(l => new LeadDto
            {
                Id = l.Id,
                CustomerName = l.CustomerName,
                StatusId = l.StatusId
            });
        }

        public void UpdateStatus(int id, int statusId)
        {
            var lead = _context.Leads.SingleOrDefault(l => l.Id == id);
            if (lead == null) throw new NotFoundException();
            if (lead.StatusId + 1 != statusId) throw new UnprocessableEntityException("Status inválido!");

            lead.StatusId = statusId;
            _context.SaveChanges();
        }
    }
}