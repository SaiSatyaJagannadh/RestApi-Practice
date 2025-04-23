using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.SqlServer;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using WebAPIPractice.Utility;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();




builder.Services.AddDbContext<EcommerceDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDB"));

});

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

// Services
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();

builder.Services.AddAutoMapper(typeof(ApplicationMapping));

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();


app.Run();


//we use routing 
app.UseRouting();
