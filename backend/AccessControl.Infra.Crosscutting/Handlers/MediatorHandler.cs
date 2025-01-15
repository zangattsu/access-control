using AccessControl.Infra.CrossCutting.Commands;
using AccessControl.Infra.CrossCutting.Events;
using AccessControl.Infra.CrossCutting.Interfaces;
using MediatR;

namespace AccessControl.Infra.CrossCutting.Handlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            return await _mediator.Send(request);
        }

        public async Task EnviarComando<T>(T comando) where T : Command
        {
            await _mediator.Send(comando);
        }

        public async Task EnviarComando<T>(T comando, CancellationToken cancellationToken = default) where T : Command
        {
            await _mediator.Send(comando, cancellationToken);
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            //if (!evento.MessageType.Equals("DomainNotification"))
                //_eventStore?.SalvarEvento(evento);

            await _mediator.Publish(evento);
        }
    }
}