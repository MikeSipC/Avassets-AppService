using System;
using System.Linq.Expressions;
using MediatR;

namespace ExampleService.Core.Queries.Repository
{
    public class EntityQuery<T> : IRequest<T>
    {
        public int? Id { get; set; }
        public Expression<Func<T, bool>> SingleOrDefault { get; set; }
        public Expression<Func<T, bool>> FirstOrDefault { get; set; }
        public Expression<Func<T, bool>> Single { get; set; }
        public Expression<Func<T, bool>> First { get; set; }
    }
}