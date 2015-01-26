using System;

namespace Core.FrameWork.Base
{
    public sealed class LogEntity
    {
       public string User { get; set; }

       public string MethodName { get; set; }

       public string Description { get; set; }

       public string ClassName { get; set; }

       public Exception InnerException { get; set; }

       public DateTime LogTime { get; set; }

    }


}
