using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private SaleContext context;
        private IGenericRepository<Sale> salesRepository;

        public UnitOfWork()
        {
            context = new SaleContext();
        }

        ~UnitOfWork() => Dispose();

        public IGenericRepository<Sale> Sales
        {
            get
            {
                if (salesRepository == null)
                {
                    salesRepository = new GenericRepository<Sale>(context);
                }
                return salesRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
