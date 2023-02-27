namespace CoffeeShopMicro.Barista.Core.Handlers
{
    using AutoMapper;
    using CoffeeShopMicro.Tools.Optional;
    using FluentValidation;
    using MediatR;
    using CoffeeShopMicro.Tools.Error;

    public abstract class BaseHandler<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        public BaseHandler(
            IValidator<TCommand> validator,
            IMapper mapper)
        {
            Validator = validator ??
                throw new InvalidOperationException(
                   "Tried to instantiate a command handler without a validator." +
                   "Did you forget to add one?");
            Mapper = mapper;
        }

        protected IMapper Mapper { get; }
        protected IValidator<TCommand> Validator { get; }

        public Task<Option<Unit, Error>> Handle(TCommand command, CancellationToken cancellationToken) =>
            ValidateCommand(command)
                .FlatMapAsync(Handle);

        public abstract Task<Option<Unit,Error>> Handle(TCommand command);

        protected Option<TCommand, Error> ValidateCommand(TCommand command)
        {
            var validationResult = Validator.Validate(command);

            return validationResult
                .SomeWhen(
                    r => r.IsValid,
                    r => Error.Validation(r.Errors.Select(e => e.ErrorMessage)))

                .Map(_ => command);
        }
    }
}
