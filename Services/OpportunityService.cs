using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EloGroupBack.Context;
using EloGroupBack.Models;
using EloGroupBack.Models.Dto;

namespace EloGroupBack.Services
{
    public class OpportunityService : IOpportunityService
    {
        private readonly ApplicationContext _context;

        private readonly IMapper _mapper;

        public OpportunityService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void SaveOpportunity(OpportunityDto opportunityDto)
        {
            var opportunity = _mapper.Map<Opportunity>(opportunityDto);
            _context.Opportunities.Add(opportunity);
            _context.SaveChanges();
        }

        public bool OpportunityExists(string description)
        {
            return _context.Opportunities.Any(sl => string.Compare(description, sl.Description,
                StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public IEnumerable<OpportunityDto> GetOpportunities()
        {
            return _context.Opportunities.Select(o => new OpportunityDto
            {
                Id = o.Id,
                Description = o.Description
            });
        }
    }
}