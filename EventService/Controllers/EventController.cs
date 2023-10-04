using EventService.Data;
using EventService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace EventService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventStore eventStore;
        public EventController(IEventStore eventStore)
        {
            this.eventStore = eventStore;
        }
        /// <summary>
        /// Kaldes af en anden service, når den har brug for at offentliggøre (publishe) et event
        /// </summary>
        /// <param name="e">Information om den event, der er opstået</param>
        [HttpPost]
        public void RaiseEvent(Event e) {
            /// TODO: Skriv din kode her - husk også at implementere event-klassen
            this.eventStore.RaiseEvent(e.PizzaNumber, e.TableNumber);
        }

        /// <summary>
        /// Henter events
        /// </summary>
        /// <param name="startIndex">Index på det første event der skal hentes</param>
        /// <param name="antal">Antallet af events der maksimalt skal hentes (der kan være færre)</param>
        /// <returns></returns>
        /// public List<Event> ListEvents(int startIndex, int antal)
        [HttpGet]
        public ActionResult<Event[]> ListEvents(int startIndex, int antal)
        {
            // TODO Skriv din kode her. Du må gerne ændre returtype og parametre, hvis du vil.
            // Koden her er bare tænkt som et udgangspunkt.
            if (startIndex < 0 || antal < 1) { return BadRequest(); }

            return this.eventStore.ListEvents(startIndex, antal).ToArray();
        }
    }
}
