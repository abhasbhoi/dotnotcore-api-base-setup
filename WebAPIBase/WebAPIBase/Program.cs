using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPIBase.BusinessLayers;
using WebAPIBase.BusinessLayers.Contracts;
using WebAPIBase.Models;
using WebAPIBase.Repository;
using WebAPIBase.Repository.Contract;
using Serilog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var MyAllowSpecificOrigins = "_apiBaseAllowSpecificOrigins";
builder.Services.AddCors(option => option.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    }));

// add services related to controller and HTTP requests
builder.Services.AddControllers();

builder.Services.AddDbContext<MyAppDBContext>(opt => opt.UseInMemoryDatabase("Employees"));
// Register instances
builder.Services.AddScoped<IEmployeeBusinessLayer, EmployeeBusinessLayer>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// Configure DBContect connection
//builder.Services.AddDbContext<MyAppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "WebAPI Base V1"
    });
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Version = "v2",
        Title = "WebAPI Base V2"
    });

    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1, 0);
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ReportApiVersions = true;
});

var app = builder.Build();


//app.MapGet("/employees", async (MyAppDBContext db) =>
//    await db.Employees.ToListAsync());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1.0");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "V2.0");
    });
}

app.UseCors(MyAllowSpecificOrigins);

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();

app.Run();

