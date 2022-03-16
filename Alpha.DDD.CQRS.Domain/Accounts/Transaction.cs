using System;

namespace Aula.DDD.CQRS.Domain.Accounts
{
    public class Transaction
    {
        public Transaction()
        {

        }
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
