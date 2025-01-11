using CinSaude.Data.Context;
using CinSaude.Domain.Core.Events;
using CinSaude.Domain.Core.EventSourcing;

namespace AccessControl.Infra.Data.Repositories.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly CinSaudeContext _context;

        public EventStoreSQLRepository(CinSaudeContext context)
        {
            _context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}