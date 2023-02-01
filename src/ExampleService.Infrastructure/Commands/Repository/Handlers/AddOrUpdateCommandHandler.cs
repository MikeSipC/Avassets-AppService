using System.Threading;
using System.Threading.Tasks;
using ExampleService.Core.Commands.Repository;
using ExampleService.SharedKernel;
using ExampleService.SharedKernel.Interfaces;
using MediatR;

namespace ExampleService.Infrastructure.Commands.Repository.Handlers
{
    public class AddOrUpdateCommandHandler<T, TId> : IRequestHandler<AddOrUpdateCommand<T>, T> where T : BaseEntity<TId>
    {
        private readonly IRepository _repository;

        public AddOrUpdateCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<T> Handle(AddOrUpdateCommand<T> request, CancellationToken cancellationToken)
        {
            return await _repository.AddOrUpdateAsync<T, TId>(request.Entity);
        }
    }
}