namespace TestFA.Backend.WebApi.Services;

using TestFA.Backend.WebApi.Entities;
using TestFA.Backend.WebApi.Authorization;
using TestFA.Backend.WebApi.Models;
using TestFA.Backend.WebApi.Interfaces;

public class UserService : IUserService
{
    private List<User> _users = new List<User>
    {
        new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
    };

    private readonly IJwtUtils _jwtUtils;

    public UserService(IJwtUtils jwtUtils)
    {
        _jwtUtils = jwtUtils;
    }

    public AuthenticateResponse? Authenticate(AuthenticateRequest model)
    {
        var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

        if (user == null) return null;

        var token = _jwtUtils.GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public IEnumerable<User> GetAll()
    {
        return _users;
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(x => x.Id == id);
    }
}