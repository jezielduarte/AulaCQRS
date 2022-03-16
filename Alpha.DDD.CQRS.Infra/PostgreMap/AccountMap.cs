using Aula.DDD.CQRS.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aula.DDD.CQRS.Infra.PostgreMap
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {

        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("TB_ACCOUNT");

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

            builder.Property(account => account.AccountHolderId)
                .HasColumnName("ACCOUNT_HOLDER_ID")
                .IsRequired();

            builder.Property(account => account.AccountType)
                .HasColumnName("ACCOUNT_TYPE")
                .IsRequired();

            builder.Property(account => account.CreateDate)
                .HasColumnName("CREATE_DATE")
                .IsRequired();

            builder.Ignore(x => x.Errors);
        }
    }
}
