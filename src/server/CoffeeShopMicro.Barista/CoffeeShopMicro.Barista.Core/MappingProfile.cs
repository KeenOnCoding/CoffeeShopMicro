namespace CoffeeShopMicro.Barista.Core
{
    using AutoMapper;
    using CoffeeShopMicro.Barista.Core.Commands;
    using CoffeeShopMicro.Barista.Domain.Entities;
    using CoffeeShopMicro.Barista.Domain.Views;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HireBarista, Barista>(MemberList.Source);

            CreateMap<Barista, BaristaView>(MemberList.Destination);
        }
    }
}