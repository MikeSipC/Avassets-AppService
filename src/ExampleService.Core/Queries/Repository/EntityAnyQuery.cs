using System;
using System.Linq.Expressions;
using MediatR;

namespace ExampleService.Core.Queries.Repository
{
    public class EntityAnyQuery<T> : IRequest<bool>
    {
        public Expression<Func<T, bool>> Where { get; set; }
    }
}