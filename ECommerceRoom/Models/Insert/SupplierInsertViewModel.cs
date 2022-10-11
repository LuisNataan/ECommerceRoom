
using ECommerce.Project.Backend.Web.Models.Insert;

namespace ECommerce.Project.Backend.Domain.Models.Insert
{
    public class SupplierInsertViewModel
    {
        public string Name { get; set; }
        public string CorporateName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string EinNumber { get; set; }
        public AddressInsertViewModel AddressViewModel { get; set; }
    }
}
