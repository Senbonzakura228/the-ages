using API.Extensions;
using API.Extensions.Configuration;
using API.Extensions.Services;
using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TheAgesDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(TheAgesDBContext)), m => m.MigrationsAssembly("Data"));
});

builder.Services.AddCustomConfigurations(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAllCustomServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
