using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.FrameWork.Contract;
using EmitMapper;

namespace Core.Facilities
{
    public static class ObjectMapper 
    {
        static ObjectMapper()
        {
            Mapper = ObjectMapperManager.DefaultInstance; 
        }

        public static TDestinition Map<TSource, TDestinition>(TSource source)
            where TSource : class
            where TDestinition : class
        {
          return  Mapper.GetMapper<TSource, TDestinition>().Map(source);
        }

        private static readonly ObjectMapperManager Mapper;
    }
}
