namespace CoffeeShopMicro.Barista.Domain.Repositories
{
    using MediatR;
    using CoffeeShopMicro.Barista.Domain.Entities;

    public interface IBaristaRepository
    {
        Task<Barista> Get(Guid id);

        Task<Barista> Update(Barista barista);

        Task<Barista> Add(Barista barista);
    }
}
