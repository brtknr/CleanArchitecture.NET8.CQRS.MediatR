using CleanArchitecture.Application.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Filters
{
    public class InvalidateCacheFilterAsync : Attribute, IAsyncActionFilter
    {
        private readonly string _callerName;
        private ICacheService _cacheService;
        

        public InvalidateCacheFilterAsync(ICacheService cacheService, string callerName)
        {
            _callerName = callerName;
            _cacheService = cacheService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context,
                                                 ActionExecutionDelegate next)
        {
            // invalidate given key . 
            await _cacheService.RemoveKeyAsync(_callerName);

            await next(); 
        }
    }
}
