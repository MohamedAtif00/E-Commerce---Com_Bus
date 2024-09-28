using E_Commerce.Application.Command.ContactCommand.AddContact;
using E_Commerce.Application.Query.ContactQuery.GetAllContact;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllContactsQuery());
            return Ok(result);
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<IActionResult>  Post(ContactDto value)
        {
            var result = await  _mediator.Send(new AddContactCommand(value.email,value.name,value.subject,value.body));
            return Ok(result);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public void Put()
        {
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public record ContactDto(string email,string name,string subject,string body);
}
