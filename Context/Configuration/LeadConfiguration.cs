using EloGroupBack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EloGroupBack.Context.Configuration
{
    public class LeadConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property(x => x.CustomerName)
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(x => x.CustomerPhone)
                .HasMaxLength(12)
                .IsRequired();

            builder.Property(x => x.CustomerEmail)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.StatusId)
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Lead)
                .HasForeignKey<Customer>(x => x.LeadId);
        }
    }
}