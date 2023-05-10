using IdGen.DependencyInjection;
using Kshop.Infra.Persistence.EntityFrameWork;
using Kshop.Infra.Persistence.EntityFrameWork.Customers;
using Kshop.Infra.Persistence.EntityFrameWork.Orders;
using Kshop.Infra.Persistence.EntityFrameWork.Shipments;
using KShop.Application.DomainApplication.CommandHandlers.Customers;
using KShop.Core.Domain.Customers;
using KShop.Core.Domain.Orders;
using KShop.Core.Domain.Shipments;
using KShop.Endpoint.Api.Middlewares;
using KShop.EndPoint.Subscriber.EventHandlers.Orders;
using KShop.FrameWork.SharedFrameWork.AppSettingsConfiguration;
using KShop.Infra.Query.EntityFrameWork;
using KShop.Infra.Query.EntityFrameWork.Contracts;
using KShop.Infra.Query.EntityFrameWork.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdGen(123);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, 
    typeof(CreateCustomerCommandHandler).Assembly,
    typeof(CreateOrderEventHandler).Assembly));


builder.Services.AddDbContext<KShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString"),
        x => x.MigrationsHistoryTable("__EFMigrationsHistory"));
});
builder.Services.AddDbContext<KShopQueryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString"));
});
builder.Services.AddScoped<DbContext,  KShopDbContext>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
builder.Services.AddScoped<IShipmentQueryRepository, ShipmentQueryRepository>();
builder.Services.Configure<MinPriceConfig>(builder.Configuration.GetSection("MinPriceConfig"));
builder.Services.Configure<ValidShopTimeConfig>(builder.Configuration.GetSection("ValidShopTimeConfig"));

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

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
