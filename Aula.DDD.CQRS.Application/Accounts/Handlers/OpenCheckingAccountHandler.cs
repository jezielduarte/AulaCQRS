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
    public class OpenCheckingAccountHandler : IRequestHandler<OpenCheckingAccountCommand, Response>
    {
        private readonly IAccountRepository _repository;
        private readonly IUnityOfWork _unityOfWork;
        public OpenCheckingAccountHandler(IAccountRepository repository, IUnityOfWork unityOfWork)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
        }

        public async Task<Response> Handle(OpenCheckingAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _unityOfWork.BeginTransaction();

                //Cria o holder
                var holder = new AccountHolder(request.Name, request.Email);
                //Verifica erros de negocio
                holder.ReleaseSave();
                //salva no banco
                await _repository.SaveAccoutHolderAsync(holder);
                
                //Cria a conta
                var account = new Account();
                
                //Abre a conta passando o holder cadastrado e o deposito inicial
                var transaction = account.OpenCheckingAccount(request.Agency, request.AccountNumber,request.InitialDeposit, holder);

                //salva account no banco de dados
                await _repository.SaveAccountAsync(account);

                //salva a transação do deposito inicial
                await _repository.SaveTransactioAsync(transaction);

                _unityOfWork.Commit();
                
                //retona o response com status code 200
                return new Response { Message = "Success", StatusCode = 200 };

            }
            catch (BusinessException ex)
            {
                _unityOfWork.Rollback();
                return new Response { Message = ex.Message, StatusCode = 400 };
            }
            catch (Exception ex)
            {
                _unityOfWork.Rollback();
                return new Response { Message = ex.Message, StatusCode = 500 };
            }
        }
    }
}
