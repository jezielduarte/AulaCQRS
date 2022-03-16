using Aula.DDD.CQRS.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aula.DDD.CQRS.Infra.PostgreMap
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("TB_TRANSACTION");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
                .HasColumnName("ID");

            builder.Property(user => user.Date)
                .HasColumnName("DATE")
                .IsRequired();

            builder.Property(user => user.Operation)
                .HasColumnName("OPERATION")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(user => user.Ammount)
                .HasColumnName("AMMOUNT")
                .IsRequired();

            builder.Property(user => user.Date)
                .HasColumnName("DATE")
                .IsRequired();

            builder.Property(user => user.AccountId)
                .HasColumnName("ACCOUNT_ID")
                .IsRequired();

        }
    }
}
