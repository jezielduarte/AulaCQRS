using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Domain.Exeptions
{
    public class BusinessException : Exception
    {
        public List<BrokenRule> Errors { get; protected set; }
        public BusinessException(string message) : base(message)
        {

        }

        public BusinessException(string message, List<BrokenRule> errors) : base(message)
        {
            Errors = errors;
        }
    }
}
