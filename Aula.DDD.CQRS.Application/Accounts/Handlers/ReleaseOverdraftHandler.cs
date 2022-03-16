using Aula.DDD.CQRS.Application.Accounts.Commands;
using Aula.DDD.CQRS.Application.Util;
using Aula.DDD.CQRS.Domain.Accounts;
using Aula.DDD.CQRS.Domain.Exeptions;
using Aula.DDD.CQRS.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Application.Accounts.Handlers
{
    public class ReleaseOverdraftHandler : IRequestHandler<ReleaseOverdraftCommand, Response>
    {
        private readonly IAccountRepository _repository;
        private readonly IUserRepository _userRepository;
        public ReleaseOverdraftHandler(IAccountRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<Response> Handle(ReleaseOverdraftCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //pega no banco a conta do cliente
                var account = await _repository.FindAccountByNumberAndAgency(request.AccountNumber, request.Agency);

                //pega o usuario no banco
                var user = await _userRepository.FindUserByName(request.User);

                //Libera o cheque especial
                account.ReleaseOverdraft(request.Ammount, user);

                //salva a conta com o novo cheque especial
                await _repository.UpdateAccountAsync(account);

                //retona o response com status code 200
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
