using MediatR;

namespace ExampleService.Core.Commands.Repository
{
    public class UpdateCommand<T> : IRequest<Unit>
    {
        public T Entity { get; set; }
    }
}