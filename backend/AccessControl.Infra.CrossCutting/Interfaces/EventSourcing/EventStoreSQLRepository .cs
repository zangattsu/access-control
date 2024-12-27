using System;
using System.Collections.Generic;
using System.Linq;
using Cesgranrio.Financeiro.Domain.Core.Events;
using Cesgranrio.Financeiro.Infra.Data.Identity.Context;

namespace AccessControl.Infra.CrossCutting.Interfaces.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly FinanceiroContext _context;

        public EventStoreSQLRepository(FinanceiroContext context)
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