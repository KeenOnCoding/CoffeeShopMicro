namespace CoffeeShopMicro.Barista.Core.Queries
{
    using MediatR;

    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
