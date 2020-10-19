using EloGroupBack.Context.Configuration;
using EloGroupBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EloGroupBack.Context
{
    public class ApplicationContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<StatusLead> StatusLeads { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<LeadOpportunity> LeadOpportunities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LeadConfiguration());
            modelBuilder.ApplyConfiguration(new StatusLeadConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OpportunityConfiguration());
            modelBuilder.ApplyConfiguration(new LeadOpportunityConfiguration());
        }
    }
}