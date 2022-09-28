using ECommerce.Project.Backend.Domain.ComplexTypes;

namespace ECommerce.Project.Backend.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; protected set; }
        public string CorporateName { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public string Email { get; protected set; }
        public string EinNumber { get; protected set; }
        public Address Adress { get; protected set; }
        

        protected Supplier()
        {
        }
    }
}