using Aula.DDD.CQRS.Domain.Exeptions;
using System;
using System.Collections.Generic;

namespace Aula.DDD.CQRS.Domain.Accounts
{
    public class AccountHolder
    {
        public AccountHolder(string name, string email)
        {
            Name = name;
            Email = email;
            Errors = new List<BrokenRule>();
        }

        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public DateTime CreateDate { get; protected set; }

        public List<BrokenRule> Errors { get; protected set; }

        public bool HasErrors => Errors.Count > 0;

        public void AddBrokenRule(string field, string description)
        {
            BrokenRule rule = new BrokenRule(field, description);
            Errors.Add(rule);
        }

        public void ReleaseSave()
        {
            if (string.IsNullOrEmpty(Name))
                AddBrokenRule(nameof(Name), "name not informed");

            if (string.IsNullOrEmpty(Email))
                AddBrokenRule(nameof(Email), "Email not informed");

            if (!Email.Contains("@"))
                AddBrokenRule(nameof(Email), "Email invalid");

            if (HasErrors)
                throw new BusinessException("Please verificar...", Errors);

            CreateDate = DateTime.Today;
        }
    }
}
