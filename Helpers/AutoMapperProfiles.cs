namespace TestFA.Backend.WebApi.Helpers;

using AutoMapper;
using TestFA.Backend.WebApi.Entities;
using TestFA.Backend.WebApi.Models;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<VehiculoCreateRequest, Vehiculo>();
        CreateMap<VehiculoUpdateRequest, Vehiculo>();
    }
}