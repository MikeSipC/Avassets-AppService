using AutoMapper;

namespace ExampleService.Customer.Api.Mapping
{
    public class Entity2 : Profile
    {
        public Entity2()
        {
            CreateMap<int, string>();
            
        }

    }
}