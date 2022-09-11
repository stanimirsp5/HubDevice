using HubDevice.Data;
using HubDevice.Repository;
using HubDevice.Services;
using HubDevice.Services.Interfaces;
using Newtonsoft.Json.Serialization;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
//Enable CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
});
//JSON Serializer
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(opt =>
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(opt =>
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddDbContext<hubdeviceContext>(opt =>

    opt.UseNpgsql(configuration.GetConnectionString("HubAppCon"))
);
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICacheRepository, CacheRepository>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

var app = builder.Build();

app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

