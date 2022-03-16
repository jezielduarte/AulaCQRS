using Aula.DDD.CQRS.Domain.Accounts;
using Aula.DDD.CQRS.Domain.Users.Entities;
using Aula.DDD.CQRS.Infra.PostgreMap;
using Microsoft.EntityFrameworkCore;

namespace Repository.Contex
{
    public class PostgreContext : DbContext
    {
        public PostgreContext(DbContextOptions<PostgreContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        public DbSet<Account> Account { get; set; }

        public DbSet<AccountHolder> AccountHolder { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new AccountHolderMap());
            modelBuilder.ApplyConfiguration(new TransactionMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
