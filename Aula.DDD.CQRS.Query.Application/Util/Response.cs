using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Query.Application.Util
{
    public class Response
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }
    }
}
