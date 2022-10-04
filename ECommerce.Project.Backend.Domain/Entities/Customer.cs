using ECommerce.Project.Backend.Domain.ComplexTypes;

namespace ECommerce.Project.Backend.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
    }
}
