using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using piyozbek.uz.DataAccess.Entities;
using piyozbek.uz.Dtos;
using Riok.Mapperly.Abstractions;

namespace piyozbek.uz.Maps;

[Mapper]
public partial class CarMapper
{
    public partial CreateCarDto CarToCarDto(Car car);

    public partial Car CarDtoToCar(CreateCarDto dto);

    public partial void UpdateCarDto(Car car, CreateCarDto dto);
}

[Mapper]
public partial class DriverMapper
{
    [MapProperty([nameof(Driver.Firstname), nameof(Driver.Lastname)], nameof(Driver.Lastname))]
    public partial DriverDto ToDto(Driver driver);

    public partial Driver ToEntity(DriverDto dto);
}