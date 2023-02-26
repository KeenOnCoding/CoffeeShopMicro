namespace CoffeeShopMicro.Barista.Data.Repositories
{
    using CoffeeShopMicro.Barista.Domain.Entities;
    using CoffeeShopMicro.Barista.Domain.Repositories;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using CoffeeShopMicro.Tools.Optional;

    public class BaristaRepository : IBaristaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BaristaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Add(Barista barista)
        {
            _dbContext.Baristas.Add(barista);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }

        public async Task<Option<Barista>> Get(Guid id) =>
            (await _dbContext
                .Baristas
                //.Include(b => b.CompletedOrders)
                .FirstOrDefaultAsync(b => b.Id == id))
                .SomeNotNull();

        public async Task<Unit> Update(Barista barista)
        {
            _dbContext.Baristas.Update(barista);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
