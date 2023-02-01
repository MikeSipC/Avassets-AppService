using System.Threading;
using System.Threading.Tasks;
using ExampleService.Core.Queries.Repository;
using ExampleService.Infrastructure.Data;
using ExampleService.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExampleServiceInfrastructure.Queries.Repository.Handlers
{
    public class EntityCountQueryHandler<T, TId> : IRequestHandler<EntityCountQuery<T>, int> where T : BaseEntity<TId>
    {
        private readonly AppDbContext _dbContext;

        public EntityCountQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(EntityCountQuery<T> request, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<T>().CountAsync(request.Where, cancellationToken);
        }
    }
}