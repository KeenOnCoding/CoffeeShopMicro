namespace CoffeeShopMicro.Barista.Domain.Views
{
    using CoffeeShopMicro.Barista.Domain.Entities;

    public class MenuItemView
    {
        public MenuItemView()
        {
        }

        public MenuItemView(MenuItem item)
        {
            Number = item.Number;
            Description = item.Description;
            Price = item.Price;
        }

        public int Number { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
