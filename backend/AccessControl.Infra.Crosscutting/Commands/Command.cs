using AccessControl.Infra.CrossCutting.Events;
using MediatR;

namespace AccessControl.Infra.CrossCutting.Commands
{
    public class Command : Message, IRequest
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}