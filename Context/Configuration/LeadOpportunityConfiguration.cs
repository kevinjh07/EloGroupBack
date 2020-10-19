using EloGroupBack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EloGroupBack.Context.Configuration
{
    public class LeadOpportunityConfiguration : IEntityTypeConfiguration<LeadOpportunity>
    {
        public void Configure(EntityTypeBuilder<LeadOpportunity> builder)
        {
            builder.HasKey(lo => new {lo.LeadId, lo.OpportunityId});

            builder.HasOne(o => o.Lead)
                .WithMany(l => l.LeadOpportunities)
                .HasForeignKey(lo => lo.LeadId);

            builder.HasOne(lo => lo.Opportunity)
                .WithMany(c => c.LeadOpportunities)
                .HasForeignKey(lo => lo.OpportunityId);
        }
    }
}