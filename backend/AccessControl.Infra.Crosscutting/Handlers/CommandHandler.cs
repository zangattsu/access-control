using AccessControl.Infra.CrossCutting.Interfaces;
using AccessControl.Infra.CrossCutting.Notifications;
using FluentValidation.Results;
using MediatR;
using System.Net;

namespace AccessControl.Infra.CrossCutting.Handlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _mediator;
        private readonly DomainNotificationHandler _notifications;

        protected CommandHandler(
            IUnitOfWork uow,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _mediator.PublicarEvento(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected void NotificarValidacao(string code, string message)
        {
            _mediator.PublicarEvento(new DomainNotification(((int)Enum.Parse(typeof(HttpStatusCode), code)).ToString(), message));
        }

        protected void NotificarValidacao(int code, List<string> message)
        {
            foreach (var item in message)
            {
                _mediator.PublicarEvento(new DomainNotification(code.ToString(), item));
            }
        }

        protected bool OperacaoValida()
        {
            return !_notifications.HasNotifications();
        }

        protected bool OperacaoInvalida()
        {
            try
            {
                if (_notifications.HasNotifications())
                    return false;

                if (_uow.Commit())
                    return true;

                NotificarValidacao(HttpStatusCode.BadRequest.ToString(), "Ocorreu um erro ao salvar os dados no banco");
                return false;
            }
            catch (Exception e)
            {
                NotificarValidacao(HttpStatusCode.BadRequest.ToString(), $"Ocorreu erro ao realizar o Commit. Mensagem: {e.Message}");
                return false;
            }
        }
    }
}