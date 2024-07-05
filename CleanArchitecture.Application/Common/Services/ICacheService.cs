using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Services
{
    public interface ICacheService
    {
        Task SetAsync<T>(string key, T value);
        Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options);
        bool TryGetValue<T>(string key, out T? value);
    }
}
