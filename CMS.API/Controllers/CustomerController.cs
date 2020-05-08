using CMS.Application.ApiModels;
using CMS.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.API.Controllers
{
    /// <summary>
    /// REST API Ends for Managing Customers in system
    /// </summary>
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;
        /// <summary>
        /// Constructor for IoC or DI
        /// </summary>
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        // GET 
        // api/Customer

        /// <summary>
        /// Retrieves a list of customers
        /// </summary>
        /// <returns>A response with list of customers</returns>
        /// <response code="200">Returns the Customer List</response>
        /// <response code="404">If Customer is not exists</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            _service.GetCustomers();
            return Ok();
        }

        // GET 
        // api/Customer/5
        /// <summary>
        /// Retrieves a Cutomer by customer ID
        /// </summary>
        /// <param name="id">Customer ID</param>
        /// <returns>A response with Customer Item</returns>
        /// <response code="200">Returns the Customer List</response>
        /// <response code="404">If Customer is not exists</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet("/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST
        // api/Customer


        /// <remarks>
        /// Sample request:
        /// {
        ///   FirstName = "FN",
        ///   LastName = "LN"
        /// }
        /// </remarks>
        /// <summary>
        /// Creates a new customer in the system
        /// </summary>
        /// <param name="customerModel">Customer Models</param>
        /// <returns>A response with new customer</returns>
        /// <response code="201">A response as creation of customer</response>
        /// <response code="400">For bad request</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody]CustomerModel customerModel)
        {
            return Created("api/Customer/Id", customerModel);
        }

        // PUT: 
        // api/Customer/5

        /// <summary>
        /// Update an existing customer item
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <param name="customerModel">Request model</param>
        /// <returns>A response with updated customer</returns>
        /// <response code="200">If Customer item was updated successfully</response>
        /// <response code="400">For bad request</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpPut("{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int customerId, [FromBody] CustomerModel customerModel)
        {
            return Ok();
        }

        // DELETE 
        // api/Customer/5

        /// <summary>
        /// Delete an existing customer item
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <returns>A response as Customer deleted from system</returns>
        /// <response code="200">If Customer item was Deleted successfully</response>
        /// <response code="404">If Customer is not exists</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
