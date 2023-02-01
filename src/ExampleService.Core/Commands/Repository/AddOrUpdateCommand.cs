using MediatR;

namespace ExampleService.Core.Commands.Repository
{
    public class AddOrUpdateCommand<T> : IRequest<T>
    {
        public T Entity { get; set; }
    }
}