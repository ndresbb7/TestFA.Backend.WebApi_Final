
namespace TestFA.Backend.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using TestFA.Backend.WebApi.Authorization;
using TestFA.Backend.WebApi.Interfaces;
using TestFA.Backend.WebApi.Models;
using TestFA.Backend.WebApi.Services;

[ApiController]
[Authorize]
[Route("[controller]")]

public class VehiculoController : ControllerBase
{
    private IVehiculoService _vehiculoService;

    public VehiculoController(IVehiculoService vehiculoService)
    {
        _vehiculoService = vehiculoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _vehiculoService.GetAllVehiculos();
        return Ok(users);
    }

    [HttpGet("GetVehiculosCatalogo")]
    public async Task<IActionResult> GetAllCatalogo()
    {
        var users = await _vehiculoService.GetAllVehiculosCatalogo();
        return Ok(users);
    }

    [HttpGet("GetFotosVehiculo")]
    public async Task<IActionResult> GetFotosVehiculo(int id)
    {
        var users = await _vehiculoService.GetAllVehiculoFotos(id);
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _vehiculoService.GetVehiculoById(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(VehiculoCreateRequest model)
    {
        await _vehiculoService.Create(model);
        return Ok(new { message = "Vehiculo creado" });
    }

    [HttpPut]
    public async Task<IActionResult> Update(VehiculoUpdateRequest model)
    {
        await _vehiculoService.Update(model);
        return Ok(new { message = "Vehiculo actualizado" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _vehiculoService.Delete(id);
        return Ok(new { message = "Vehiculo eliminado" });
    }
}
