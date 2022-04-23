using Aula.DDD.CQRS.Query.Application.Extract.Responses;
using Aula.DDD.CQRS.Query.Application.Util;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Query.Application.Extract.Requests
{
    public class ExtractRequest : IRequest<Response>
    {
        public string Account { get; set; }
        public string Agency { get; set; }
    }
}
