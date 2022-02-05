using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Domain.Accounts
{
    public class Transaction
    {
        public Transaction(OperationType operation, decimal ammount, Account account)
        {
            Operation = operation;
            Ammount = ammount;
            AccountId = account.Id;
        }

        public Guid Id { get; protected set; }
        public OperationType Operation { get; protected set; }
        public decimal Ammount { get; protected set; }
        public DateTime Date { get; protected set; }
        public Guid AccountId { get; protected set; }
        public Account Account { get; protected set; }
    }
}
