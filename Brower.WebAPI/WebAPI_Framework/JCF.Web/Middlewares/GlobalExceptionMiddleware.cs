using JCF.Domain.Shared.Exceptions;
using JCF.Infrastructure;

namespace JCF.Web.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var traceId = context.TraceIdentifier;

            //这是使用元组解构的语法，将 switch 表达式的结果解构到三个变量中：statusCode、message 和 detail。这些变量的类型由编译器推断。
            var (statusCode, message, detail) = ex switch
            {
                InParametersException be => (be.StatusCode, be.Message, null),
                UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "未授权访问", null),
                _ => (StatusCodes.Status500InternalServerError, "服务器内部错误", ex.ToString())//_ 是一个通配符，表示任何未匹配的情况
            };

            // 记录日志（完整异常）
            LogService.Error($"TraceId: {traceId}", ex);

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new ErrorResponse
            {
                TraceId = traceId,
                StatusCode = statusCode,
                Message = message,
                Detail = context.RequestServices.GetRequiredService<IHostEnvironment>().IsDevelopment() ? detail : null//开发环境显示详细错误信息
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
