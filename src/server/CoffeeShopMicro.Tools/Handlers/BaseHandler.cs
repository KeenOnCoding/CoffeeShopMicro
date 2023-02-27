using AutoMapper;
using CoffeeShopMicro.Tools.Events;
using CoffeeShopMicro.Tools.Optional;
using FluentValidation;
using MediatR;


namespace CoffeeShopMicro.Tools.Handlers
{
    public abstract class BaseHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        public BaseHandler(
            //IValidator<TCommand> validator,
            //IEventBus eventBus,
            IMapper mapper)
        {
            //Validator = validator ??
            //    throw new InvalidOperationException(
            //        "Tried to instantiate a command handler without a validator." +
            //        "Did you forget to add one?");
            //EventBus = eventBus;
            Mapper = mapper;
        }

        protected IEventBus EventBus { get; }
        protected IMapper Mapper { get; }
        protected IValidator<TCommand> Validator { get; }

        public Task<Option<Unit, CoffeeShopMicro.Tools.Error.Error>> Handle(TCommand command, CancellationToken cancellationToken) =>
            ValidateCommand(command)
                .FlatMapAsync(Handle);

        public abstract Task<Option<Unit, CoffeeShopMicro.Tools.Error.Error>> Handle(TCommand command);

        protected Task<Unit> PublishEvents(Guid streamId, params IEvent[] events) =>
            EventBus.Publish(streamId, events);

        protected Option<TCommand, CoffeeShopMicro.Tools.Error.Error> ValidateCommand(TCommand command)
        {
            var validationResult = Validator.Validate(command);

            return validationResult
                .SomeWhen(
                    r => r.IsValid,
                    r => CoffeeShopMicro.Tools.Error.Error.Validation(r.Errors.Select(e => e.ErrorMessage)))

                // If the validation result is successful, disregard it and simply return the command
                .Map(_ => command);
        }
    }
}
