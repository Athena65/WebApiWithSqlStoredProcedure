using Microsoft.AspNetCore.Mvc;
using StoredProcedureImplementing.Models;
using StoredProcedureImplementing.Services;

namespace StoredProcedureImplementing.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
               return Ok(await _customerService.GetAllCustomers());

            }
            catch (Exception ex)
            {
                var response = new ServiceResponse()
                {
                    Success=false,
                    Message=ex.Message, 
                };
                return BadRequest(response);    
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                return Ok(await _customerService.GetCustomerById(id));
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse()
                {
                    Success=false,
                    Message=ex.Message,
                };
                return BadRequest(response);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            try
            {
                return Ok(await _customerService.CreateCustomer(customer)+ $"{customer.Name} Created!");
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse()
                {
                    Success = false,
                    Message=ex.Message,
                };
                return BadRequest(response);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer updatedCustomer)
        {
            try
            {
                return Ok(await _customerService.UpdateCustomer(updatedCustomer)+ $"{updatedCustomer.Name} Updated!");
            }
            catch (Exception ex)
            {
                var response = new ServiceResponse()
                {
                    Success = false,
                    Message = ex.Message,
                };
                return BadRequest(response);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                return Ok(await _customerService.DeleteCustomer(id));   
            }
            catch (Exception ex)
            {
                var response= new ServiceResponse() { Success=false,Message=ex.Message, };  
                return BadRequest(response);
            }
        }
    }
}
