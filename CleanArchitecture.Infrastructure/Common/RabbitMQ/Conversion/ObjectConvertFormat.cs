using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Common.RabbitMQ.Conversion
{
    public class ObjectConvertFormat : IObjectConvertFormat
    {
        public T JsonToObject<T>(string json) where T : class, new()
        {
            var objectData = JsonConvert.DeserializeObject<T>(json);
            return objectData;
        }

        public string ObjectToJson<T>(T entityObject) where T : class, new()
        {
            var json = JsonConvert.SerializeObject(entityObject);
            return json;
        }

        public T ParseObjectDataArray<T>(byte[] rawBytes) where T : class, new()
        {
            var stringData = Encoding.UTF8.GetString(rawBytes);
            return JsonToObject<T>(stringData);
        }
    }
}
