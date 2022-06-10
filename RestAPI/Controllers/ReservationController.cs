using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        IReservationService _reservationService;

        public ReservationController(IReservationService bookService)
        {
            _reservationService = bookService;
        }
        // GET: api/book
        [HttpGet]
        public IEnumerable Get()
        {
            return _reservationService.List();
        }

        // GET api/book/1
        [HttpGet("{id}")]
        public ReservationModel Get(int id)
        {
            return _reservationService.Get(id);
        }

        // POST api/book
        [HttpPost]
        public int Post([FromBody] ReservationModel model)
        {
            return _reservationService.Add(model);
        }
        // PUT api/book
        [HttpPut]
        public int Put([FromBody] ReservationModel model)
        {
            return _reservationService.Update(model);
        }

        // DELETE api/book/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _reservationService.Delete(id);
        }
    }
}
