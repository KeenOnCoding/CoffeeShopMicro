
namespace CoffeeShopMicro.Barista.Core.Handlers
{
    using AutoMapper;
    using CoffeeShopMicro.Barista.Core.Commands;
    using CoffeeShopMicro.Barista.Domain.Events;
    using FluentValidation;
    using MediatR;

    public abstract class BaseHandler//<TCommand> //: ICommandHandler<TCommand>where TCommand : ICommand
    {
        //public BaseHandler(
        //    IEventBus eventBus,
        //    IMapper mapper)
        //{
        //    EventBus = eventBus;
        //    Mapper = mapper;
        //}

        //protected IEventBus EventBus { get; }
        //protected IMapper Mapper { get; }
    }
}
