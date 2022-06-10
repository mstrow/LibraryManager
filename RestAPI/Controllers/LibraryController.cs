using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        // GET: api/library
        [HttpGet]
        public IEnumerable Get()
        {
            return _libraryService.List();
        }

        // GET api/library/1
        [HttpGet("{id}")]
        public LibraryModel Get(int id)
        {
            return _libraryService.Get(id);
        }

        /*// GET api/library/names
        [HttpGet("names")]
        public IEnumerable Names()
        {
            return _libraryService.ListNames();
        }*/
        // POST api/library
        [HttpPost]
        public int Post([FromBody] LibraryModel model)
        {
            return _libraryService.Add(model);
        }
        // PUT api/library
        [HttpPut]
        public int Put([FromBody] LibraryModel model)
        {
            return _libraryService.Update(model);
        }

        // DELETE api/library/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _libraryService.Delete(id);
        }
    }
}
