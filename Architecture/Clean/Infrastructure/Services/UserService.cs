using Domain.Entities;
using Domain.Interfaces;
using Domain.Services;

namespace Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserById(int id)
    {
        return await _userRepository.GetUserById(id);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _userRepository.GetAllUsers();
    }

    public async Task CreateUser(User user)
    {
        await _userRepository.CreateUser(user);
    }

    public async Task UpdateUser(User user)
    {
        await _userRepository.UpdateUser(user);
    }

    public async Task DeleteUser(int id)
    {
        await _userRepository.DeleteUser(id);
    }
}
