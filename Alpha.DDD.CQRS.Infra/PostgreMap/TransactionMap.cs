using Aula.DDD.CQRS.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;


namespace Aula.DDD.CQRS.Infra.PostgreMap
{
    class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            throw new NotImplementedException();
        }
    }
}
