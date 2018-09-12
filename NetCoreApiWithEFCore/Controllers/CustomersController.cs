using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Models;

namespace Module1.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private List<Customer> _customer = new List<Customer>()
        {
            new Customer() {Id = 0, Name = "Sachin", Email = "abc@xyz.com", Phone = "1111"},
            new Customer() { Id = 1, Name = "Soumya", Email = "pqr@efg.com", Phone = "2222"}
        };

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customer;
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customer.Add(customer);
                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}