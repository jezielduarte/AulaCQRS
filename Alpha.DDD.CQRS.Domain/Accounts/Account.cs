using Aula.DDD.CQRS.Domain.Exeptions;
using Aula.DDD.CQRS.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Domain.Accounts
{
    public class Account
    {
        public Guid Id { get; protected set; }

        public string Agency { get; protected set; }

        public string AccountNumber { get; protected set; }
        public decimal Balance { get; protected set; }

        public DateTime CreateDate { get; protected set; }

        public Guid AccountHolderId { get; protected set; }
        public AccountHolder AccountHolder { get; protected set; }

        public AccountType AccountType { get; protected set; }
        public decimal Overdraft { get; protected set; }
        public string UserOverdraftReleaser { get; protected set; }


        public List<BrokenRule> Errors { get; protected set; }

        public bool HasErrors => Errors.Count > 0;
        public decimal AvailableAmmount => Balance + Overdraft;


        //Abrir uma conta poupança
        public void OpenSavingsAccount(string agency, string accountNumber, AccountHolder accountHolder)
        {
            if (accountHolder == null)
                AddBrokenRule(nameof(AccountHolder), "uninformed account holder");

            if (HasErrors)
                throw new BusinessException("Please check the rules...", Errors);

            Agency = agency;
            AccountNumber = accountNumber;
            AccountHolderId = accountHolder.Id;
            AccountHolder = accountHolder;
        }

        //Abrir uma conta corrente
        public Transaction OpenCheckingAccount(string agency, string accountNumber, decimal amount, AccountHolder accountHolder)
        {
            if (accountHolder == null)
                AddBrokenRule(nameof(AccountHolder), "Account holder was not informed");

            if (amount < 200)
                AddBrokenRule(nameof(AccountHolder), "To open a checking account it is necessary to make a deposit of at least 200 dollars");

            if (HasErrors)
                throw new BusinessException("please check the rules...", Errors);

            Agency = agency;
            AccountNumber = accountNumber;
            AccountHolderId = accountHolder.Id;
            AccountHolder = accountHolder;

            return this.Deposit(amount);
        }

        public Transaction Deposit(decimal ammount)
        {
            if (ammount <= 0)
                throw new BusinessException("Invalid deposit amount.");

            Balance += ammount; 

            return new Transaction(OperationType.Deposit, ammount, this);
        }

        public Transaction Withdraw(decimal ammount)
        {
            if (ammount <= 0)
                throw new BusinessException("Invalid deposit amount.");

            if (AvailableAmmount < ammount)
                this.AddBrokenRule(nameof(ammount), $"Insufficient balance you have only {AvailableAmmount} dollars available");

            if (HasErrors)
                throw new BusinessException("please check the rules...", Errors);

            return new Transaction(OperationType.Withdrawal, ammount, this);
        }

        public void ReleaseOverdraft(decimal ammount, User user)
        {
            if (!user.AllowsReleaseOverdraft)
                AddBrokenRule(nameof(Overdraft), "User is not allowed to release overdraft");

            if (user.CreateDate > DateTime.Now.AddMonths(-2))
                AddBrokenRule(nameof(CreateDate), "To release overdraft the account must be at least 2 months old");

            if (AccountType == AccountType.SavingsAccount)
                AddBrokenRule(nameof(Overdraft), "Savings account is not entitled to overdraft");

            if (HasErrors)
                throw new BusinessException("please check the rules...", Errors);

            Overdraft = ammount;
            UserOverdraftReleaser = user.UserName;
        }

        public void AddBrokenRule(string field, string description)
        {
            BrokenRule rule = new BrokenRule(field, description);
            Errors.Add(rule);
        }
    }
}
