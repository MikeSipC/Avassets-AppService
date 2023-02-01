using System.Threading;
using System.Threading.Tasks;
using ExampleService.Core.Commands.Repository;
using ExampleService.SharedKernel;
using ExampleService.SharedKernel.Interfaces;
using MediatR;

namespace ExampleService.Infrastructure.Commands.Repository.Handlers
{
    public class DeleteRangeCommandHandler<T, TId> : IRequestHandler<DeleteRangeCommand<T>> where T : BaseEntity<TId>
    {
        private readonly IRepository _repository;

        public DeleteRangeCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteRangeCommand<T> request, CancellationToken cancellationToken)
        {
            await _repository.DeleteRangeAsync<T, TId>(request.Entities);
            return Unit.Value;
        }
    }
}