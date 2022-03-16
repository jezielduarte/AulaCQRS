
using Aula.DDD.CQRS.Application.Util;
using MediatR;
using System;

namespace Aula.DDD.CQRS.Application.User.Commands
{
    public class UpdateUserCommand : IRequest<Response>
    {
        public void SetId(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; protected set; }

        public string Pass { get; set; }

        public bool AllowsOpenAccount { get; set; }

        public bool AllowsReleaseOverdraft { get; set; }
    }
}
