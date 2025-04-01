using Microsoft.EntityFrameworkCore;
using piyozbek.uz.DataAccess;
using piyozbek.uz.DataAccess.Entities;
using piyozbek.uz.DataAccess.Repositories;
using piyozbek.uz.Dtos;
using piyozbek.uz.Endpoints;
using piyozbek.uz.Maps;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCarEndpoints()
    .MapDriverEndpoints();



app.Run();