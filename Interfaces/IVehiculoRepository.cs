using TestFA.Backend.WebApi.Entities;

namespace TestFA.Backend.WebApi.Interfaces;

public interface IVehiculoRepository
{
    Task<IEnumerable<Vehiculo>> GetAllVehiculos();
    Task<IEnumerable<Vehiculo>> GetAllVehiculosCatalogo();
    Task<Vehiculo> GetVehiculoById(int id);
    Task<Vehiculo> GetVehiculoByPlaca(string placa);
    Task<IEnumerable<string>> GetAllVehiculoFotos(int id);
    Task Create(Vehiculo vehiculo);
    Task CreateFotos(string placa, IEnumerable<string> fotos);
    Task Update(Vehiculo vehiculo);
    Task UpdateFotos(int id, IEnumerable<string> fotos);
    Task Delete(int id);
}
