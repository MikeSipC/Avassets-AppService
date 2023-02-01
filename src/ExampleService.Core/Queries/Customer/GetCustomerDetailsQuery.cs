using MediatR;

namespace ExampleService.Core.Queries.Customer
{
    public class GetCustomerDetailsQuery : IRequest<Entities.Customer>
    {
        public int Id { get; set; }
    }
}