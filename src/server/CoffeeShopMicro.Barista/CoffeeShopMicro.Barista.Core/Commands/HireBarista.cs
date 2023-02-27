
namespace CoffeeShopMicro.Barista.Core.Commands
{
    using CoffeeShopMicro.Barista.Core.Handlers;

    public class HireBarista : ICommand
    {
        public Guid Id { get; set; }

        public string ShortName { get; set; }
    }
}
