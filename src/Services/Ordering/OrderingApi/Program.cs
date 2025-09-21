using OrderingApi;
using OrderingApplication;
using OrderingInfrastrueture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();


var app = builder.Build();

// Congigure the http request pipeline.

app.Run();
