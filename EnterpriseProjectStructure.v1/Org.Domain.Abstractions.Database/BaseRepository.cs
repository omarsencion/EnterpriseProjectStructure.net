namespace Org.Domain.Abstractions.Database
{
    using System;
    using Microsoft.EntityFrameworkCore;

    using DataBridge;
 
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbSet;

        protected BaseRepository(AbstractCrmDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected AbstractCrmDbContext DbContext { get; }

        public virtual void Insert(TEntity entity)
        {
            InitializeDbSet();
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            InitializeDbSet();
            _dbSet.Attach(entityToUpdate);
            DbContext.Entry(entityToUpdate);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            InitializeDbSet();
            if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual int Save()
        {
            return DbContext.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (DbContext != null)
                    {
                        DbContext.Dispose();
                    }
                }

                // Clean up unmanaged resources

                disposedValue = true;
            }
        }

        #endregion

        private void InitializeDbSet()
        {
            // Cannot be set in constructor, since there's a provision to override the dbcontext
            // after creation of Lazy<> object in constructor
            if (_dbSet == null)
            {
                _dbSet = DbContext.Set<TEntity>();
            }
        }

      
    }
}
