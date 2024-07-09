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
        Task<T?> GetOrCreateAsync<T>(
            string key,
            Func<CancellationToken, Task<T>> factory,
            DistributedCacheEntryOptions? options = null,
            CancellationToken cancellationToken = default);

    }
}
