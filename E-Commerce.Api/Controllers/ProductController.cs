using E_Commerce.Application.Query.ProductQuery.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using E_Commerce.Domain.Model.ProductAggre;
using E_Commerce.Application.Command.ProductCommands.AddProductCommand;
using E_Commerce.Application.DTOs;
using E_Commerce.Application.Command.ProductCommands.AddMasterImageCommand;
using E_Commerce.Application.Command.ProductCommands.AddProductImagesCommand;
using E_Commerce.Application.Query.ProductQuery.GetProductImage;
using E_Commerce.Application.Helper;
using E_Commerce.Application.Query.ProductQuery.GetSingleProduct;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/<ProductController>
        [HttpGet("GetAll/{number}")]
        public async Task<IActionResult> Get(int number)
        {
            var result = await _mediator.Send(new GetAllProductsQuery(number,8));

            return Ok(result);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(ProductId id)
        {
            var result = await _mediator.Send(new GetSingleProductQuery(id));
            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTOs.CreateProductDTO value)
        {

            var result = await _mediator.Send(new AddProductCommand(value));

            return Ok(result);
        }

        [HttpPost("AddMasterImage")]
        public async Task<IActionResult> AddMasterImage([FromForm] ProductDTOs.CreateProductImageDTO value)
        {
            var result = await _mediator.Send(new AddMasterImageCommand(value.ProductId,value.file,_webHostEnvironment.WebRootPath,"Upload/ProductImage"));

            return Ok(result);
        }

        [HttpPost("AddProductImages")]
        public async Task<IActionResult> AddProductImages([FromForm] List<IFormFile> files,[FromForm] ProductId productId)
        {
            var result = await _mediator.Send(new AddProductImagesCommand(productId,files,_webHostEnvironment.WebRootPath,"Upload/ProductImages"));

            return Ok(result);
        }

        [HttpGet("GetProductMasterImage/{id}")]
        public async Task<IActionResult> GetProductMasterImage(ProductId id)
        {
            var result = await _mediator.Send(new GetProductMasterImageQuery(id));

            var file = ImageHelper.GetImageFilePath(result.Value, _webHostEnvironment.WebRootPath);

            if (System.IO.File.Exists(file))
            {
                // Read the file into a byte array
                byte[] imageData = System.IO.File.ReadAllBytes(file);


                // Return the image data along with appropriate content type
                return File(imageData, "image/jpeg");
            }


            return NotFound();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(ProductId id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(ProductId id)
        {
        }
    }
}
