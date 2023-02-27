namespace CoffeeShopMicro.Tools.Resources
{
    public class ResourceContainer<TResouce> : Resource
        where TResouce : Resource
    {
        public IEnumerable<TResouce> Items { get; set; }
    }
}
