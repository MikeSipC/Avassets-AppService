using MediatR;

namespace ExampleService.Core.Commands.Repository
{
    public class DeleteCommand<T> : IRequest<Unit>
    {
        public T Entity { get; set; }
    }
}