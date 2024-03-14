using Domain.Entities;

namespace Domain.Services;

public interface IUserService
{
    Task<User> GetUserById(int id);
    Task<List<User>> GetAllUsers();
    Task CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
}
