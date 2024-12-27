using System;
using System.Collections.Generic;

namespace AccessControl.Infra.CrossCutting.Interfaces
{
    public interface INotificationTable
    {
        IList<string> Notifications { get; }

        void AddNotification(string notification);

        bool IsValid();
    }
}
