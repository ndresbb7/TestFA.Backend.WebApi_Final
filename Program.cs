
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using TestFA.Backend.WebApi.Authorization;
using TestFA.Backend.WebApi.Entities;
using TestFA.Backend.WebApi.Helpers;
using TestFA.Backend.WebApi.Interfaces;
using TestFA.Backend.WebApi.Models;
using TestFA.Backend.WebApi.Repositories;
using TestFA.Backend.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddCors();
    services.AddControllers().AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

    services.AddAutoMapper(cfg =>
    {
        cfg.CreateMap<VehiculoCreateRequest, Vehiculo>();
        cfg.CreateMap<VehiculoUpdateRequest, Vehiculo>();
    });

    services.AddSingleton<DataContext>();
    services.AddScoped<IJwtUtils, JwtUtils>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<ICommonService, CommonService>();
    services.AddScoped<ICommonRepository, CommonRepository>();
    services.AddScoped<IVehiculoService, VehiculoService>();
    services.AddScoped<IVehiculoRepository, VehiculoRepository>();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Description = "Enter token",
            Name = "Authorization",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });

        options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "bearer"
                    }
                },
                new string []{ }
            }
        });
    });
}

var app = builder.Build();

{
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<DataContext>();
//context.Init();
}

{
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.UseMiddleware<JwtMiddleware>();
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.MapControllers();
}

app.UseSwagger();
app.UseSwaggerUI();

app.Run("http://localhost:4000");