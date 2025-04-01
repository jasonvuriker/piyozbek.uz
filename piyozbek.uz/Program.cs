using Microsoft.EntityFrameworkCore;
using piyozbek.uz.DataAccess;
using piyozbek.uz.DataAccess.Entities;
using piyozbek.uz.DataAccess.Repositories;
using piyozbek.uz.Dtos;
using piyozbek.uz.Maps;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICarRepository, CarRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/cars/add", async (CreateCarDto dto, ICarRepository carRepository) =>
{
    var carMapper = new CarMapper();
    var car = carMapper.CarDtoToCar(dto);
    await carRepository.Add(car);
    await carRepository.SaveChangesAsync();
})
.WithName("CreateCar")
.WithOpenApi();

app.MapGet("/api/cars/{id}", async (int id, ICarRepository carRepository)
    =>
{
    var car = await carRepository.GetById(id);

    if (car is null)
    {
        return Results.NotFound();
    }

    var carMapper = new CarMapper();
    var carDto = carMapper.CarToCarDto(car);

    return Results.Ok(carDto);
});

app.MapPut("/api/cars/{id}", async (int id, CreateCarDto dto, ICarRepository carRepository) =>
{
    var existingCar = await carRepository.GetById(id);

    var carMapper = new CarMapper();
    carMapper.UpdateCarDto(existingCar, dto);

    //carRepository


    return Results.Ok(carMapper.CarToCarDto(existingCar));
});

app.Run();