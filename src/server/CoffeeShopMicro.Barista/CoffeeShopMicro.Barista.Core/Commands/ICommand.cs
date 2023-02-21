namespace CoffeeShopMicro.Barista.Core.Commands
{
    using MediatR;

    public interface ICommand : IRequest
    {
    }

    public interface ICommand<TResult> : IRequest<TResult>
    {
    }
}
