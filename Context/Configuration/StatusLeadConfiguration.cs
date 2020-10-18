using EloGroupBack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EloGroupBack.Context.Configuration
{
    public class StatusLeadConfiguration : IEntityTypeConfiguration<StatusLead>
    {
        public void Configure(EntityTypeBuilder<StatusLead> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Description)
                .HasMaxLength(120);

            builder.HasMany(x => x.Leads)
                .WithOne(x => x.Status);
        }
    }
}