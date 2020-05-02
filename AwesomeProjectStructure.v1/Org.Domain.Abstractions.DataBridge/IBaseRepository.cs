namespace Org.Domain.Abstractions.DataBridge
{
    using System;

    public interface IBaseRepository <in TEntity> : IDisposable where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(TEntity entityToDelete);
        int Save();
    }
}
