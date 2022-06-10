using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: api/book
        [HttpGet]
        public IEnumerable Get()
        {
            return _customerService.List();
        }

        // GET api/book/1
        [HttpGet("{id}")]
        public CustomerModel Get(int id)
        {
            return _customerService.Get(id);
        }

        // POST api/book
        [HttpPost]
        public int Post([FromBody] CustomerModel model)
        {
            return _customerService.Add(model);
        }
        // PUT api/book
        [HttpPut]
        public int Put([FromBody] CustomerModel model)
        {
            return _customerService.Update(model);
        }

        // DELETE api/book/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerService.Delete(id);
        }
    }
}
