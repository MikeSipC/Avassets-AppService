using System.Threading;
using System.Threading.Tasks;
using ExampleService.Core.Commands.Repository;
using ExampleService.SharedKernel;
using ExampleService.SharedKernel.Interfaces;
using MediatR;

namespace ExampleService.Infrastructure.Commands.Repository.Handlers
{
    public class DeleteCommandHandler<T, TId> : IRequestHandler<DeleteCommand<T>> where T : BaseEntity<TId>
    {
        private readonly IRepository _repository;

        public DeleteCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync<T, TId>(request.Entity);
            return Unit.Value;
        }
    }
}