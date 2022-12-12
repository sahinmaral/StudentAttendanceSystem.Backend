using Microsoft.Extensions.DependencyInjection;

using StudentAttendanceSystem.Core.CrossCuttingConcerns.Caching;
using StudentAttendanceSystem.Core.CrossCuttingConcerns.Caching.Microsoft;
using StudentAttendanceSystem.Core.CrossCuttingConcerns.Caching.Redis;
using StudentAttendanceSystem.Core.Utilities.IoC;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Core.DependencyResolvers
{
    public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            #region For Microsoft Caching
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<ICacheManager, MicrosoftCacheManager>();
            #endregion

            #region For Redis Caching
            //serviceCollection.AddDistributedMemoryCache();
            //serviceCollection.AddSingleton<ICacheManager, RedisCacheManager>();
            #endregion
        }
    }
}
