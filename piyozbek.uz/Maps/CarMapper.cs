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


//public class Automapper
//{
//    public TDestination Map<TSource, TDestination>(TSource source)
//    {
//        var profile = Assembly.GetAssembly(typeof(Profile));

//        var specifications = profile.GetSpecification();

//        var sourceType = typeof(TSource);
//        var destinationType = typeof(TDestination);

//        var destinationInstance = Activator.CreateInstance(destinationType);

//        var sourceProperties = sourceType.GetProperties();

//        foreach (var sourceProperty in sourceProperties)
//        {
//            var sourcePropertyName = sourceProperty.Name;

//            var destinationProperty = destinationType.GetProperty(sourcePropertyName);

//            destinationProperty.SetValue(destinationInstance, sourceProperty.GetValue(source));
//        }
//    }
//}