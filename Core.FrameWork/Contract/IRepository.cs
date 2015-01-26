using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.FrameWork.Base;

namespace Core.FrameWork.Contract
{
    public interface IRepository<TEntity> 
        where TEntity : EntityBase
    {
        TEntity Get(Guid id);

        TEntity GetByFilter(Expression<Func<TEntity, Boolean>> predicate);

        IList<TEntity> GetAll();

        IList<TEntity> GetAllByFilter(Expression<Func<TEntity, Boolean>> predicate);

        void Insert(TEntity entity);

        void Update(TEntity entity);

    }
}
