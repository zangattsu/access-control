using Domain.Events;

namespace AccessControl.Infra.CrossCutting.Interfaces.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);

        IList<StoredEvent> All(Guid aggregateId);
    }
}