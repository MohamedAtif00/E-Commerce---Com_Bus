using Ardalis.Result.AspNetCore;
using E_Commerce.Application.Command.CategoryCommand.AddCategory;
using E_Commerce.Application.Command.CategoryCommand.AddChildCategory;
using E_Commerce.Application.Command.CategoryCommand.DeleteCategory;
using E_Commerce.Application.Command.CategoryCommand.MoveCategory;
using E_Commerce.Application.Query.AdministrationQuery.CategryEarningChart;
using E_Commerce.Application.Query.CategoryQuery.GetAllCategoriesQuery;
using E_Commerce.Application.Query.CategoryQuery.GetAllChildsCategoryQuery;
using E_Commerce.Application.Query.CategoryQuery.GetSingleCategoryQuery;
using E_Commerce.Domain.Model.CategoryAggre;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());

            return Ok(result);
        }
        [HttpGet("GetAllChildsCategories")]
        public async Task<IActionResult> GetAllChildsCategories()
        {
            var result = await _mediator.Send(new GetAllChildsCategoryQuery());

            return Ok(result);
        }

        [HttpGet("GetCategoriesProfits/{days}")]
        public async Task<IActionResult> GetCategoriesProfits(int days)
        {
            var result = await _mediator.Send(new GetCategoryEarningChartQuery(days));

            return Ok(result);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(CategoryId id)
        {
            var result = await _mediator.Send(new GetSingleCategoryQuery(id));

            return Ok(result);
        }

        // POST api/<CategoryController>
        [HttpPost("AddCategory")]
        public async Task<IActionResult> Post([FromBody] AddCategoryCommand value)
        {
            var result = await _mediator.Send(value);
            return Ok(result);
        }

        [HttpPost("AddChildCategory")]
        public async Task<IActionResult> AddChildCategory([FromBody] AddChildCategoryCommand value)
        {
            var result = await _mediator.Send(value);

            return Ok(result);
        }

        [HttpPost("MoveCategory")]
        public async Task<IActionResult> MoveCategory([FromBody] MoveCategoryCommand value)
        {
            var result = await _mediator.Send(value);

            return Ok(result);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(CategoryId id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(id));

            return Ok(result);
        }
    }
}
