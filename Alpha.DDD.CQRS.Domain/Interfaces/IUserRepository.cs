using Aula.DDD.CQRS.Domain.Accounts;
using Aula.DDD.CQRS.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> FindUserByName(string name);

        Task SaveUserAsync(User user);
        
    }
}
