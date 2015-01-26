using System;

namespace Core.FrameWork.Base
{
    public abstract class BusinessExeprionBase : Exception
    {
        public abstract string Messesage { get; set; }

        public abstract string Title { get; set; }

        protected DateTime ExceptionTime { get; set; }
    }
}
