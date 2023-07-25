using System.Text.Json;
using API.Models;

namespace API.MiddleWares;

public class ExceptionMiddleWare
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleWare> _logger;  

    private readonly IWebHostEnvironment _env;
    public ExceptionMiddleWare(RequestDelegate next, ILogger<ExceptionMiddleWare> logger, IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }
    

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            var response = _env.IsDevelopment()
                ? new ExceptionModel(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                : new ExceptionModel(context.Response.StatusCode, ex.Message, "Internal Server Error");

            var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }
    }
    
}