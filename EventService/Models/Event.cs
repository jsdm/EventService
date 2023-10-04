namespace EventService.Models
{
    /// <summary>
    /// Information om den event, der er opstået
    /// Tænk over, hvilke data det er relevant at event'et indeholder
    /// </summary>
    public class Event
    {
       // TODO: Du skal selv lave en god implementering af event-klassen
        public long SequenceNumber { get; }
        public int PizzaNumber { get; set; }
        public int TableNumber { get; set; }

        public Event(long sequenceNumber, int pizzaNumber, int tableNumber)
        {
            SequenceNumber = sequenceNumber;
            PizzaNumber = pizzaNumber;
            TableNumber = tableNumber;
        }
    }
}
