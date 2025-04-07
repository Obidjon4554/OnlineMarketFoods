using OnlineMarketFoods.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace OnlineMarketFoods.Examples
{
    public class GetCustomerExamples : IExamplesProvider<CustomerDto>
    {
        public CustomerDto GetExamples()
        {
            return new()
            {
                Id = 1,
                Name = "Test",
                Address = "Test Address",
                PhoneNumber = "1234567890",
            };
        }
    }

    public class CreateCustomerExamples : IExamplesProvider<CreateCustomerDto>
    {
        public CreateCustomerDto GetExamples()
        {
            return new()
            {
                Name = "Test",
                Address = "Test Address",
                PhoneNumber = "1234567890",
            };
        }
    }
}
