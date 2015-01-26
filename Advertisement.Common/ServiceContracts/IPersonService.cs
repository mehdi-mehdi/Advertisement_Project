using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertisement.Common.Dto;
using Core.FrameWork.Contract;

namespace Advertisement.Common.ServiceContracts
{
    public interface IPersonService : IServiceContract
    {
        PersonDto GetById(Guid id);
        IList<PersonDto> GetAll();
        void Insert(PersonDto dto);
        void Update(PersonDto dto);
    }
}
