global using SMDashboardApi.Models;
global using Microsoft.EntityFrameworkCore;
using SMDashboardApi.Services.ClientServices;
using SMDashboardApi.Services.PlatformDatasetServices;
using SMDashboardApi.Services.PlatformMetricServices;
using SMDashboardApi.Services.MetricProgressServices;
using SMDashboardApi.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Additions
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IPlatformDatasetService, PlatformDatasetService>();
builder.Services.AddScoped<IPlatformMetricService, PlatformMetricService>();
builder.Services.AddScoped<IMetricProgressService, MetricProgressService>();
builder.Services.AddCors(opts => opts.AddPolicy("Unsafe", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
builder.Services.AddDbContext<DataContext>();
builder.Services.AddTransient<DataSeed>();
// So controller PUT methods can use CreatedAtRoute methods when async 
builder.Services.AddControllers(opts =>{
    opts.SuppressAsyncSuffixInActionNames = false;
    });

// Enums returned as strings
builder.Services.AddMvc().AddJsonOptions(options =>
    {
        var enumConverter = new JsonStringEnumConverter();
        options.JsonSerializerOptions.Converters.Add(enumConverter);
    });

var app = builder.Build();
// Seeding Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataSeeder.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Unsafe");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
