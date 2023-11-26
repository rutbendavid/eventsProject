using Microsoft.AspNetCore.Mvc;
using System.Runtime.ExceptionServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private static int idEvents = 3;
        private static List<Event> events = new List<Event> { new Event { Id = 1, Title="first", Start=new DateTime(2023, 11, 23) }, 
                                                       new Event { Id = 2, Title = "second", Start = new DateTime(2023, 11, 24) } , 
                                                       new Event { Id = 3, Title = "third", Start = new DateTime(2023, 11, 25) } };
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event newEvent)
        {
            events.Add(new Event { Id = ++idEvents, Title = newEvent.Title, Start = newEvent.Start });
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event _event)
        {
            var e=events.Find(e=>e.Id==id);
            if (e != null)
            {
                e.Title = _event.Title;
                e.Start=_event.Start;
            }
            //events.Find(e=> e.Id==id).Title=
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var e = events.Find(e => e.Id == id);
            if (e != null)
            {
                events.Remove(e);
            }
        }
    }
}

