using Aula.DDD.CQRS.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aula.DDD.CQRS.Infra.PostgreMap
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TB_USER");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id)
                .HasColumnName("ID");

            builder.Property(user => user.UserName)
                .HasColumnName("USER_NAME")
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(user => user.Pass)
                .HasColumnName("PASS")
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(user => user.AllowsOpenAccount)
                .HasColumnName("ALLOWS_OPEN_ACCOUNT")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(user => user.AllowsReleaseOverdraft)
                .HasColumnName("ALLOWS_RELEASE_OVERDRAFT")
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(user => user.CreateDate)
                .HasColumnName("CREATE_DATE")
                .IsRequired();

            builder.Ignore(x => x.Errors);
        }
    }
}
