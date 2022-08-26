using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Data.Models;
using ProductApp.Interfaces;
using ProductApp.Services;
using System.Net;
using RestSharp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web.Resource;

namespace ProductApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey ="AzureAd:scopes")]
    public class ProductController : ControllerBase
    {
        public IProduct _productService;

        public ProductController(IProduct productService)
        {
            _productService = productService;
        }

        // Saving product with articles 
        [Authorize(Roles ="Manager")]
        [HttpPost("addProduct")]
        public async Task<IActionResult> createProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int genRand = random.Next(1, 9);

                int genSeq = random.Next(10000000, 10000009);

                string intnum = genRand.ToString().PadLeft(3, '0');

                if (product.ChannelId == 1)
                    product.ProductCode = Convert.ToString(product.ProductYear) + intnum;
                if (product.ChannelId == 2)
                    product.ProductCode = GetCode(6, random);
                if (product.ChannelId == 3)
                    product.ProductCode = Convert.ToString(genSeq);

                _productService.AddProduct(product);
            }
            else
            {
                return BadRequest("request is incorrect");
            }

            return Created(new Uri(Request.Path, UriKind.Relative), product);
        }

        public static string GetCode(int length, Random random)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var result = new string(
                Enumerable.Repeat(chars, length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }

        [Authorize]
        [HttpPost("AddColour")]
        public IActionResult Post([FromBody] Colour colour)
        {
            _productService.AddColour(colour);
            return Ok(colour);
        }

        [Authorize]
        [HttpPost("AddSizeScale")]
        public IActionResult Post([FromBody] SizeScale sizeScale)
        {
            _productService.AddSizeScale(sizeScale);
            return Ok(sizeScale);
        }

        [Authorize]
        [HttpGet("getProduct/{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }
    }
}
