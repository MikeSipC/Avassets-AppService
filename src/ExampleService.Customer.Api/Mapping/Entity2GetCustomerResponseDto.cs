using AutoMapper;
using ExampleService.Customer.Api.Models.Requests;

namespace ExampleService.Customer.Api.Mapping
{
    public class Entity2GetCustomerResponseDto : Profile
    {
        public Entity2GetCustomerResponseDto()
        {
            CreateMap<Core.Entities.Customer, GetCustomerResponseDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}" ));
        }

    }
}