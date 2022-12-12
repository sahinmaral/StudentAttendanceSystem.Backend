using Microsoft.Extensions.Caching.Distributed;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendanceSystem.Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheManager(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void Add(string key, object value, int duration)
        {
            string serializedObject = 
            JsonConvert.SerializeObject(value, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            _distributedCache.Set(key, Encoding.UTF8.GetBytes(serializedObject),new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(duration)
            });
        }

        public object Get(string key)
        {
            var byteObject = Encoding.UTF8.GetString(_distributedCache.Get(key));
            var returnedObject = JsonConvert.DeserializeObject(byteObject, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return returnedObject;
        }

        public T Get<T>(string key)
        {
            return (T)JsonConvert.DeserializeObject(_distributedCache.GetString(key));
        }

        public bool IsAdd(string key)
        {
            return _distributedCache.Get(key) != null;
        }

        public void Remove(string key)
        {
            _distributedCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }
    }
}
