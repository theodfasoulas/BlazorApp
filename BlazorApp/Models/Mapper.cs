using AutoMapper;
using BlazorApp.Shared;
using BlazorApp.Shared.Models;

namespace BlazorApp.Models
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDbModel, CustomerViewModel>();
            CreateMap<CustomerViewModel, CustomerDbModel>();
               //.ForMember(x => x.Id, opt => opt.I());
            CreateMap<PagedList<CustomerDbModel>, CustomerList>();
        }
    }
}
