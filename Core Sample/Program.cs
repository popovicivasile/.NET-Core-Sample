using Core_Sample.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Core_Sample.Repository.Abstract;
using Core_Sample.Repository.Real;

var configFileName = "Development";

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(configFileName != null ? $"appsettings.{configFileName}.json" : "appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ServiceContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("Service")));
builder.Services.AddTransient<ServiceContext>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAccount, AccountRepository>();
builder.Services.AddTransient<IMachineRepository, MachineRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ServiceContext>();
    dbContext.Database.Migrate();
}


app.Run();
