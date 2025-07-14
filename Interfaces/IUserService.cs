using TestFA.Backend.WebApi.Entities;
using TestFA.Backend.WebApi.Models;

namespace TestFA.Backend.WebApi.Interfaces;

public interface IUserService
{
    AuthenticateResponse? Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User? GetById(int id);
}