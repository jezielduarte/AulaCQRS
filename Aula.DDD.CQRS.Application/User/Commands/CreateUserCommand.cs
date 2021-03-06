
using Aula.DDD.CQRS.Application.Util;
using MediatR;

namespace Aula.DDD.CQRS.Application.User.Commands
{
    public class CreateUserCommand : IRequest<Response>
    {
        public string UserName { get; set; }

        public string Pass { get; set; }

        public bool AllowsOpenAccount { get; set; }

        public bool AllowsReleaseOverdraft { get; set; }
    }
}
