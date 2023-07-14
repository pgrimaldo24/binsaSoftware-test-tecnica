using BinsaSoftware.ClientWebApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BinsaSoftware.ClientWebApp.Infraestructure.Extensions.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> entity)
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Client__E67E1A24C16B3EC3");

            entity.ToTable("Client");

            entity.Property(e => e.CodigoPostal).HasMaxLength(40);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('Administrator')");
            entity.Property(e => e.Domicilio).HasMaxLength(40);
            entity.Property(e => e.Nombre).HasMaxLength(40);
            entity.Property(e => e.Poblacion).HasMaxLength(40);
        }
    }
}
