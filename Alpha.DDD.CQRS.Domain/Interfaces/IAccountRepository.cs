using Aula.DDD.CQRS.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> FindAccountByNumberAndAgency(string number, string Agency);

        Task<AccountHolder> FindAccountHolderById(Guid id);

        Task<IList<Transaction>> GetByAccountNumberAndAgency(string accountNumber, string Agency);

        Task SaveAccountAsync(Account account);

        Task SaveAllAsync(IList<Account> accounts);

        Task UpdateAccountAsync(Account account);

        Task SaveAccoutHolderAsync(AccountHolder holder);

        Task SaveTransactioAsync(Transaction transaction);
    }
}
