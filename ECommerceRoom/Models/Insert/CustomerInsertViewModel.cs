namespace ECommerce.Project.Backend.Web.Models.Insert
{
    public class CustomerInsertViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public AddressInsertViewModel AddressViewModel { get; set; }
    }
}
