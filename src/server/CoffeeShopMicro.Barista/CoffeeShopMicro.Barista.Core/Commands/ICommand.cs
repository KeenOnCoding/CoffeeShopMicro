using CoffeeShopMicro.Tools.Optional;
using MediatR;


namespace CoffeeShopMicro.Barista.Core.Handlers
{
    public interface ICommand : IRequest<Option<Unit, CoffeeShopMicro.Tools.Error.Error>>
    {
    }

    public interface ICommand<TResult> : IRequest<Option<TResult, CoffeeShopMicro.Tools.Error.Error>>
    {
    }
}
