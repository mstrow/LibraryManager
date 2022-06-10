using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/magazine")]
    [ApiController]
    public class MagazineController : ControllerBase
    {
        IMagazineService _bookService;

        public MagazineController(IMagazineService bookService)
        {
            _bookService = bookService;
        }
        // GET: api/book
        [HttpGet]
        public IEnumerable Get()
        {
            return _bookService.List();
        }

        // GET api/book/1
        [HttpGet("{id}")]
        public MagazineBookModel Get(int id)
        {
            return _bookService.Get(id);
        }

        /*// GET api/book/names
        [HttpGet("names")]
        public IEnumerable Names()
        {
            return _bookService.ListNames();
        }*/
        // POST api/book
        [HttpPost]
        public int Post([FromBody] MagazineBookModel model)
        {
            return _bookService.Add(model);
        }
        // PUT api/book
        [HttpPut]
        public int Put([FromBody] MagazineBookModel model)
        {
            return _bookService.Update(model);
        }

        // DELETE api/book/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _bookService.Delete(id);
        }
    }
}
