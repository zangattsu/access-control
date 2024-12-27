using Domain.Events;

namespace AccessControl.Infra.CrossCutting.Interfaces
{
    public interface IEventStore
    {
        void SalvarEvento<T>(T evento) where T : Event;
    }
}