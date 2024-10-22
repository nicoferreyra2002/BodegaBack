using Bodega.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bodega.Repository
{
    public class UserRepository
    {
        private readonly BodegaContext _context;

        public UserRepository(BodegaContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync(); // Obtiene todos los usuarios de la base de datos
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id); // Busca un usuario por su ID
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)); // Busca un usuario por su nombre de usuario
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user); // Agrega un nuevo usuario a la base de datos
            await _context.SaveChangesAsync(); // Guarda los cambios
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user); // Actualiza el usuario
            await _context.SaveChangesAsync(); // Guarda los cambios
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await GetUserByIdAsync(id); // Busca el usuario por su ID
            if (user != null)
            {
                _context.Users.Remove(user); // Elimina el usuario
                await _context.SaveChangesAsync(); // Guarda los cambios
            }
        }
    }
}