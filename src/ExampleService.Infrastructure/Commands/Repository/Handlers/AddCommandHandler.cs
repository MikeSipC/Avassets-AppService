using System.Threading;
using System.Threading.Tasks;
using ExampleService.Core.Commands.Repository;
using ExampleService.SharedKernel;
using ExampleService.SharedKernel.Interfaces;
using MediatR;

namespace ExampleService.Infrastructure.Commands.Repository.Handlers
{
    public class AddCommandHandler<T, TId> : IRequestHandler<AddCommand<T>, T> where T : BaseEntity<TId>
    {
        private readonly IRepository _repository;

        public AddCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<T> Handle(AddCommand<T> request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync<T, TId>(request.Entity);
        }
    }
}