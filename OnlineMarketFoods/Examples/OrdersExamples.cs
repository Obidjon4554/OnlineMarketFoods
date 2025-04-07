using OnlineMarketFoods.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace OnlineMarketFoods.Examples
{
    public class GetOrderExamples : IExamplesProvider<OrderDto>
    {
        public OrderDto GetExamples()
        {
            return new()
            {
                Id = 101,
                CustomerId = 1,
                ProductId = 2,
                OrderDate = DateTime.UtcNow,
                TotalAmount = 2.00m,
                Customer = new CustomerDto
                {
                    Id = 1,
                    Name = "John Doe",
                    Address = "123 Main St",
                    PhoneNumber = "123-456-7890"
                },
                Product = new ProductDto
                {
                    Id = 2,
                    Name = "Bread",
                    Description = "Whole grain bread",
                    Price = 2.00m
                }
            };
        }
    }


    public class CreateOrderExamples : IExamplesProvider<CreateOrderDto>
    {
        public CreateOrderDto GetExamples()
        {
            return new()
            {
                CustomerId = 1,
                ProductId = 2,
                OrderDate = DateTime.UtcNow,
                TotalAmount = 2.00m,
                Customer = new CustomerDto
                {
                    Id = 1,
                    Name = "John Doe",
                    Address = "123 Main St",
                    PhoneNumber = "123-456-7890"
                },
                Product = new ProductDto
                {
                    Id = 2,
                    Name = "Bread",
                    Description = "Whole grain bread",
                    Price = 2.00m
                }
            };
        }
    }
}