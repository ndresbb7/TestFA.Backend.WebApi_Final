namespace TestFA.Backend.WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using TestFA.Backend.WebApi.Authorization;
using TestFA.Backend.WebApi.Interfaces;

[ApiController]
[Authorize]
[Route("[controller]")]
public class CommonController : ControllerBase
{
    private ICommonService _commonService;

    public CommonController(ICommonService commonService)
    {
        _commonService = commonService;
    }

    [HttpGet("GetMarcas")]
    public async Task<IActionResult> GetAllMarcas()
    {
        var marcas = await _commonService.GetAllMarcas();
        return Ok(marcas);
    }

    [HttpGet("GetColores")]
    public async Task<IActionResult> GetAllColores()
    {
        var colores = await _commonService.GetAllColor();
        return Ok(colores);
    }

    [HttpGet("GetFases")]
    public async Task<IActionResult> GetAllFases()
    {
        var fases = await _commonService.GetAllFases();
        return Ok(fases);
    }
}
