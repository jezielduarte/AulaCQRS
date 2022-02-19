using Aula.DDD.CQRS.Application.Util;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
