namespace TestFA.Backend.WebApi.Repositories;

using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestFA.Backend.WebApi.Entities;
using TestFA.Backend.WebApi.Helpers;
using TestFA.Backend.WebApi.Interfaces;

public class CommonRepository : ICommonRepository
{
    private DataContext _context;

    public CommonRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Color>> GetAllColor()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Color
            WHERE Color_Activo = 1
        """;
        return await connection.QueryAsync<Color>(sql);
    }

    public async Task<IEnumerable<Fase>> GetAllFases()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Fase
            WHERE Fase_Activo = 1
        """;
        return await connection.QueryAsync<Fase>(sql);
    }

    public async Task<IEnumerable<Marca>> GetAllMarcas()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Marca
            WHERE Marca_Activo = 1
        """;
        return await connection.QueryAsync<Marca>(sql);
    }

    public async Task<Color> GetColorById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Color 
            WHERE Color_Id = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<Color>(sql, new { id });
    }

    public async Task<Fase> GetFaseById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Fase 
            WHERE Fase_Id = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<Fase>(sql, new { id });
    }

    public async Task<Marca> GetMarcaById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Marca 
            WHERE Marca_Id = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<Marca>(sql, new { id });
    }
}
