using System;

namespace AccessControl.Infra.CrossCutting.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}