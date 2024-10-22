using Bodega.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bodega.Entities;

namespace Bodega.Services
{
    public interface IUserService
    {
        Task<User?> AuthenticateUser(string username, string password);
        Task<List<UserDtos>> GetAllUsers();
        Task RegisterUser(UserDtos user);
        Task DeleteUser(int userId);
    }
}
