using System.Threading;
using System.Threading.Tasks;
using ExampleService.Core.Commands.Repository;
using ExampleService.SharedKernel;
using ExampleService.SharedKernel.Interfaces;
using MediatR;

namespace ExampleService.Infrastructure.Commands.Repository.Handlers
{
    public class UpdateCommandHandler<T, TId> : IRequestHandler<UpdateCommand<T>> where T : BaseEntity<TId>
    {
        private readonly IRepository _repository;

        public UpdateCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCommand<T> request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync<T, TId>(request.Entity);
            return Unit.Value;
        }
    }
}