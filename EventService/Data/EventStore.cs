using EventService.Models;

namespace EventService.Data
{
    public interface IEventStore
    {
        void RaiseEvent(int pizzaNumber, int tableNumber);
        IEnumerable<Event> ListEvents(int startIndex, int antal);
    }
    
    public class EventStore : IEventStore
    {
        private static long CurrentSequenceNumber = 0;
        private static readonly IList<Event> _events = new List<Event>();

        public void RaiseEvent(int pizzaNumber, int tableNumber)
        {
            var seqNumber = Interlocked.Increment(ref CurrentSequenceNumber);
            _events.Add(new Event(seqNumber, pizzaNumber, tableNumber));
        }

        public IEnumerable<Event> ListEvents(int startIndex, int antal) => _events
            .Where(e => startIndex <= e.SequenceNumber && e.SequenceNumber <= startIndex+antal)
            .OrderBy(e=> e.SequenceNumber);
    }
}
