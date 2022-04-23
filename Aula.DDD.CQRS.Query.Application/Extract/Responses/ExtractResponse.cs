using Aula.DDD.CQRS.Query.Application.Util;
using System;
using System.Collections.Generic;

namespace Aula.DDD.CQRS.Query.Application.Extract.Responses
{
    public class ExtractResponse : Response
    {
        public string AccountHolder { get; set; }
        public decimal Balance { get; set; }
        public string Agency { get; set; }
        public string AccountNumber { get; set; }
        public decimal Overdraft { get; set; }
        public decimal AvailableAmmount => Balance + Overdraft;

        public List<ExtractResponseItem> Extract { get; set; }
    }

    public class ExtractResponseItem
    {
        public DateTime Date { get; set; }
        public string Operation { get; set; }
        public decimal Ammount { get; set; }
    }
}
