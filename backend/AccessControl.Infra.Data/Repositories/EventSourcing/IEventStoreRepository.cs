using System;
using System.Collections.Generic;
using Cesgranrio.Financeiro.Domain.Core.Events;

namespace AccessControl.Infra.Data.Repositories.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}