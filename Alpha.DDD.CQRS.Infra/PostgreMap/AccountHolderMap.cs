using Aula.DDD.CQRS.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Aula.DDD.CQRS.Infra.PostgreMap
{
    public class AccountHolderMap : IEntityTypeConfiguration<AccountHolder>
    {
        public void Configure(EntityTypeBuilder<AccountHolder> builder)
        {
            throw new NotImplementedException();
        }
    }
}
