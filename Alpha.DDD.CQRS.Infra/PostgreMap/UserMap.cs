using Aula.DDD.CQRS.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Aula.DDD.CQRS.Infra.PostgreMap
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
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
        }
    }
}
