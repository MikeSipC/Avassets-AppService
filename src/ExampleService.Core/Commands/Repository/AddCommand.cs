using MediatR;

namespace ExampleService.Core.Commands.Repository
{
    public class AddCommand<T> : IRequest<T>
    {
        public T Entity { get; set; }
    }
}