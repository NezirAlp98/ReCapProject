using System;
using System.Collections.Generic;
using System.Text;
using Core.CrossCuttingConcern.Caching;
using Core.CrossCuttingConcern.Caching.Microsoft;
using Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager,MemoryCacheManager>();
        }
    }
}
