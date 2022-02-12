using Aula.DDD.CQRS.Domain.Interfaces;
using Repository.Contex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Infra.PostgreRepository
{
    
    public class AccountHolderRepository: IAccountHolderRepository
    {
        private readonly PostgreContext _context;

        public AccountHolderRepository(PostgreContext context)
        {
            _context = context;



        }
    }
}
