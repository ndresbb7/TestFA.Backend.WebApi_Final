namespace TestFA.Backend.WebApi.Interfaces;

using TestFA.Backend.WebApi.Entities;

public interface ICommonService
{
    Task<IEnumerable<Marca>> GetAllMarcas();
    Task<Marca> GetMarcaById(int id);
    Task<IEnumerable<Color>> GetAllColor();
    Task<Color> GetColorById(int id);
    Task<IEnumerable<Fase>> GetAllFases();
    Task<Fase> GetFaseById(int id);
}
