using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.FrameWork.Contract;

namespace Core.FrameWork.Base
{
    public abstract class ServiceBase<TEntityRepository> where TEntityRepository : class
    {
        protected readonly IUnitOfWork Uow;

        protected  TEntityRepository Repository { get;  set; }

        protected ServiceBase(IUnitOfWork uow)
        {
            Uow = uow;
          //  Repository = new TEntityRepository();
        }

    }
}
