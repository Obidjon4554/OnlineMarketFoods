using System.Net;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using OnlineMarketFoods.Dtos;
using OnlineMarketFoods.Examples;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace OnlineMarketFoods.Controllers.V2
{
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class OrderController : ControllerBase
    {
        private static readonly List<CustomerDto> _customers =
        [
            new CustomerDto { Id = 1, Name = "John Doe", PhoneNumber = "123-456-7890", Address = "123 Main St" },
            new CustomerDto { Id = 2, Name = "Jane Smith", PhoneNumber = "987-654-3210", Address = "456 Elm St" }
        ];

        private static readonly List<ProductDto> _products =
        [
            new ProductDto { Id = 1, Name = "Apple", Description = "Fresh red apple", Price = 1.50m },
            new ProductDto { Id = 2, Name = "Bread", Description = "Whole grain bread", Price = 2.00m }
        ];


        private static readonly List<CreateOrderDto> _orders = [];

        [HttpGet]
        [SwaggerOperation("GetOrder")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetOrderExamples))]
        [SwaggerResponseExample(201, typeof(GetOrderExamples))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Order not found")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(_orders);
        }

        [HttpPost]
        [SwaggerOperation("CreateOrder")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(CreateOrderExamples))]
        [SwaggerResponseExample(201, typeof(CreateOrderExamples))]
        [SwaggerResponse(400, "Bad Request")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto orderDto)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == orderDto.CustomerId);
            var product = _products.FirstOrDefault(p => p.Id == orderDto.ProductId);

            if (customer == null || product == null)
            {
                return BadRequest("Customer or Product not found.");
            }

            var newOrder = new CreateOrderDto
            {
                CustomerId = customer.Id,
                ProductId = product.Id,
                OrderDate = orderDto.OrderDate == default ? DateTime.UtcNow : orderDto.OrderDate,
                TotalAmount = product.Price,
                Customer = customer,
                Product = product
            };

            _orders.Add(newOrder);

            return Ok(newOrder);
        }
    }
}
