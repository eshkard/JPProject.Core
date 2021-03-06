using JPProject.Domain.Core.Events;

namespace JPProject.Admin.Domain.Events.PersistedGrant
{
    public class PersistedGrantRemovedEvent : Event
    {
        public string Key { get; }

        public PersistedGrantRemovedEvent(string key)
            : base(EventTypes.Success)
        {
            Key = key;
            AggregateId = key;
        }
    }
}