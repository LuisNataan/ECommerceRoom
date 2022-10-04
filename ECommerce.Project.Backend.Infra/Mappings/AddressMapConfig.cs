using ECommerce.Project.Backend.Domain.ComplexTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Project.Backend.Infra.Mappings
{
    public class AddressMapConfig : IEntityTypeConfiguration<Address>
    {

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            
            builder.Property(a => a.City)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(a => a.State)
                .IsFixedLength()
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(a => a.StreetName)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(a => a.Number)
                .HasMaxLength(99999)
                .IsRequired();

            builder.Property(a => a.ZipCode)
                .IsFixedLength()
                .HasMaxLength(6)
                .IsRequired();
        }
    }
}
