using System.Threading;
using System.Threading.Tasks;
using ExampleService.Core.Queries.Repository;
using ExampleService.Infrastructure.Data;
using ExampleService.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExampleServiceInfrastructure.Queries.Repository.Handlers
{
    public class EntityAnyQueryHandler<T, TId> : IRequestHandler<EntityAnyQuery<T>, bool> where T : BaseEntity<TId>
    {
        private readonly AppDbContext _dbContext;

        public EntityAnyQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(EntityAnyQuery<T> request, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().AnyAsync(request.Where, cancellationToken).ConfigureAwait(false);
        }
    }
}