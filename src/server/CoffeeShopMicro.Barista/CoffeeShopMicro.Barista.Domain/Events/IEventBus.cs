namespace CoffeeShopMicro.Barista.Domain.Events
{
    using CoffeeShopMicro.Barista.Domain.Events;
    using MediatR;

    public interface IEventBus
    {
        Task<Unit> Publish<TEvent>(Guid streamId, params TEvent[] events) where TEvent : IEvent;
    }
}
