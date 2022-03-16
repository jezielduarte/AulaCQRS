using Aula.DDD.CQRS.Application.Util;
using Aula.DDD.CQRS.Domain.Accounts;
using MediatR;
using System;

namespace Aula.DDD.CQRS.Application.Accounts.Commands
{
    public class OpenCheckingAccountCommand : IRequest<Response>
    {
        public string Agency { get; set; }
        public string AccountNumber { get; set; }
        public decimal InitialDeposit { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
