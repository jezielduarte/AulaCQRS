
using Aula.DDD.CQRS.Application.Util;
using MediatR;
using System;

namespace Aula.DDD.CQRS.Application.User.Commands
{
    public class DeleteUserCommand : IRequest<Response>
    {
        public Guid UserId { get; set; }

        public DeleteUserCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
