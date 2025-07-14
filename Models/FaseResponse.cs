using TestFA.Backend.WebApi.Entities;

namespace TestFA.Backend.WebApi.Models;

public class FaseResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public FaseResponse(Fase fase)
    {
        Id = fase.Fase_Id;
        Nombre = fase.Fase_Nombre;
    }
}
