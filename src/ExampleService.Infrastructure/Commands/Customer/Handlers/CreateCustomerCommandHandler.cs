using System.Threading;
using System.Threading.Tasks;
using ExampleService.Core.Commands.Repository;
using MediatR;

namespace ExampleService.Core.Commands.Customer.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
    {
        private readonly IMediator _mediator;

        public CreateCustomerCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ideally COMMANDS should not return anything, so Unit.Value since void is not valid
        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // new
            var customer = new Entities.Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var result = await _mediator.Send(new AddOrUpdateCommand<Entities.Customer> { Entity = customer });

            return Unit.Value;
        }
    }
}