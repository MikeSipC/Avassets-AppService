using System.Threading;
using System.Threading.Tasks;
using ExampleService.Core.Commands.Repository;
using ExampleService.Infrastructure.Data;
using MediatR;

namespace ExampleService.Infrastructure.Commands.Repository.Handlers
{
    public class ForceSaveChangesCommandHandler : IRequestHandler<ForceSaveChangesCommand>
    {
        private readonly AppDbContext _dbContext;

        public ForceSaveChangesCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ForceSaveChangesCommand request, CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}