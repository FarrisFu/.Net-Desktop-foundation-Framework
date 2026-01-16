using log4net;
using System.Text;

public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private static readonly ILog _requestLogger = LogManager.GetLogger("RequestLogger");

    public RequestResponseLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // 读取请求体
        context.Request.EnableBuffering();
        var requestBody = await ReadStreamAsync(context.Request.Body);
        context.Request.Body.Position = 0;

        var originalBodyStream = context.Response.Body;
        await using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        try
        {
            await _next(context);

            // 仅在“正常响应”时记录响应体
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            _requestLogger.Info($"""
                {context.Request.Method} {context.Request.Path}
                Request: {requestBody}
                Response: {responseText}
                StatusCode: {context.Response.StatusCode}
                """);

            //将响应体写回原始流
            await responseBody.CopyToAsync(originalBodyStream);
        }
        catch (Exception ex)
        {
            // 记录异常请求
            _requestLogger.Error($"""
                {context.Request.Method} {context.Request.Path}
                Request: {requestBody}
                Exception: {ex}
                """);

            // 恢复原始流
            context.Response.Body = originalBodyStream;

            // 重新抛出异常
            throw;
        }
        finally
        {
            context.Response.Body = originalBodyStream;
        }
    }

    private static async Task<string> ReadStreamAsync(Stream stream)
    {
        using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);
        return await reader.ReadToEndAsync();
    }
}
