using System;
using System.Collections.Generic;
using System.Linq;
using Advertisement.Common.Dto;
using Advertisement.Common.ServiceContracts;
using Advertisement.DataAccess.IRepositories;
using Advertisement.Entities;
using Core.Facilities;
using Core.FrameWork.Base;
using Core.FrameWork.Contract;

namespace Advertisement.Service
{
    public class PersonService : ServiceBase<IPersonRepository>, IPersonService
    {
        public PersonService(IUnitOfWork uow, IPersonRepository repository)
            : base(uow)
        {
            Repository = repository;
        }

        public PersonDto GetById(Guid id)
        {
            var person = Repository.Get(id);
            var personDto = ObjectMapper.Map<Person, PersonDto>(person);
            return personDto;
        }

        public IList<PersonDto> GetAll()
        {          
            var list = Repository.GetAll();
            var dtoList = ObjectMapper.Map<List<Person>, List<PersonDto>>(list.ToList());
            return dtoList;
        }
        public void Insert(PersonDto dto)
        {
            var personEntity = ObjectMapper.Map<PersonDto, Person>(dto);
            Repository.Insert(personEntity);
            Uow.Commit();
        }

        public void Update(PersonDto dto)
        {
            var personEntity = ObjectMapper.Map<PersonDto, Person>(dto);
            Repository.Update(personEntity);
            Uow.Commit();
        }
    }
}
