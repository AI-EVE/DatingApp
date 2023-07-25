using API.Extensions;
using API.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleWare>();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseCors(policy => policy.WithOrigins("https://localhost:4200").AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
