namespace CoffeeShopMicro.Barista.Domain.Repositories
{
    using MediatR;
    using CoffeeShopMicro.Barista.Domain.Entities;
    using System;
    using CoffeeShopMicro.Tools.Optional;

    public interface IBaristaRepository
    {
        Task<Option<Barista>> Get(Guid id);

        Task<Unit> Update(Barista barista);

        Task<Unit> Add(Barista barista);
    }
}
