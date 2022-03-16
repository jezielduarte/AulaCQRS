using Aula.DDD.CQRS.Domain.Accounts;
using Aula.DDD.CQRS.Domain.Interfaces;
using Aula.DDD.CQRS.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contex;
using System.Threading.Tasks;

namespace Repository.PostgreRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly PostgreContext _context;

        public UserRepository(PostgreContext context)
        {
            _context = context;
        }

        public async Task<User> FindUserByName(string name)
        {
            return await _context.User.FirstAsync(x => x.UserName == name);
        }

        public async Task SaveUserAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
