using Aula.DDD.CQRS.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aula.DDD.CQRS.Infra.PostgreMap
{
    public class AccountHolderMap : IEntityTypeConfiguration<AccountHolder>
    {
        public void Configure(EntityTypeBuilder<AccountHolder> builder)
        {
            builder.ToTable("TB_ACCOUNT_HOLDER");

            builder.Property(account => account.Id)
                .HasColumnName("ID");

            builder.Property(account => account.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(account => account.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(account => account.CreateDate)
                .HasColumnName("CREATE_DATE")
                .IsRequired();

            builder.Ignore(x => x.Errors);
        }
    }
}
