using System;
using System.Linq.Expressions;
using MediatR;

namespace ExampleService.Core.Queries.Repository
{
    public class EntityCountQuery<T> : IRequest<int>
    {
        public Expression<Func<T, bool>> Where { get; set; }
    }
}