

namespace CoffeeShopMicro.Tools.Handlers
{
    using CoffeeShopMicro.Tools.Optional;
    using MediatR;

    public interface ICommandHandler<in TCommand> :
        IRequestHandler<TCommand, Option<Unit, CoffeeShopMicro.Tools.Error.Error>>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, Option<TResult, Error.Error>>
        where TCommand : ICommand<TResult>
    {
    }
}
