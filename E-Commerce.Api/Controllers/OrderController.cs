using E_Commerce.Application.Command.OrderCommand.AddOrder;
using E_Commerce.Application.DTOs;
using E_Commerce.Application.Query.OrderQuery.GetAllOrdersQuery;
using E_Commerce.Application.Query.OrderQuery.GetSingleOrderQuery;
using E_Commerce.Domain.Model.OrderAggre;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<OrderController>
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> Get([FromQuery] OrderQuery query)
        {
            var result = await _mediator.Send(new GetAllOrdersQuery(query.pageNumber,5,query.sortColumn,query.searchTerm,query.des));
            return Ok(result);
        }

        // GET api/<OrderController>/5
        [HttpGet("GetSingleOrder/{id}")]
        public async Task<IActionResult> Get(OrderId id)
        {
            var result = await _mediator.Send(new GetSingleOrderQuery(id));
            return Ok(result);
        }


        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDTOs.AddOrderDTO value)
        {
            if (value == null)
            {
                return BadRequest("Order data is required.");
            }

            var result = await _mediator.Send(new AddOrderCommand(value));

            return Ok(result);

        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public record OrderQuery(int pageNumber, string? searchTerm, string? sortColumn,bool des = false);
}
