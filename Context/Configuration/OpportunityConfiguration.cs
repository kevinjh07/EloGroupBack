using EloGroupBack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EloGroupBack.Context.Configuration
{
    public class OpportunityConfiguration : IEntityTypeConfiguration<Opportunity>
    {
        public void Configure(EntityTypeBuilder<Opportunity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Lead)
                .WithMany(x => x.Opportunities);
        }
    }
}