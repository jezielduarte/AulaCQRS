using Aula.DDD.CQRS.Application.Account.Commands;
using Aula.DDD.CQRS.Application.Util;
using Aula.DDD.CQRS.Domain.Exeptions;
using Aula.DDD.CQRS.Domain.Interfaces;
using Aula.DDD.CQRS.Domain.Users.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Application.Account.Handlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, Response>
    {
        private readonly IAccountRepository _repository;
        public async Task<Response> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var account = new Domain.Accounts.Account();
                await _repository.SaveAccountAsync(account);

                return new Response { Message = "Success", StatusCode = 200 };

            }
            catch (BusinessException ex)
            {
                return new Response { Message = ex.Message, StatusCode = 400 };
            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, StatusCode = 500 };
            }
        }
    }
}
