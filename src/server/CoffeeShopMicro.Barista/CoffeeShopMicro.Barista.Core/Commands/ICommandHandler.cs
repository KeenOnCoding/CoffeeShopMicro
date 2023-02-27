

namespace CoffeeShopMicro.Barista.Core.Handlers
{
    using CoffeeShopMicro.Tools.Optional;
    using MediatR;

    public interface ICommandHandler<in TCommand> :
        IRequestHandler<TCommand, Option<Unit, CoffeeShopMicro.Tools.Error.Error>>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, Option<TResult, CoffeeShopMicro.Tools.Error.Error>>
        where TCommand : ICommand<TResult>
    {
    }
}
