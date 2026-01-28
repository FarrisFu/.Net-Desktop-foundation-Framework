using JCF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JCF.Service.HttpCore
{
    public class HttpHelper
    {
        private static readonly HttpClient _httpClient;
        private static readonly IdempotencyCache _cache = new IdempotencyCache();
        private static readonly RequestIdProvider _requestIdProvider = new RequestIdProvider();
        private static string baseUrl = "http://localhost:8090/api/";

        static HttpHelper()
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(15)
            };
        }

        /// <summary>
        /// GET 请求
        /// </summary>
        public static async Task<HttpResult<T>> GetAsync<T>(string url)
        {
            try
            {
                url = baseUrl + url;
                PrepareAuthorizationHeader();

                var response = await _httpClient.GetAsync(url);
                return await HandleResponse<T>(response);
            }
            catch (Exception ex)
            {
                return new HttpResult<T>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        /// <summary>
        /// POST 请求（JSON）
        /// </summary>
        public static async Task<HttpResult<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest data)
        {
            string body = string.Empty;
            try
            {
                //生成请求 ID
                body = JsonSerializer.Serialize(data);
                url = baseUrl + url;
                var requestId = _requestIdProvider.Generate(url, body);

                // 检查幂等性缓存
                if (_cache.TryGet(requestId, out HttpResult<TResponse>? cashed))
                {
                    return cashed!;
                }

                PrepareAuthorizationHeader();

                var content = new StringContent(body, Encoding.UTF8, "application/json");
                content.Headers.Add("Idempotency-Key", requestId);

                var response = await _httpClient.PostAsync(url, content);
                var result = await HandleResponse<TResponse>(response);
                // 存入幂等性缓存
                _cache.Set(requestId, result);

                return result;
            }
            catch (Exception ex)
            {
                LogService.Error($" POST 请求异常:url={url},body={body}", ex);
                return new HttpResult<TResponse>
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        /// <summary>
        /// 处理统一返回
        /// </summary>
        private static async Task<HttpResult<T>> HandleResponse<T>(HttpResponseMessage response)
        {
            var result = new HttpResult<T>
            {
                StatusCode = (int)response.StatusCode
            };

            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                result.Success = true;

                if (!string.IsNullOrWhiteSpace(content))
                {
                    result.Data = JsonSerializer.Deserialize<T>(content,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                }
            }
            else
            {
                result.Success = false;
                result.Message = content;
            }

            return result;
        }

        /// <summary>
        /// 自动注入 JWT
        /// </summary>
        private static void PrepareAuthorizationHeader()
        {
            var token = JwtTokenProvider.GetToken();

            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Authorization = null;
            }
        }
    }
}
