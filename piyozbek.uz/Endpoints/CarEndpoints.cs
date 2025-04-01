using piyozbek.uz.DataAccess.Repositories;
using piyozbek.uz.Dtos;
using piyozbek.uz.Maps;

namespace piyozbek.uz.Endpoints;

public static class CarEndpoints
{
    public static IEndpointRouteBuilder MapCarEndpoints(this IEndpointRouteBuilder app)
    {
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

        return app;
    }
}
