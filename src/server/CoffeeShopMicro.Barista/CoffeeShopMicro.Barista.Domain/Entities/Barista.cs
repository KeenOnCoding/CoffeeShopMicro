namespace CoffeeShopMicro.Barista.Domain.Entities
{
    public class Barista
    {
        public Guid Id { get; set; }

        public string ShortName { get; set; }

        public ICollection<ToGoOrder> CompletedOrders { get; set; }
    }
}
