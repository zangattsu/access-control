using AccessControl.Infra.CrossCutting.Commands;
using AccessControl.Infra.CrossCutting.Events;
using MediatR;

namespace AccessControl.Infra.CrossCutting.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;

        Task EnviarComando<T>(T comando) where T : Command;
        Task<Unit> EnviarComando<T>(T comando, CancellationToken cancellationToken = default) where T : Command;

        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}