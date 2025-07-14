using TestFA.Backend.WebApi.Entities;

namespace TestFA.Backend.WebApi.Models;

public class MarcaResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public MarcaResponse(Marca marca)
    {
        Id = marca.Marca_Id;
        Nombre = marca.Marca_Nombre;
    }
}
