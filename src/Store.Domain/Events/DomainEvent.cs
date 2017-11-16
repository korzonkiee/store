namespace Store.Domain.Events
{
    public class DomainEvent : Event
    {
        public string EventType { get; set; }
        public string EventError { get; set; }

        public DomainEvent(string eventType, string eventError)
        {
            EventType = eventType;
            EventError = eventError;
        }
    }
}