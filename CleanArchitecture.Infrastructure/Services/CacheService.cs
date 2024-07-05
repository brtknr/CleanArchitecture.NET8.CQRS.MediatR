using CleanArchitecture.Application.Common.Services;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services
{
    public class CacheService(IDistributedCache cache) : ICacheService
    {
        public Task SetAsync<T>(string key, T value)
        {
            return SetAsync(key, value, new DistributedCacheEntryOptions());
        }

        public Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options)
        {
            var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, _serializerOptions));
            return cache.SetAsync(key, bytes, options);
        }

        public bool TryGetValue<T>(string key, out T? value)
        {
            var val = cache.Get(key);
            value = default;

            if (val == null) return false;
            value = JsonSerializer.Deserialize<T>(val, _serializerOptions);
            
            return true;
        }


        private static JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            WriteIndented = true,
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        //private static JsonSerializerOptions GetJsonSerializerOptions()
        //{
        //    return new JsonSerializerOptions()
        //    {
        //        PropertyNamingPolicy = null,
        //        WriteIndented = true,
        //        AllowTrailingCommas = true,
        //        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        //    };
        //}
    }
}
