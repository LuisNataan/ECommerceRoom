using ECommerce.Project.Backend.Domain.ComplexTypes;

namespace ECommerce.Project.Backend.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public Address Address { get; protected set; }

        protected Customer()
        {
        }
    }
}
