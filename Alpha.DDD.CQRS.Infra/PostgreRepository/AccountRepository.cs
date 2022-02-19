using Aula.DDD.CQRS.Domain.Accounts;
using Aula.DDD.CQRS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repository.Contex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.PostgreRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly PostgreContext _context;

        public AccountRepository(PostgreContext context)
        {
            _context = context;
        }

        public async Task<Account> FindAccountByNumberAndAgency(string number, string Agency)
        {
            return await _context.Account.FirstAsync(x => x.AccountNumber == number && x.Agency == Agency);
        }

        public async Task<AccountHolder> FindAccountHolderById(Guid id)
        {
            return await _context.AccountHolder.FindAsync(id);
        }

        public async Task<IList<Transaction>> GetByAccountNumberAndAgency(string accountNumber, string Agency)
        {
            return await _context.Transactions.Where(x=> x.Account.AccountNumber == accountNumber && x.Account.Agency == Agency).ToListAsync();
        }

        public async Task SaveAccountAsync(Account account)
        {
            //await _context.Account.AddAsync(account);

            _context.Entry(account).State = EntityState.Added;

            await _context.SaveChangesAsync();
        }

        public async Task SaveAllAsync(IList<Account> accounts)
        {
            //await _context.Account.AddAsync(account);

            await _context.AddRangeAsync(accounts);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Account.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task SaveAccoutHolderAsync(AccountHolder holder)
        {
            await _context.AddAsync(holder);
            await _context.SaveChangesAsync();
        }

        public async Task SaveTransactioAsync(Transaction transaction)
        {
            await _context.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
