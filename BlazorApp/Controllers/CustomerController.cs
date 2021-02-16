
using BlazorApp.Models;
using BlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Controllers
{

    [Route("customer")]
    [ApiController]
    public class CustomerController : Controller
    {
        private ICustomerRepository customerRepository;
        public CustomerController(ICustomerRepository _customerRepository)
        {
            customerRepository = _customerRepository;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            await customerRepository.DeleteCustomerAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomerViewModel customer)
        {
            if(customer == null)
            {
                return BadRequest();
            }
            await customerRepository.UpdateCustomerAsync(customer.Id, customer);
            return Ok();
        }
        [HttpPost("list")]
        public async Task<IActionResult> LoadCustomers()
        {
            var result = await customerRepository.LoadCustomersAsync();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> LoadCustomersWithPaging([FromQuery] PagingParameters pagingParameters)
        {
            var result = await customerRepository.LoadCustomersWithPagingAsync(pagingParameters);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerViewModel customer)
        {
            await customerRepository.AddCustomerAsync(customer);
            return Ok();
        }

    }
}
