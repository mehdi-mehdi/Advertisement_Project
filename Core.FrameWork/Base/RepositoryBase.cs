using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.FrameWork.Contract;

namespace Core.FrameWork.Base
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        protected readonly IUnitOfWork Uow;

        protected readonly IDbSet<TEntity> Db;

        protected RepositoryBase(IUnitOfWork uow)
        {
            Uow = uow;
            Db = Uow.Set<TEntity>();
        }

        public TEntity Get(Guid id)
        {
            var entity = Db.Find(id);
            return entity;
        }


        public TEntity GetByFilter(Expression<Func<TEntity, Boolean>> predicate)
        {
            var entity = Db.FirstOrDefault(predicate);
            return entity;
        }

        public Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, Boolean>> predicate)
        {
            var entity = Db.FirstOrDefaultAsync(predicate);
            return entity;
        }

        public IList<TEntity> GetAll()
        {
            var list = Db.ToList();

            return list;
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            var list = Db.ToListAsync();

            return list;
        }
        public IList<TEntity> GetAllByFilter(Expression<Func<TEntity, Boolean>> predicate)
        {
            var list = Db.Where(predicate).ToList();

            return list;
        }

        public void Insert(TEntity entity)
        {
            Db.Add(entity);
        }

        public void Update(TEntity entity)
        {

            Uow.SetModified(entity);
        }
    }
}
