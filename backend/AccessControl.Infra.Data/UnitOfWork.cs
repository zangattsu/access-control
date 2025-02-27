using AccessControl.Infra.CrossCutting.Interfaces;
using AccessControl.Infra.Data.Context;

namespace AccessControl.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultContext _context;
        private bool _disposed = false;

        public UnitOfWork(DefaultContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}