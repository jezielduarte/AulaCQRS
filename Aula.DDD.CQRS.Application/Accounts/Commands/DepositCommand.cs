using Aula.DDD.CQRS.Application.Util;
using Aula.DDD.CQRS.Domain.Accounts;
using MediatR;
using System;

namespace Aula.DDD.CQRS.Application.Accounts.Commands
{
    public class DepositCommand : IRequest<Response>
    {
        public string Agency { get; set; }
        public string AccountNumber { get; set; }
        public decimal Ammount { get; set; }
    }
}
