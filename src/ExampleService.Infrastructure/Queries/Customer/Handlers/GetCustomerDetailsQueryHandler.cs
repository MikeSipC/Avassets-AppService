using System.Threading;
using System.Threading.Tasks;
using ExampleService.Core.Queries.Customer;
using MediatR;

namespace ExampleService.Infrastructure.Queries.Customer.Handlers
{
    class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, Core.Entities.Customer>
    {
        /// <summary>
        /// Example to implement usage of a database (inject your db into IRepository)
        /// See ExampleService.SharedKernel.Interfaces.IRepository
        /// </summary>
        //private readonly IRepository _repository;

        //public GetCustomerDetailsQueryHandler(IRepository repository)
        //{
        //    _repository = repository;
        //}

        //public async Task<Core.Entities.Customer> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        //{
        //    var customer = await _repository.Query<Core.Entities.Customer, int>()
        //        .Where(c => c.Id == request.Id)
        //        .SingleOrDefaultAsync(cancellationToken)
        //        .ConfigureAwait(false);

        //    if (customer == null)
        //        throw new Exception($"No customer found for given id: '{request.Id}'. Please provide a valid id.");

        //    return customer;
        //}

        public GetCustomerDetailsQueryHandler()
        {
        }

        public async Task<Core.Entities.Customer> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            // Retrieve customer data from database/repo or any other source you want to retrieve from (see above commented code), this is example fake data

            return new Core.Entities.Customer()
            {
                Id = request.Id,
                FirstName = request.Id > 10 ? "Jack" : "Mike",
                LastName = request.Id > 10 ? "Sparrow" : "Avanade"
            };
        }
    }
}
