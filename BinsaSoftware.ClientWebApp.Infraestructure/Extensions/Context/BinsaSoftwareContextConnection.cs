using BinsaSoftware.ClientWebApp.Domain;
using BinsaSoftware.ClientWebApp.Infraestructure.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BinsaSoftware.ClientWebApp.Infraestructure.Extensions.Context
{
    public class BinsaSoftwareContextConnection : DbContext
    {
        public BinsaSoftwareContextConnection(DbContextOptions<BinsaSoftwareContextConnection> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerContactConfiguration()); 
        }

        public virtual DbSet<ClientEntity> Clients { get; set; }
        public virtual DbSet<CustomerContactEntity> CustomerContacts { get; set; } 
    }
}
