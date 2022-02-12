﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Domain.Interfaces
{
    public interface IUnityOfWork
    {
        public void BeginTransaction();

        public void Commit();

        public void Rollback();

    }
}