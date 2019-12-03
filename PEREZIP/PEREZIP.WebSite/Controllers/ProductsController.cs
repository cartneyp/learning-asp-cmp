using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PEREZIP.WebSite.Services;
using PEREZIP.WebSite.Models;

namespace PEREZIP.WebSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]

        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();

        }
        [HttpGet]
        [Route("Rate")]
        public ActionResult Get(
            [FromQuery]string ProductId,
            [FromQuery]int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();
        }

    }
}