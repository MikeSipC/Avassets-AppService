using System.Collections.Generic;
using MediatR;

namespace ExampleService.Core.Commands.Repository
{
    public class DeleteRangeCommand<T> : IRequest<Unit>
    {
        public IList<T> Entities { get; set; }
    }
}