using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExampleService.Core.Queries.Repository;
using ExampleService.Infrastructure.Data;
using ExampleService.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExampleServiceInfrastructure.Queries.Repository.Handlers
{
    public class EntityListQueryHandler<T, TId> : IRequestHandler<EntityListQuery<T>, List<T>> where T : BaseEntity<TId>
    {
        private readonly AppDbContext _dbContext;

        public EntityListQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<T>> Handle(EntityListQuery<T> request, CancellationToken cancellationToken)
        {
            if (request.Where == null)
                return await _dbContext.Set<T>().ToListAsync(cancellationToken);
            return await _dbContext.Set<T>().AsQueryable().Where(request.Where).ToListAsync(cancellationToken);
        }
    }
}