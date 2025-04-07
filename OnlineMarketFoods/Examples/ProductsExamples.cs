using OnlineMarketFoods.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace OnlineMarketFoods.Examples
{
    public class GetProductExamples : IExamplesProvider<ProductDto>
    {
        public ProductDto GetExamples()
        {
            return new()
            {
                Id = 1,
                Name = "Apple",
                Description = "Fresh and juicy apples",
                Price = 1.99m
            };
        }
    }

    public class CreateProductExamples : IExamplesProvider<CreateProductDto>
    {
        public CreateProductDto GetExamples()
        {
            return new()
            {
                Name = "Banana",
                Description = "Ripe bananas",
                Price = 0.99m
            };
        }
    }
}
