namespace CoffeeShopMicro.Barista.Core.Commands
{
    public class HireBarista : ICommand
    {
        public Guid Id { get; set; }

        public string ShortName { get; set; }
    }
}
