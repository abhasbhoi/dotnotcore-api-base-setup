using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPIBase.BusinessLayers;
using WebAPIBase.BusinessLayers.Contracts;
using WebAPIBase.Models;
using WebAPIBase.Repository;
using WebAPIBase.Repository.Contract;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

// add services related to controller and HTTP requests
builder.Services.AddControllers();

builder.Services.AddDbContext<MyAppDBContext>(opt =>opt.UseInMemoryDatabase("Employees"));
// Register instances
builder.Services.AddScoped<IEmployeeBusinessLayer, EmployeeBusinessLayer>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// Configure DBContect connection
//builder.Services.AddDbContext<MyAppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//app.MapGet("/employees", async (MyAppDBContext db) =>
//    await db.Employees.ToListAsync());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

app.Run();

