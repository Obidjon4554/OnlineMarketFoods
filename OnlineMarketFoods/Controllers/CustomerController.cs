using System.Net;
using Microsoft.AspNetCore.Mvc;
using OnlineMarketFoods.Dtos;
using OnlineMarketFoods.Examples;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace OnlineMarketFoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private static readonly List<CustomerDto> _customers =
        [
            new ()
            {
                Id = 1,
                Name = "John Doe",
                PhoneNumber = "123-456-7890",
                Address = "123 Main St, Anytown, USA"
            },
            new ()
            {
                Id = 2,
                Name = "Jane Smith",
                PhoneNumber = "987-654-3210",
                Address = "456 Elm St, Othertown, USA"
            }
        ];
        [HttpGet]
        [SwaggerOperation("GetCustomer")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetCustomerExamples))]
        [SwaggerResponseExample(201, typeof(GetCustomerExamples))]
        [SwaggerResponse(201,"Got Customers Successfuly", typeof(IList<CustomerDto>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Customer not found")]

        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(_customers);
        }

        [HttpPost]
        [SwaggerOperation("CreateCustomer")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(CreateCustomerExamples))]
        [SwaggerResponseExample(201, typeof(CreateCustomerExamples))]
        [SwaggerResponse(201, "Customer Created Successfuly", typeof(IList<CustomerDto>))]
        [SwaggerResponse(400, "Bad Request")]

        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto customerDto)
        {
            if (customerDto == null || string.IsNullOrWhiteSpace(customerDto.Name))
                return BadRequest("Invalid customer data.");

            var newCustomer = new CustomerDto
            {
                Id = _customers.Any() ? _customers.Max(p => p.Id) + 1 : 1,
                Name = customerDto.Name,
                PhoneNumber = customerDto.PhoneNumber,
                Address = customerDto.Address
            };

            _customers.Add(newCustomer);
            return Ok(newCustomer);

        }
    }
}
