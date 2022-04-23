using Aula.DDD.CQRS.Domain.Accounts;
using Aula.DDD.CQRS.Domain.Interfaces;
using Aula.DDD.CQRS.Query.Application.Extract.Requests;
using Aula.DDD.CQRS.Query.Application.Extract.Responses;
using Aula.DDD.CQRS.Query.Application.Util;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Query.Application.Extract.Handlers
{
    public class ExtractHandler : IRequestHandler<ExtractRequest, Response>
    {
        IAccountRepository _repository;

        public ExtractHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(ExtractRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var account = await _repository.FindAccountByNumberAndAgency(request.Account, request.Agency);
                if (account is null)
                {
                    return new Response
                    {
                        Message = "Account not found",
                        StatusCode = 404
                    };
                }

                var transactions = await _repository.GetByExtractNumberAndAgency(request.Account, request.Agency);

                return new ExtractResponse
                {
                    AccountHolder = account.AccountHolder.Name,
                    AccountNumber = account.AccountNumber,
                    Agency = account.Agency,
                    Balance = account.Balance,
                    Overdraft = account.Overdraft,
                    Extract = transactions.Select(transaction => new ExtractResponseItem
                    {
                        Ammount = transaction.Ammount,
                        Date = transaction.Date,
                        Operation = transaction.Operation.ToString()
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Message = ex.Message,
                    StatusCode = 500
                };
            }
        }
    }
}
