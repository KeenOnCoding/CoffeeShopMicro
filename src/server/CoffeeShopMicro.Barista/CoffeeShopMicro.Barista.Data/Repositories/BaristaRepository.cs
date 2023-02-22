namespace CoffeeShopMicro.Barista.Data.Repositories
{
    using CoffeeShopMicro.Barista.Domain.Entities;
    using CoffeeShopMicro.Barista.Domain.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class BaristaRepository : IBaristaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BaristaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Barista> Add(Barista barista)
        {
            var result =  _dbContext.Baristas.Add(barista);

            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Barista> Get(Guid id)
        {
            var result =  await _dbContext.Baristas
                .AsNoTracking()
                .Include(b => b.CompletedOrders)
                .FirstOrDefaultAsync(b => b.Id == id);
            return result;

        }

        public async Task<Barista> Update(Barista barista)
        {
            var result =  _dbContext.Baristas.Update(barista);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
