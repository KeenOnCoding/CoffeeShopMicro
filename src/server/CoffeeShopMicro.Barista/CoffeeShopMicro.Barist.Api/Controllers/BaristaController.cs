using AutoMapper;
using CoffeeShopMicro.Barista.Core.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoffeeShopMicro.Barista.Api.Controllers
{
    [Route("[controller]")]
    public class BaristaController : Controller
    {
        readonly IMapper _mapper;
        readonly IMediator _mediator;

        public BaristaController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException();
            _mediator = mediator ?? throw new ArgumentNullException();
        }

        [HttpPost(Name = nameof(HireBarista))]
        public IActionResult HireBarista([FromBody] HireBarista command)
        {
            var result =  _mediator.Send(command);

            if (result.IsCompletedSuccessfully)
            {
                return Ok();
            }
            return BadRequest();
        }

       
    }
}
