namespace CoffeeShopMicro.Barista.Data
{
    using Microsoft.EntityFrameworkCore;
    using CoffeeShopMicro.Barista.Domain.Entities;

    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<Barista> Baristas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<ToGoOrderMenuItem>()
                .HasOne(x => x.Order)
                .WithMany(o => o.OrderedItems)
                .HasForeignKey(x => x.OrderId);

            base.OnModelCreating(builder);
        }
    }
}