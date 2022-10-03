using AutoMapper;
using ECommerce.Project.Backend.Domain.Entities;
using ECommerce.Project.Backend.Web.Models.Insert;

namespace ECommerce.Project.Backend.Web.Utils
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Customer, CustomerInsertViewModel>()
                .ForMember(ad => ad.Address, src =>
                src.MapFrom(opt => opt.Address));
        }
    }
}
