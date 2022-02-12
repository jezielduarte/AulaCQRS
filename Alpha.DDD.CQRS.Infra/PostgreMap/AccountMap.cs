using Aula.DDD.CQRS.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Infra.PostgreMap
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {

        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(account => account.Id);

            builder.Property(account => account.Id)
                .HasColumnName("ID");

            builder.Property(account => account.Agency)
                .HasColumnName("AGENCY")
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(account => account.AccountNumber)
                .HasColumnName("NUMBER")
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(account => account.Balance)
                .HasColumnName("BALANCE")
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(account => account.Overdraft)
                .HasColumnName("OVERDRAFT")
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(account => account.UserOverdraftReleaser)
                .HasColumnName("USER_OVERDRAFT_RELEASE")
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();
        }
    }
}
