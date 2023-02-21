namespace CoffeeShopMicro.Barista.Domain.Views
{
    public class BaristaView
    {
        public Guid Id { get; set; }

        public string ShortName { get; set; }

        public IList<ToGoOrderView> CompletedOrders { get; set; }
    }
}
