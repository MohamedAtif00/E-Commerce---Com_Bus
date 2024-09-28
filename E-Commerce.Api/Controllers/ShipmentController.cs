using Ardalis.Result.AspNetCore;
using E_Commerce.Application.Command.ShipmentInformationCommand.AddPickupAddress;
using E_Commerce.Application.Command.ShipmentInformationCommand.AddShipmentInformation;
using E_Commerce.Application.Command.ShipmentInformationCommand.AddShipmentToken;
using E_Commerce.Application.Query.ShipmentInformation.GetAllPickupAddress;
using E_Commerce.Domain.Model.ShipmentInformationAggre;
using E_Commerce.Infrastructure.Migrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShipmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
 
        //}

        [HttpPost]
        public async Task<IActionResult> AddShipmentInformation(AddShipmentInformationRequest request)
        {
            var shipmentInformation = await _mediator.Send(new AddShipmentInformationCommand(request.email,request.fullName,request.token));

            return Ok(shipmentInformation);
        }


        [HttpPost("AddPickupAddress")]
        public async Task<IActionResult> AddPickupAddress(AddPickupAddressDto address)
        {
            var result = await _mediator.Send(new AddPickupAddressCommand(address));
            return Ok(result);
        }

        [HttpGet("GetAllPickupAddress")]
        public async Task<IActionResult> GetAllPickupAddress()
        {
            var result = await _mediator.Send(new GetAllPickupAddressQuery());

            return Ok(result);
        }

    }

    public record AddShipmentInformationRequest(string email,string fullName,string token);
    public record SetToken(string token);
}
