using Aula.DDD.CQRS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Contex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly PostgreContext _context;
        private IDbContextTransaction _transaction;

        public UnityOfWork(PostgreContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
