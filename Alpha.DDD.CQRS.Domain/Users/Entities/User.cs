using Aula.DDD.CQRS.Domain.Exeptions;
using System;
using System.Collections.Generic;

namespace Aula.DDD.CQRS.Domain.Users.Entities
{
    public class User
    {
        public User()
        {

        }
        public User(string name, string pass, bool allowsOpenAccount, bool allowsReleaseOverdraft)
        {
            UserName = name;
            Pass = pass;
            AllowsOpenAccount = allowsOpenAccount;
            AllowsReleaseOverdraft = allowsReleaseOverdraft;
            Errors = new List<BrokenRule>();
        }

        public Guid Id { get; protected set; }

        public string UserName { get; protected set; }

        public string Pass { get; protected set; }

        public bool AllowsOpenAccount { get; protected set; }

        public bool AllowsReleaseOverdraft { get; protected set; }

        public DateTime CreateDate { get; protected set; }

        public List<BrokenRule> Errors { get; protected set; }

        public bool HasErrors => Errors.Count > 0;

        public void ReleaseCreate()
        {
            if (string.IsNullOrEmpty(UserName))
                AddBrokenRule(nameof(UserName), "Name holder was not informed");

            if (string.IsNullOrEmpty(Pass))
                AddBrokenRule(nameof(Pass), "Pass holder was not informed");

            if (Pass.Length != 6)
                AddBrokenRule(nameof(Pass), "pass invalid");

            if (HasErrors)
                throw new BusinessException("Please verificar...", Errors);
        }

        public void AddBrokenRule(string field, string description)
        {
            BrokenRule rule = new BrokenRule(field, description);
            Errors.Add(rule);
        }
    }
}
