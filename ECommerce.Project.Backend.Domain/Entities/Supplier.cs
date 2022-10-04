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

        public Supplier(string name, string corporateName, string phone, string email, string einNumber, Address address)
        {
            this.Name = name;
            this.CorporateName = corporateName;
            this.PhoneNumber = phone;
            this.Email = email;
            this.EinNumber = einNumber;
            this.Adress = address;
        }
    }
}