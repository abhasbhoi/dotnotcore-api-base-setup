using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPIBase.BusinessLayers;
using WebAPIBase.BusinessLayers.Contracts;
using WebAPIBase.Repository;


var builder = WebApplication.CreateBuilder(args);

// add services related to controller and HTTP requests
builder.Services.AddControllers();

// Register instances
builder.Services.AddScoped<IEmployeeBusinessLayer, EmployeeBusinessLayer>();

// Configure DBContect connection
builder.Services.AddDbContext<MyAppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.Run();

