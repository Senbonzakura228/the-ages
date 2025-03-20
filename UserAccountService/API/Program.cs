using API.Extensions;
using Application.Authentication;
using Application.Services;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using API.Extensions.Services;
using System.Text.Json;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFluentValidation();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserAccountDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly("Infrastructure"));
});

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddScoped<JwtOptions>();
builder.Services.AddScoped<JwtGenerator>();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddScoped<UserAccountRepository>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", h =>
      {
          h.Username("guest");
          h.Password("guest");
      });
    });
});
builder.Services.AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";
        var response = new
        {
            status = "Healthy",
            checks = report.Entries.Select(e => new
            {
                name = e.Key,
                status = "Healthy",
                exception = e.Value.Exception?.Message,
                duration = e.Value.Duration.ToString()
            })
        };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
});
app.MapControllers();
app.Run();

