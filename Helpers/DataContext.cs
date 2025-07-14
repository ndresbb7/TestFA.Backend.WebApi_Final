namespace TestFA.Backend.WebApi.Helpers;

using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

public class DataContext
{
    private DbSettings _dbSettings;

    public DataContext(IOptions<DbSettings> dbSettings)
    {
        _dbSettings = dbSettings.Value;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = $"Server={_dbSettings.Server}; Database={_dbSettings.Database}; User Id={_dbSettings.UserId}; Password={_dbSettings.Password};TrustServerCertificate=true;";
        return new SqlConnection(connectionString);
    }

    public void Init()
    {
    }
}