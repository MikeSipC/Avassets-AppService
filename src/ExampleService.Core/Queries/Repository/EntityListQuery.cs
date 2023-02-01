using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MediatR;

namespace ExampleService.Core.Queries.Repository
{
    public class EntityListQuery<T> : IRequest<List<T>>
    {
        public Expression<Func<T, bool>> Where { get; set; }
    }
}