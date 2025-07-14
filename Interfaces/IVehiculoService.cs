using TestFA.Backend.WebApi.Entities;
using TestFA.Backend.WebApi.Models;

namespace TestFA.Backend.WebApi.Interfaces;

public interface IVehiculoService
{
    Task<IEnumerable<Vehiculo>> GetAllVehiculos();
    Task<IEnumerable<Vehiculo>> GetAllVehiculosCatalogo();
    Task<Vehiculo> GetVehiculoById(int id);
    Task<Vehiculo> GetVehiculoByPlaca(string placa);
    Task<IEnumerable<string>> GetAllVehiculoFotos(int id);
    Task Create(VehiculoCreateRequest model);
    Task CreateFotos(string placa, IEnumerable<string> fotos);
    Task Update(VehiculoUpdateRequest model);
    Task UpdateFotos(int id, IEnumerable<string> fotos);
    Task Delete(int id);
}
