﻿using System.Net;
using Microsoft.AspNetCore.Mvc;
using OnlineMarketFoods.Dtos;
using OnlineMarketFoods.Examples;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace OnlineMarketFoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<ProductDto> _products = new()
        {
            new ProductDto
            {
                Id = 1,
                Name = "Apple",
                Description = "Fresh red apple",
                Price = 1.50m
            },
            new ProductDto
            {
                Id = 2,
                Name = "Bread",
                Description = "Whole grain bread",
                Price = 2.00m
            }
        };

        [HttpGet]
        [SwaggerOperation("GetProduct")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetProductExamples))]
        [SwaggerResponseExample(201, typeof(GetProductExamples))]
        [SwaggerResponse(201, "Got Products Successfuly", typeof(IList<ProductDto>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Product not found")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(_products);
        }

        [HttpPost]
        [SwaggerOperation("CreateProduct")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(CreateProductExamples))]
        [SwaggerResponseExample(201, typeof(CreateProductExamples))]
        [SwaggerResponse(201, "Product Created Successfuly", typeof(ProductDto))]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto productDto)
        {
            if (productDto == null || string.IsNullOrWhiteSpace(productDto.Name))
                return BadRequest("Invalid product data.");

            var newProduct = new ProductDto
            {
                Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price
            };

            _products.Add(newProduct);

            return Ok(newProduct);
        }
    }
}
