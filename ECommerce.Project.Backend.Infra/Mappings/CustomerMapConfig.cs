using ECommerce.Project.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Project.Backend.Infra.Mappings
{
    internal class CustomerMapConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            
            builder.Property(c => c.Name)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(c => c.PhoneNumber)
                .IsFixedLength()
                .HasMaxLength(11)
                .IsRequired();
        }
    }
}
