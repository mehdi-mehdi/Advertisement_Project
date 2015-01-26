using System;

namespace Core.FrameWork.Base
{
    public class DtoBase
    {
        public DtoBase()
        {
            Created = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
