﻿using Marten;
using MediatR;

namespace CoffeeShopMicro.Tools.Events
{
    public class EventBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly IDocumentSession _session;

        public EventBus(IMediator mediator, IDocumentSession session)
        {
            _mediator = mediator;
            _session = session;
        }

        public async Task<Unit> Publish<TEvent>(Guid streamId, params TEvent[] events)
            where TEvent : IEvent
        {
            foreach (var @event in events)
            {
                // For some unknown reason if we use the Append overload that takes a collection of events they will not be published
                // (ask me how I know :)
                _session.Events.Append(streamId, @event);
                await _mediator.Publish(@event);
            }

            await _session.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
