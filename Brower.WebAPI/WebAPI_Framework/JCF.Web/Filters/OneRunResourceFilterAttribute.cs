using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;

namespace JCF.Web.Filters
{
    /// <summary>
    /// 只运行一次资源过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class OneRunResourceFilterAttribute : Attribute, IAsyncResourceFilter
    {
        private static readonly ConcurrentDictionary<string, CacheItem> _cache = new ConcurrentDictionary<string, CacheItem>();

        private const int ExpireSeconds = 5;
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            // 只处理 POST
            if (!HttpMethods.IsPost(context.HttpContext.Request.Method))
            {
                await next();
                return;
            }

            var key = await BuildKeyAsync(context);

            // 命中缓存并且未过期
            if (_cache.TryGetValue(key, out var cacheItem))
            {
                if ((DateTime.UtcNow - cacheItem.CreatedAt).TotalSeconds <= ExpireSeconds)
                {
                    context.Result = cacheItem.Result;
                    return;
                }

                // 已过期，移除
                _cache.TryRemove(key, out _);
            }

            // 执行真正的 Action
            var executedContext = await next();

            if (executedContext.Result != null)
            {
                _cache[key] = new CacheItem
                {
                    Result = executedContext.Result,
                    CreatedAt = DateTime.UtcNow
                };
            }

            context.Result = executedContext.Result;
        }

        private static async Task<string> BuildKeyAsync(ResourceExecutingContext context)
        {
            var request = context.HttpContext.Request;

            // 客户端 IP
            var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

            // Path
            var path = request.Path.ToString().ToLowerInvariant();

            // POST Body
            request.EnableBuffering();

            using var reader = new StreamReader(
                request.Body,
                Encoding.UTF8,
                leaveOpen: true);

            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0;

            var bodyHash = ComputeHash(body);

            return $"{ip}:{path}:{bodyHash}";
        }

        private static string ComputeHash(string input)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToHexString(bytes);
        }

        private sealed class CacheItem
        {
            public IActionResult Result { get; set; } = default!;
            public DateTime CreatedAt { get; set; }
        }
    }
}
