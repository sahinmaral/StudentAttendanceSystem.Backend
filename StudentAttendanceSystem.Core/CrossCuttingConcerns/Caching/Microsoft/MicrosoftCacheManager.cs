using Microsoft.Extensions.Caching.Memory;

using System.Text.RegularExpressions;

namespace StudentAttendanceSystem.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MicrosoftCacheManager : ICacheManager
    {
        private IMemoryCache _memoryCache;

        public MicrosoftCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public T Get<T>(string key)
        {
           return _memoryCache.Get<T>(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            List<Regex> regexes = cacheCollectionValues.Select(x => new Regex(x.Key.ToString())).ToList();

            Dictionary<string, Regex> cacheCollectionValuesAndRegexPairs = new Dictionary<string, Regex>();
            cacheCollectionValues.ForEach(x => cacheCollectionValuesAndRegexPairs.Add(x.Key.ToString(),new Regex(x.Key.ToString(), RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase)));

            foreach (var pair in cacheCollectionValuesAndRegexPairs)
            {
                if (pair.Value.IsMatch(pattern)) _memoryCache.Remove(pair.Key);
            }
        }
    }
}
