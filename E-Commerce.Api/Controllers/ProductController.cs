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
using E_Commerce.Application.Query.ProductQuery.GetProductImageQuery;
using E_Commerce.Application.Command.ProductCommands.UpdateProductDetails;
using E_Commerce.Application.Command.ProductCommands.DeleteMasterImageCommand;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Application.Command.ProductCommands.AddReviewCommand;
using E_Commerce.Application.Command.ProductCommands.MakeProductSpecialCommand;
using E_Commerce.Domain.Model.AdministrationAggre;
using E_Commerce.Application.Query.ProductQuery.GetSpecialProducts;
using E_Commerce.Application.Query.ProductQuery.GetAllReviews;

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
        //[HttpGet("GetAll/{number}/{searchTerm?}")]
        //public async Task<IActionResult> Get(int number,string? searchTerm)
        //{
        //    var result = await _mediator.Send(new GetAllProductsQuery(number,8,searchTerm));

        //    return Ok(result);
        //}

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get([FromQuery] ProductQuery query)
        {
            var result = await _mediator.Send(new GetAllProductsQuery(query.pageNumber,
                                                                      8,
                                                                      query.sortColumn,
                                                                      query.searchTerm,
                                                                      query.startPrice,
                                                                      query.endPrice,
                                                                      query.totalReviews,
                                                                      query.categoryIds,
                                                                      query.asend

                                                                      ));

            return Ok(result);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(ProductId id)
        {
            var result = await _mediator.Send(new GetSingleProductQuery(id));
            return Ok(result);
        }

        [HttpGet("GetSpecialProducts/{id}")]
        public async Task<IActionResult> GetSpecialProducts(string id)
        {
            var result = await _mediator.Send(new GetSpecialProductsQuery(GroupId.Create(Guid.Parse(id))));

           return Ok(result);
        }
        [HttpGet("GetAllReviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            var result = await _mediator.Send(new GetAllReviewsQuery());

            return Ok(result);
        }

        [HttpGet("MakeSpecial/{productId:guid}/{groupId}")]
        public async Task<IActionResult> MakeSpecial([FromRoute] ProductId productId,[FromRoute] string groupId)
        {
            var result = await _mediator.Send(new MakeProductSpecialCommand(productId,GroupId.Create(Guid.Parse(groupId))));
            return Ok(result);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTOs.CreateProductDTO value)
        {

            var result = await _mediator.Send(new AddProductCommand(value));

            return Ok(result);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> Put(ProductId productId, [FromBody] UpdateProduct value)
        {
            var result = await _mediator.Send(new UpdateProductDetailsCommand(productId, value.name,value.nameArab, value.description,value.descriptionArab, value.stockQuantity,value.price,value.discount, value.CategoryId,_webHostEnvironment.WebRootPath,value.hasPercentage));

            return Ok(result);
        }


        [HttpPost("AddMasterImage")]
        public async Task<IActionResult> AddMasterImage([FromForm] ProductDTOs.CreateProductImageDTO value)
        {
            var result = await _mediator.Send(new AddMasterImageCommand(value.ProductId,value.file,_webHostEnvironment.WebRootPath,"Upload/ProductImage"));

            return Ok(result);
        }

        [HttpPost("AddProductImages/{productId}")]
        public async Task<IActionResult> AddProductImages([FromForm] AddProductImage image, [FromRoute] ProductId productId)
        {
            // Validate if the file is provided
            if (image.file == null || image.file.Length == 0)
            {
                return BadRequest("No file provided.");
            }

            // Ensure the file is of an acceptable type (optional)
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(image.file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(fileExtension))
            {
                return BadRequest("Invalid file type.");
            }

            // Process the image upload
            var result = await _mediator.Send(new AddProductImagesCommand(productId, image.file, image.name, _webHostEnvironment.WebRootPath, "Upload/ProductImages"));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Image uploaded successfully.");
        }

        [HttpPost("AddReview")]
        public async Task<IActionResult> AddReview([FromBody] AddReviewCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }



        [HttpGet("GetProductMasterImage/{id}")]
        public async Task<IActionResult> GetProductMasterImage(ProductId id)
        {
            
            var result = await _mediator.Send(new GetProductMasterImageQuery(id));

            try
            {
                if (result.IsSuccess)
                {

                    var file = ImageHelper.GetImageFilePath(result.Value.Path, _webHostEnvironment.WebRootPath);

                    if (System.IO.File.Exists(file))
                    {


                        // Read the file into a byte array
                        byte[] imageData = System.IO.File.ReadAllBytes(file);


                        // Return the image data along with appropriate content type
                        return File(imageData, "image/jpeg", result.Value.Name);
                    }
                }
                else
                {
                    return NotFound("this master image is not exist");
                }
            }
            catch (Exception ex)
            {
                return NotFound();
            }




            return NotFound();
        }

        [HttpGet("GetProductImage/{id}/{productId}")]
        public async Task<IActionResult> GetProductImage(ProductId productId,ImageId id)
        {
            var result = await _mediator.Send(new GetProductImageQuery(id));

            if (result.IsSuccess)
            {
                var file = ImageHelper.GetImageFilePath(result.Value.Path, _webHostEnvironment.WebRootPath);

                if (System.IO.File.Exists(file))
                {


                    // Read the file into a byte array
                    byte[] imageData = System.IO.File.ReadAllBytes(file);


                    // Return the image data along with appropriate content type
                    return File(imageData, "image/jpeg", result.Value.Name);
                }
                
            }

            return NotFound();
        }


        // PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(ProductId id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(ProductId id)
        //{

        //    var result = await _mediator.Send(new DeleteMasterImageCommand(id,_webHostEnvironment.WebRootPath));
        //}
    }

    public record ProductQuery(int pageNumber,
                               string? searchTerm,
                               string? sortColumn,
                               decimal? startPrice,
                               decimal? endPrice,
                               decimal? totalReviews,
                               List<CategoryId>? categoryIds,
                               bool asend = false
                               );

    public record AddProductImage( IFormFile file,string name);

    public record UpdateProduct(string name,string nameArab,string description,string descriptionArab,int stockQuantity,decimal price,int discount,CategoryId CategoryId,bool hasPercentage = false);
    //public record AddProductImagesDto(List<AddProductImages> images);
}
