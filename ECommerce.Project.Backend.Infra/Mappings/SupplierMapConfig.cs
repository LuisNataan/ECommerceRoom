using ECommerce.Project.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Project.Backend.Infra.Mappings
{
    public class SupplierMapConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.Property(s => s.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.CorporateName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(s => s.EinNumber)
                .IsFixedLength()
                .HasMaxLength(9)
                .IsRequired();

            builder.Property(s => s.PhoneNumber)
                .IsFixedLength()
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(s => s.Email)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
