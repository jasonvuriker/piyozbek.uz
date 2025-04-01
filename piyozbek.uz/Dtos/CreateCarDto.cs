using piyozbek.uz.DataAccess.Entities;

namespace piyozbek.uz.Dtos;

public class CreateCarDto
{
    public string Name { get; set; }

    public CarBrand Brand { get; set; }

    public decimal Price { get; set; }

    public int ManufacturedYear { get; set; }
}
