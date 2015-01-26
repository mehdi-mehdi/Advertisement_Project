using System;
using System.Data.Entity;
using Core.FrameWork.Base;

namespace Core.FrameWork.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase;
        void SetModified<TEntity>(TEntity item) where TEntity : EntityBase;
        int Commit();

    }
}
