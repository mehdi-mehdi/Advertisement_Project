using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.FrameWork.Base;

namespace Advertisement.Common.Dto
{
    public class PersonDto : DtoBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string DaramaticName { get { return FirstName + " " + LastName; } }
    }
}
