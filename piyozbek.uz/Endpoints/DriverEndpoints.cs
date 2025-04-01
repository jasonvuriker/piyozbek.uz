using piyozbek.uz.DataAccess.Entities;
using piyozbek.uz.DataAccess.Repositories;
using piyozbek.uz.Dtos;

namespace piyozbek.uz.Endpoints;

public static class DriverEndpoints
{
    public static IEndpointRouteBuilder MapDriverEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/drivers", async (IDriverRepository driverRepository) =>
        {
            var drivers = await driverRepository.GetAll();

            return Results.Ok(drivers);
        });

        endpoints.MapGet("/drivers/{id}", async (IDriverRepository driverRepository, int id) =>
        {
            var driver = await driverRepository.GetById(id);

            return Results.Ok(driver);
        });

        endpoints.MapPost("/drivers", async (IDriverRepository driverRepository, DriverDto driverDto) =>
        {
            var driver = new Driver
            {
            };

            await driverRepository.Add(driver);
            await driverRepository.SaveChangesAsync();
        });

        endpoints.MapPut("/drivers/{id}", async (IDriverRepository driverRepository, int id, DriverDto driverDto) =>
        {
            var driver = new Driver
            {
            };

            driverRepository.Update(driver);
            await driverRepository.SaveChangesAsync();
        });

        endpoints.MapDelete("/drivers/{id}", async (IDriverRepository driverRepository, int id) =>
        {
             var driver = await driverRepository.GetById(id);

             driverRepository.Delete(driver);

             await driverRepository.SaveChangesAsync();
        });

        return endpoints;
    }
}
