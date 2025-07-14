namespace TestFA.Backend.WebApi.Repositories;

using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestFA.Backend.WebApi.Entities;
using TestFA.Backend.WebApi.Helpers;
using TestFA.Backend.WebApi.Interfaces;

public class VehiculoRepository: IVehiculoRepository
{
    private DataContext _context;

    public VehiculoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vehiculo>> GetAllVehiculos()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Vehiculo
        """;
        return await connection.QueryAsync<Vehiculo>(sql);
    }

    public async Task<IEnumerable<Vehiculo>> GetAllVehiculosCatalogo()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT veh.* FROM Vehiculo veh
            INNER JOIN Fase fas ON fas.Fase_Id = veh.Vehiculo_Fase
            WHERE fas.Fase_Nombre <> 'Vendido'
        """;
        return await connection.QueryAsync<Vehiculo>(sql);
    }

    public async Task<Vehiculo> GetVehiculoById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Vehiculo 
            WHERE Vehiculo_Id = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<Vehiculo>(sql, new { id });
    }

    public async Task Create(Vehiculo vehiculo)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            INSERT INTO Vehiculo (Vehiculo_Placa, Vehiculo_Color, Vehiculo_Marca, Vehiculo_Linea, Vehiculo_Anio, Vehiculo_KM, Vehiculo_Valor, Vehiculo_Observaciones, Vehiculo_Fase)
            VALUES (@Vehiculo_Placa, @Vehiculo_Color, @Vehiculo_Marca, @Vehiculo_Linea, @Vehiculo_Anio, @Vehiculo_KM, @Vehiculo_Valor, @Vehiculo_Observaciones, @Vehiculo_Fase)
        """;
        await connection.ExecuteAsync(sql, vehiculo);
    }

    public async Task Update(Vehiculo vehiculo)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            UPDATE Vehiculo 
            SET Vehiculo_Placa = @Vehiculo_Placa,
                Vehiculo_Color = @Vehiculo_Color,
                Vehiculo_Marca = @Vehiculo_Marca, 
                Vehiculo_Linea = @Vehiculo_Linea, 
                Vehiculo_Anio = @Vehiculo_Anio, 
                Vehiculo_KM = @Vehiculo_KM, 
                Vehiculo_Valor = @Vehiculo_Valor,
                Vehiculo_Observaciones = @Vehiculo_Observaciones,
                Vehiculo_Fase = @Vehiculo_Fase,
            WHERE Vehiculo_Id = @Vehiculo_Id
        """;
        await connection.ExecuteAsync(sql, vehiculo);
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            DELETE FROM Vehiculo 
            WHERE Vehiculo_Id = @id
        """;
        await connection.ExecuteAsync(sql, new { id });
    }

    public async Task<Vehiculo> GetVehiculoByPlaca(string placa)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Vehiculo 
            WHERE Vehiculo_Placa = @placa
        """;
        return await connection.QuerySingleOrDefaultAsync<Vehiculo>(sql, new { placa });
    }

    public async Task CreateFotos(string placa, IEnumerable<string> fotos)
    {
        using var connection = _context.CreateConnection();
        Vehiculo veh = await GetVehiculoByPlaca(placa);

        foreach (var foto in fotos)
        {
            var sql = """
                INSERT INTO Vehiculo_Foto (Vehiculo_Foto_Vehiculo, Vehiculo_Foto_Filename)
                VALUES (@Vehiculo_Id, @foto)
            """;
            await connection.ExecuteAsync(sql, new { veh.Vehiculo_Id, foto });
        }
    }

    public async Task UpdateFotos(int id, IEnumerable<string> fotos)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            DELETE FROM Vehiculo _Foto
            WHERE Vehiculo_Foto_Vehiculo = @id
        """;
        await connection.ExecuteAsync(sql, new { id });

        foreach (var foto in fotos)
        {
            var sql2 = """
                INSERT INTO Vehiculo_Foto (Vehiculo_Foto_Vehiculo, Vehiculo_Foto_Filename)
                VALUES (@id, @foto)
            """;
            await connection.ExecuteAsync(sql2, new { id, foto });
        }
    }

    public async Task<IEnumerable<string>> GetAllVehiculoFotos(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT Vehiculo_Foto_Filename FROM Vehiculo_Foto
            WHERE Vehiculo_Foto_Vehiculo = @id
        """;
        return await connection.QueryAsync<string>(sql, new { id });
    }
}
