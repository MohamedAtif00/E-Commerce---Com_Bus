using E_Commerce.Application.Command.OrderCommand.AddCoupon;
using E_Commerce.Application.Command.OrderCommand.AddOrder;
using E_Commerce.Application.Command.OrderCommand.ChangeStatus;
using E_Commerce.Application.Command.OrderCommand.DeleteCoupon;
using E_Commerce.Application.Command.OrderCommand.UpdateOrder;
using E_Commerce.Application.DTOs;
using E_Commerce.Application.Query.OrderQuery.GetAllCouponQuery;
using E_Commerce.Application.Query.OrderQuery.GetAllOrdersQuery;
using E_Commerce.Application.Query.OrderQuery.GetSingleCouponQuery;
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

        // GET: api/orders/OrderStates
        [HttpGet("OrderStates")]
        public ActionResult<IEnumerable<OrderStateDto>> GetOrderStates()
        {
            var orderStates = Enum.GetValues(typeof(OrderState))
                                  .Cast<OrderState>()
                                  .Select(state => new OrderStateDto(state.ToString(),(int)state))
                                  .ToList();

            return Ok(orderStates);
        }
        [HttpGet("GetAllCoupons")]
        public async Task<IActionResult> GetAllCoupons()
        {
            var result = await _mediator.Send(new GetAllCouponQuery());

            return Ok(result);
        }
        [HttpGet("GetCoupon")]
        public async Task<IActionResult> GetCoupon( string code)
        {
            var result = await _mediator.Send(new GetSingleCouponQuery(code));

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

        [HttpPost("AddCoupon")]
        public async Task<IActionResult> AddCoupon(AddCouponCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }



        [HttpPost("ChangeState")]
        public async Task<IActionResult> ChangeState(ChangeStateDto change)
        {
            var result = await _mediator.Send(new ChangeStateCommand(change.id,change.state));

            return Ok(result);  
        }

        [HttpPost("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand value)
        {
            var result = await _mediator.Send(value);

            return Ok(result);
        }
        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpDelete("DeleteCoupon/{id}")]
        public async Task<IActionResult> DeleteCoupon( Guid id)
        {
            var result = await _mediator.Send(new DeleteCouponCommand(CouponId.Create(id)));

            return Ok(result);
        }
    }
    public record OrderQuery(int pageNumber, string? searchTerm, string? sortColumn,bool des = false);
    public record OrderStateDto(string Name,int Value);
    public record ChangeStateDto(OrderId id,OrderState state);

}
