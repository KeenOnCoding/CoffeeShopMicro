using MediatR;

namespace CoffeeShopMicro.Tools.Events
{
    public interface IEventBus
    {
        Task<Unit> Publish<TEvent>(Guid streamId, params TEvent[] events) where TEvent : IEvent;
    }
}
