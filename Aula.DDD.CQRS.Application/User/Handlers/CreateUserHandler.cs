using Aula.DDD.CQRS.Application.User.Commands;
using Aula.DDD.CQRS.Application.Util;
using Aula.DDD.CQRS.Domain.Exeptions;
using Aula.DDD.CQRS.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Application.User.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Response>
    {
        private readonly IUserRepository _repository;

        public CreateUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new Domain.Users.Entities.User(request.UserName, request.Pass, request.AllowsOpenAccount, request.AllowsReleaseOverdraft);

                user.ReleaseCreate();

                await _repository.SaveUserAsync(user);

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
