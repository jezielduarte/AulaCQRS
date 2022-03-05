using Aula.DDD.CQRS.Application.Util;
using Aula.DDD.CQRS.Domain.Accounts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Application.Account.Commands
{
    public class CreateAccountCommand:IRequest<Response>
    {
        public string Agency { get; protected set; }

        public string AccountNumber { get; protected set; }
        public decimal Balance { get; protected set; }

        public DateTime CreateDate { get; protected set; }

        public Guid AccountHolderId { get; protected set; }
        public AccountHolder AccountHolder { get; protected set; }

        public AccountType AccountType { get; protected set; }
        public decimal Overdraft { get; protected set; }
        public string UserOverdraftReleaser { get; protected set; }
    }
}
