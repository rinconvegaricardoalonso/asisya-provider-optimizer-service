using Microsoft.EntityFrameworkCore;
using ProviderOptimizerService.Application.Extensions;
using ProviderOptimizerService.Infrastructure.Extensions;
using ProviderOptimizerService.Infrastructure.Persistence;
using ProviderOptimizerService.Infrastructure.Persistence.Seed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProviderDbContext>();

    dbContext.Database.Migrate();
    await ProviderSeeder.SeedAsync(dbContext);
}

if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

public partial class Program { }