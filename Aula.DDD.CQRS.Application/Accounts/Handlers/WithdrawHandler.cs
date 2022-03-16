using Aula.DDD.CQRS.Application.Accounts.Commands;
using Aula.DDD.CQRS.Application.Util;
using Aula.DDD.CQRS.Domain.Exeptions;
using Aula.DDD.CQRS.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Application.Accounts.Handlers
{
    public class WithdrawHandler : IRequestHandler<WithdrawCommand, Response>
    {
        private readonly IAccountRepository _repository;
        private readonly IUnityOfWork _unityOfWork;
        public WithdrawHandler(IAccountRepository repository, IUnityOfWork unityOfWork)
        {
            _repository = repository;
            _unityOfWork = unityOfWork;
        }

        public async Task<Response> Handle(WithdrawCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //inicial a transação na unidade de trabalho
                _unityOfWork.BeginTransaction();

                //pega no banco a conta do cliente
                var accout = await _repository.FindAccountByNumberAndAgency(request.AccountNumber, request.Agency);

                //realiza o deposito
                var transaction = accout.Withdraw(request.Ammount);

                //salva a conta com o novo saldo
                await _repository.UpdateAccountAsync(accout);

                //salva a transação
                await _repository.SaveTransactioAsync(transaction);

                //comita a transação na unidade de trabalho
                _unityOfWork.Commit();

                //retona o response com status code 200
                return new Response { Message = "Success", StatusCode = 200 };

            }
            catch (BusinessException ex)
            {
                //cancela a transação na unidade de trabalho
                _unityOfWork.Rollback();
                return new Response { Message = ex.Message, StatusCode = 400 };
            }
            catch (Exception ex)
            {
                //cancela a transação na unidade de trabalho
                _unityOfWork.Rollback();
                return new Response { Message = ex.Message, StatusCode = 500 };
            }
        }
    }
}
