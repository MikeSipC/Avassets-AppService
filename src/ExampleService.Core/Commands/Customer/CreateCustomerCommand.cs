using MediatR;

namespace ExampleService.Core.Commands.Customer
{
    public class CreateCustomerCommand : IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}