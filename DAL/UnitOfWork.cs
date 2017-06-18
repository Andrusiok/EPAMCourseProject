using DAL.Interfaces.Interfaces;
using System;
using System.Data.Entity;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            if (Context != null)
                try
                {
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("Can't commit changes to database", e);
                }
        }

        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
        }
    }
}
