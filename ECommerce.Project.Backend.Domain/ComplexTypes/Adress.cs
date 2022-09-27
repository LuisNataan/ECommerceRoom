using ECommerce.Project.Backend.Domain.Entities;

namespace ECommerce.Project.Backend.Domain.ComplexTypes
{
    public class Adress : BaseEntity
    {
        public string City { get; protected set; }
        public string State { get; protected set; }
        public string StreetName { get; protected set; }
        public string Number { get; protected set; }
        public string ZipCode { get; protected set; }

        protected Adress()
        {
        }
    }
}
