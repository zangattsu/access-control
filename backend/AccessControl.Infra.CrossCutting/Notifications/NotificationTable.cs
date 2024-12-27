using AccessControl.Infra.CrossCutting.Interfaces;
using System;
using System.Collections.Generic;

namespace AccessControl.Infra.CrossCutting.Notifications
{
    public abstract class NotificationTable : INotificationTable
    {
        public NotificationTable()
        {
            Notifications = new List<string>();
        }

        protected NotificationTable(IList<string> notifications)
        {
            Notifications = notifications;
        }

        public IList<string> Notifications { get; }

        public void AddNotification(string notification)
        {
            Notifications.Add(notification);
        }

        public bool IsValid()
        {
            return Notifications.Count == 0;
        }

    }
}
