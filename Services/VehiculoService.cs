namespace TestFA.Backend.WebApi.Services;

using AutoMapper;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using TestFA.Backend.WebApi.Entities;
using TestFA.Backend.WebApi.Helpers;
using TestFA.Backend.WebApi.Interfaces;
using TestFA.Backend.WebApi.Models;

public class VehiculoService : IVehiculoService
{
    private IVehiculoRepository _vehiculoRepository;
    private readonly IMapper _mapper;

    public VehiculoService(IVehiculoRepository vehiculoRepository, IMapper mapper)
    {
        _vehiculoRepository = vehiculoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Vehiculo>> GetAllVehiculos()
    {
        return await _vehiculoRepository.GetAllVehiculos();
    }

    public async Task<IEnumerable<Vehiculo>> GetAllVehiculosCatalogo()
    {
        return await _vehiculoRepository.GetAllVehiculosCatalogo();
    }

    public async Task<Vehiculo> GetVehiculoById(int id)
    {
        var vehiculo = await _vehiculoRepository.GetVehiculoById(id);

        if (vehiculo == null)
            throw new KeyNotFoundException("Vehiculo no encontrado");

        return vehiculo;
    }

    public async Task<Vehiculo> GetVehiculoByPlaca(string placa)
    {
        var vehiculo = await _vehiculoRepository.GetVehiculoByPlaca(placa);

        if (vehiculo == null)
            throw new KeyNotFoundException("Vehiculo no encontrado");

        return vehiculo;
    }

    public async Task Create(VehiculoCreateRequest model)
    {
        if (await _vehiculoRepository.GetVehiculoByPlaca(model.Vehiculo_Placa!) != null)
            throw new AppException("Vehiculo con placa '" + model.Vehiculo_Placa + "' ya existe");

        var vehiculo = _mapper.Map<Vehiculo>(model);

        await _vehiculoRepository.Create(vehiculo);
        await _vehiculoRepository.CreateFotos(vehiculo.Vehiculo_Placa, vehiculo.Vehiculo_Fotos);
    }

    public async Task CreateFotos(string placa, IEnumerable<string> fotos)
    {
        await _vehiculoRepository.CreateFotos(placa, fotos);
    }

    public async Task Delete(int id)
    {
        await _vehiculoRepository.Delete(id);
    }

    public async Task Update(VehiculoUpdateRequest model)
    {
        var vehiculo = await _vehiculoRepository.GetVehiculoById(model.Vehiculo_Id);

        if (vehiculo == null)
            throw new KeyNotFoundException("Vehiculo no encontrado");

        var placaChanged = !string.IsNullOrEmpty(model.Vehiculo_Placa) && vehiculo.Vehiculo_Placa != model.Vehiculo_Placa;
        if (placaChanged && await _vehiculoRepository.GetVehiculoByPlaca(model.Vehiculo_Placa!) != null)
            throw new AppException("Vehiculo con placa '" + model.Vehiculo_Placa + "' ya existe");

        _mapper.Map(model, vehiculo);

        await _vehiculoRepository.Update(vehiculo);
        await _vehiculoRepository.UpdateFotos(vehiculo.Vehiculo_Id, vehiculo.Vehiculo_Fotos);
    }

    public async Task UpdateFotos(int id, IEnumerable<string> fotos)
    {
        await _vehiculoRepository.UpdateFotos(id, fotos);
    }

    public async Task<IEnumerable<string>> GetAllVehiculoFotos(int id)
    {
        return await _vehiculoRepository.GetAllVehiculoFotos(id);
    }
}
