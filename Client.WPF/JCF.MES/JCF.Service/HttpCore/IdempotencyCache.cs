using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Service.HttpCore
{
    /// <summary>
    /// 幂等性缓存
    /// </summary>
    public class IdempotencyCache
    {
        private readonly ConcurrentDictionary<string, CacheItem> _cache = new();

        private readonly TimeSpan _expire = TimeSpan.FromSeconds(5);


        public bool TryGet<T>(string key, out HttpResult<T>? result)
        {
            result = null;

            if (_cache.TryGetValue(key, out var item))
            {
                if (DateTime.UtcNow - item.Time < _expire)
                {
                    result = item.Value as HttpResult<T>;
                    return true;
                }

                _cache.TryRemove(key, out _);
            }

            return false;
        }

        public void Set<T>(string key, HttpResult<T> result)
        {
            _cache[key] = new CacheItem
            {
                Time = DateTime.UtcNow,
                Value = result
            };
        }

        private class CacheItem
        {
            public DateTime Time { get; set; }
            public object? Value { get; set; }
        }
    }
}
