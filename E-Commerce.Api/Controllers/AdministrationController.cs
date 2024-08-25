using Ardalis.Result;
using E_Commerce.Application.Command.AdministrationCommand.AddSpecialProductsCommand;
using E_Commerce.Application.Command.AdministrationCommand.ChangeTitleCommand;
using E_Commerce.Application.Command.AdministrationCommand.ChangeWebsiteColorCommand;
using E_Commerce.Application.Command.AdministrationCommand.SetDescriptionCommand;
using E_Commerce.Application.Command.ProductCommands.DeleteProductCommand;
using E_Commerce.Application.Helper;
using E_Commerce.Application.Query.AdministrationQuery.DailyEarningChart;
using E_Commerce.Application.Query.AdministrationQuery.GetAdministration;
using E_Commerce.Application.Query.AdministrationQuery.GetDescription;
using E_Commerce.Application.Query.AdministrationQuery.GetOrdersForCategory;
using E_Commerce.Application.Query.AdministrationQuery.GetSpecialProducts;
using E_Commerce.Domain.Model.CategoryAggre;
using E_Commerce.Domain.Model.ProductAggre;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdministrationController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/<AdministrationController>
        [HttpGet("GetAdministration")]
        public async Task<IActionResult>  Get()
        {
            var result = await _mediator.Send(new GetAdministrationQuery());

            return Ok(result);
        }

        [HttpGet("GetWebsiteLogo")]
        public async Task<IActionResult> GetWebsitelogo()
        {
            var result =  ImageHelper.GetImageFilePath("Upload/Logo/myLogo",_webHostEnvironment.WebRootPath);

            if (System.IO.File.Exists(result))
            {


                // Read the file into a byte array
                byte[] imageData = System.IO.File.ReadAllBytes(result);


                // Return the image data along with appropriate content type
                return File(imageData, "image/jpeg");
            }

            return BadRequest();
        }

        [HttpGet("GetHero")]
        public async Task<IActionResult> GetHero()
        {
            var result = ImageHelper.GetImageFilePath("Upload/Hero/Hero.jpg", _webHostEnvironment.WebRootPath);

            if (System.IO.File.Exists(result))
            {


                // Read the file into a byte array
                byte[] imageData = System.IO.File.ReadAllBytes(result);


                // Return the image data along with appropriate content type
                return File(imageData, "image/jpeg");
            }

            return BadRequest();
        }


        [HttpGet("GetDescription")]
        public async Task<IActionResult> GetDescription()
        {
            var result = await _mediator.Send(new GetDescriptionQuery());

            return Ok(result);
        }

        [HttpGet("GetSpecialProducts")]
        public async Task<IActionResult> GetSpecialProducts()
        {
            var result = await _mediator.Send(new GetSpecialProductsQuery());

            return Ok(result);
        }



        [HttpGet("GetDailyEarning")]
        public async Task<IActionResult> GetDailyEarning()
        {
            var result = await _mediator.Send(new DailyEarningChartQuery());

            return Ok(result);
        }

        [HttpGet("GetProductssProfitsForCategories/{id}")]
        public async Task<IActionResult> GetProductssProfitsForCategories(CategoryId id)
        {
            var result = await _mediator.Send(new GetOrdersForCategoryQuery(id));

            return Ok(result);
        }

        [HttpPost("ChangeWebsiteColor")]
        public async Task<IActionResult> ChanegWebsiteColor([FromBody] ChangeColorDto value)
        {
            var result = await _mediator.Send(new ChangeWebsiteColorCommand(value.color));

            return Ok(result);
        }

        [HttpPost("ChangeLogo")]
        public async Task<IActionResult> ChnageLogo(IFormFile logo)
        {

            var path = await ImageHelper.SaveImageAsync(logo,_webHostEnvironment.WebRootPath,"Upload/Logo","myLogo.jpg");

            return Ok();
        }

        [HttpPost("ChangeHero")]
        public async Task<IActionResult> ChangeHero(IFormFile file)
        {
            var path = await ImageHelper.SaveImageAsync(file, _webHostEnvironment.WebRootPath, "Upload/Hero", "Hero.jpg");

            return Ok();
        }

        [HttpPost("ChangeWelcomeMessage")]
        public async Task<IActionResult> ChangeWelcomeMessage(ChangeWelcomeMessageDto value)
        {
            var result = await _mediator.Send(new ChangeWelcomeCommand(value.title_Eng,value.title_Arb,value.desc_Eng,value.desc_Arb));

            return Ok(result);  
        }

        [HttpPost("ChangeDescription")]
        public async Task<IActionResult> ChangeDescription(ChangeWelcomeMessageDto value)
        {
            var result = await _mediator.Send(new SetDescriptionCommand(value.title_Eng,value.title_Arb,value.desc_Eng,value.desc_Arb));

            return Ok(result);  
        }

        [HttpGet("AddSpecialProduct/{id}")]
        public async Task<IActionResult> AddSpecialProduct(ProductId id)
        {
            var result = await _mediator.Send(new AddSpecialProductsCommand(id));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(ProductId id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));

            return Ok(result);
        }


    }

    public record ChangeColorDto(string color);
    public record ChangeWelcomeMessageDto(string title_Eng,string title_Arb,string desc_Eng,string desc_Arb);
}
