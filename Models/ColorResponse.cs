using TestFA.Backend.WebApi.Entities;

namespace TestFA.Backend.WebApi.Models;

public class ColorResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public ColorResponse(Color color)
    {
        Id = color.Color_Id;
        Nombre = color.Color_Nombre;
    }
}
