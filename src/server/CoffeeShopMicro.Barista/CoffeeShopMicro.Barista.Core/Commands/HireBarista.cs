
namespace CoffeeShopMicro.Barista.Core.Commands
{
    using CoffeeShopMicro.Tools.Handlers;

    public class HireBarista : ICommand
    {
        public Guid Id { get; set; }

        public string ShortName { get; set; }
    }
}
