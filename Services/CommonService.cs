namespace TestFA.Backend.WebApi.Services;

using TestFA.Backend.WebApi.Entities;
using TestFA.Backend.WebApi.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

public class CommonService: ICommonService
{
    private ICommonRepository _commonRepository;

    public CommonService(ICommonRepository commonRepository)
    {
        _commonRepository = commonRepository;
    }

    public async Task<IEnumerable<Color>> GetAllColor()
    {
        return await _commonRepository.GetAllColor();
    }

    public async Task<IEnumerable<Fase>> GetAllFases()
    {
        return await _commonRepository.GetAllFases();
    }

    public async Task<IEnumerable<Marca>> GetAllMarcas()
    {
        return await _commonRepository.GetAllMarcas();
    }

    public async Task<Color> GetColorById(int id)
    {
        var color = await _commonRepository.GetColorById(id);

        if (color == null)
            throw new KeyNotFoundException("Color not found");

        return color;
    }

    public async Task<Fase> GetFaseById(int id)
    {
        var fase = await _commonRepository.GetFaseById(id);

        if (fase == null)
            throw new KeyNotFoundException("Fase not found");

        return fase;
    }

    public async Task<Marca> GetMarcaById(int id)
    {
        var marca = await _commonRepository.GetMarcaById(id);

        if (marca == null)
            throw new KeyNotFoundException("Marca not found");

        return marca;
    }
}
