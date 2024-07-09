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
        private static readonly DistributedCacheEntryOptions Default = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
        };

        private static readonly SemaphoreSlim Semaphore = new(1, 1);

        public async Task<T?> GetOrCreateAsync<T>(
            string key,
            Func<CancellationToken,Task<T>> factory,
            DistributedCacheEntryOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            var cachedValue = await cache.GetStringAsync(key, cancellationToken);

            T? value;
            if (!string.IsNullOrWhiteSpace(cachedValue))
            {
                value = JsonSerializer.Deserialize<T>(cachedValue);
                
                if (value != null)
                {
                    return value;
                }
            }

            var hasLock = await Semaphore.WaitAsync(5000);

            if (!hasLock)
            {
                return default;
            }
             // stampede protection by using semaphore
            try
            {
                cachedValue = await cache.GetStringAsync(key, cancellationToken);
                if (!string.IsNullOrWhiteSpace(cachedValue))
                {
                    value = JsonSerializer.Deserialize<T>(cachedValue);

                    if (value != null)
                    {
                        return value;
                    }
                }

                value = await factory(cancellationToken);
                if (value is null) return default;

                await cache.SetStringAsync(key, JsonSerializer.Serialize(value), options ?? Default, cancellationToken);
            }
            finally
            {
                Semaphore.Release();
            }
            
            return value;
        }


        private static JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            WriteIndented = true,
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

    }
}
