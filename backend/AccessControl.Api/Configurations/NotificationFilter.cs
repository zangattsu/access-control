using AccessControl.Infra.CrossCutting.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace AccessControl.Api.Configurations
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly DomainNotificationHandler _notifications;

        public NotificationFilter(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notifications.HasNotifications())
            {
                var notifications = _notifications.GetNotifications();
                var status = notifications.GroupBy(a => a.Key).Select(b => b.Key).First();
                context.HttpContext.Response.StatusCode = status.All(char.IsDigit) ? Convert.ToInt32(status) : (int)HttpStatusCode.InternalServerError;
                context.HttpContext.Response.ContentType = "application/json";

                var json = JsonConvert.SerializeObject(notifications);
                await context.HttpContext.Response.WriteAsync(json);

                return;
            }

            await next();
        }
    }
}