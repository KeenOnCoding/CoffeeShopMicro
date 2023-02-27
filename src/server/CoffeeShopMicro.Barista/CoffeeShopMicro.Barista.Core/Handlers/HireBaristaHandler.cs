namespace CoffeeShopMicro.Barista.Core.Handlers
{
    using CoffeeShopMicro.Barista.Core.Commands;
    using CoffeeShopMicro.Barista.Domain.Entities;
    using MediatR;
    using AutoMapper;
    using CoffeeShopMicro.Barista.Domain.Repositories;
    using FluentValidation;
    using CoffeeShopMicro.Tools.Error;
    using CoffeeShopMicro.Tools.Optional;

    public class HireBaristaHandler : BaseHandler<HireBarista>
    {
        private readonly IBaristaRepository _baristaRepository;

        public HireBaristaHandler(
            IValidator<HireBarista> validator,
            IMapper mapper,
            IBaristaRepository baristaRepository) :
            base(validator, mapper)
        {
            _baristaRepository = baristaRepository;
        }

        public override Task<Option<Unit, Error>> Handle(HireBarista command) =>
            BaristaShouldNotExist(command.Id).MapAsync(_ =>
            Persist(Mapper.Map<Barista>(command)));

        private Task<Unit> Persist(Barista barista) =>
            _baristaRepository.Add(barista);

        private async Task<Option<Unit, Error>> BaristaShouldNotExist(Guid id) =>
            (await _baristaRepository.Get(id))
                .SomeWhen(b => !b.HasValue, Error.Conflict($"Barista {id} already exists."))
                .Map(_ => Unit.Value);
    }
}
