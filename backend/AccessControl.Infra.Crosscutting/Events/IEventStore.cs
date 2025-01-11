namespace AccessControl.Infra.CrossCutting.Events
{
    public interface IEventStore
    {
        void SalvarEvento<T>(T evento) where T : Event;
    }
}