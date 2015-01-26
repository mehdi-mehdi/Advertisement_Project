using System;
using Core.FrameWork.Base;

namespace Core.FrameWork.Contract
{
    public interface ILogger
    {
        void Log(Exception exception);
        void Log(LogEntity loggeEntity);
    }
}
