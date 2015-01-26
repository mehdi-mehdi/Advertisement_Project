using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.FrameWork.Contract;

namespace Core.FrameWork.Base
{
   public abstract class UnitOfWorkBase:IUnitOfWork
    {
       
        public System.Data.Entity.IDbSet<TEntity> Set<TEntity>() where TEntity : class 
        {
            throw new NotImplementedException();
        }

       public void SetModified<TEntity>(TEntity item) where TEntity : EntityBase
       {
           throw new NotImplementedException();
       }

       IDbSet<TEntity> IUnitOfWork.Set<TEntity>()
       {
           throw new NotImplementedException();
       }

       public int Commit()
       {
           throw new NotImplementedException();
       }

       public void Dispose()
       {
           throw new NotImplementedException();
       }

       public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
