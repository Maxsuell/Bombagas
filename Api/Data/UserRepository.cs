using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{

    public class UserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<string>> GetUser()
        {
            return await _context.userApps.Select(u => u.Name).ToListAsync();

        }

        public void AddUser(UserApp user)
        {
            _context.userApps?.Add(user);
            
        }

        
    }

}