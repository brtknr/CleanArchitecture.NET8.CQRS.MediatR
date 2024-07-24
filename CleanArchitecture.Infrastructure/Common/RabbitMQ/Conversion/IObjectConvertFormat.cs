using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Common.RabbitMQ.Conversion
{
    public interface IObjectConvertFormat
    {
        T JsonToObject<T>(string json) where T : class,new();
        string ObjectToJson<T>(T entityObject) where T : class,new();
        T ParseObjectDataArray<T>(byte[] rawBytes) where T : class,new(); 
    }
}
