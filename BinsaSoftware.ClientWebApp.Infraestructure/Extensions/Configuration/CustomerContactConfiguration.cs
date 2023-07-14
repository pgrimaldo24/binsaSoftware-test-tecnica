using BinsaSoftware.ClientWebApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BinsaSoftware.ClientWebApp.Infraestructure.Extensions.Configuration
{
    public class CustomerContactConfiguration : IEntityTypeConfiguration<CustomerContactEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerContactEntity> entity)
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK__Customer__DB43864AD2285632");

            entity.ToTable("CustomerContact");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValueSql("('Administrator')");
            entity.Property(e => e.Email).HasMaxLength(40);
            entity.Property(e => e.Nombre).HasMaxLength(40);
            entity.Property(e => e.Telefono).HasMaxLength(40);

          
        }
    }
}
