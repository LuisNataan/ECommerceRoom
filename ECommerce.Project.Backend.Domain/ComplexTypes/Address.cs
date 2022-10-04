using ECommerce.Project.Backend.Domain.Entities;

namespace ECommerce.Project.Backend.Domain.ComplexTypes
{
    public class Address : BaseEntity
    {
        public string City { get; set; }
        public string State { get; set; }
        public string StreetName { get; set; }
        public string Number { get; set; }
        public string ZipCode { get; set; }
    }
}
