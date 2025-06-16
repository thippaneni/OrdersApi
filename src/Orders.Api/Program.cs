using Azure.Messaging.ServiceBus;
using Orders.Application.Interfaces;
using Orders.Application.Services;
using Orders.Infrastructure.Repositories;
using Orders.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IOrderValidationService, OrderValidationService>();
builder.Services.AddScoped<IOrderService, OrderService>();


builder.Services.AddSingleton(new ServiceBusClient(config["ServiceBus:ConnectionString"]));
builder.Services.AddScoped<IEventPublisher, AzureServicebusEventPublisher>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


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

app.Run();
