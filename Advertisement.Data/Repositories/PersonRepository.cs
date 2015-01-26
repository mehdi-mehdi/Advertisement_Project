using Advertisement.DataAccess.IRepositories;
using Advertisement.Entities;
using Core.FrameWork.Base;
using Core.FrameWork.Contract;

namespace Advertisement.DataAccess.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(IUnitOfWork uow):base(uow)
        {
            
        }
    }
}
