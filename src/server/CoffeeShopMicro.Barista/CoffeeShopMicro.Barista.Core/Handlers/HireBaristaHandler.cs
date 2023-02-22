namespace CoffeeShopMicro.Barista.Core.Handlers
{
    using AutoMapper;
    using CoffeeShopMicro.Barista.Core.Commands;
    using CoffeeShopMicro.Barista.Domain.Events;
    using CoffeeShopMicro.Barista.Domain.Entities;
    using FluentValidation;
    using MediatR;
    using CoffeeShopMicro.Barista.Domain.Repositories;
    using System.Data;
    using System.ComponentModel.Design;
    using System.Threading;
    using System.Security.Cryptography.X509Certificates;
    using CoffeeShopMicro.Barista.Data;

    public class HireBaristaHandler : ICommandHandler<HireBarista>
    {
        private readonly ApplicationDbContext _baristaRepository;
        public HireBaristaHandler(
            ApplicationDbContext baristaRepository)
        {
            _baristaRepository = baristaRepository;
        }




        public async Task<Unit> Handle(HireBarista command, CancellationToken cancellationToken)
        {
            //var result = await _baristaRepository.Get(command.Id);


                var val =  _baristaRepository.Add(new Barista { ShortName  = command.ShortName });

            await _baristaRepository.SaveChangesAsync();
            return Unit.Value;

        }
    }
}
