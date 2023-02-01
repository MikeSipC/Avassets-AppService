using System.Threading;
using System.Threading.Tasks;
using ExampleService.Core.Queries.Repository;
using ExampleService.Infrastructure.Data;
using ExampleService.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExampleServiceInfrastructure.Queries.Repository.Handlers
{
    public class EntityQueryHandler<T, TId> : IRequestHandler<EntityQuery<T>, T> where T : BaseEntity<TId>
    {
        private readonly AppDbContext _dbContext;

        public EntityQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Handle(EntityQuery<T> request, CancellationToken cancellationToken)
        {
            var onlyOneParameter = (request?.Id != null) ^ (request?.SingleOrDefault != null) ^
                                   (request?.FirstOrDefault != null) ^ (request?.Single != null) ^
                                   (request?.First != null);
            if (!onlyOneParameter)
                throw new RepositoryException("Incorrect parameters provided");

            T rv = null;
            if (request?.Id != null)
                rv = await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id.Equals(request.Id), cancellationToken);
            if (request?.SingleOrDefault != null)
                rv = await _dbContext.Set<T>().SingleOrDefaultAsync(request?.SingleOrDefault, cancellationToken);
            if (request?.FirstOrDefault != null)
                rv = await _dbContext.Set<T>().FirstOrDefaultAsync(request?.FirstOrDefault, cancellationToken);
            if (request?.Single != null)
                rv = await _dbContext.Set<T>().SingleAsync(request?.Single, cancellationToken);
            if (request?.First != null)
                rv = await _dbContext.Set<T>().FirstAsync(request?.First, cancellationToken);
            return rv;
        }
    }
}