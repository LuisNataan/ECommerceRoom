using AutoMapper;
using ECommerce.Project.Backend.Domain.ComplexTypes;
using ECommerce.Project.Backend.Domain.Entities;
using ECommerce.Project.Backend.Domain.Models.Insert;
using ECommerce.Project.Backend.Web.Models.Insert;

namespace ECommerce.Project.Backend.Web.Utils
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Address, AddressInsertViewModel>().ReverseMap();

            CreateMap<CustomerInsertViewModel, Customer>()
                .ForMember(ad => ad.Address, src =>
                src.MapFrom(opt => opt.AddressViewModel));

            CreateMap<SupplierInsertViewModel, Supplier>()
                .ForMember(ad => ad.Address, src =>
                src.MapFrom(opt => opt.AddressViewModel));
        }
    }
}
