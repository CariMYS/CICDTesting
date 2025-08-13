using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.EntityFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.EntityFrameworkCore
{
    public class UnitOfWork<T> : IUnitOfWork
        where T : DbContext
    {
        public T Context { get; }

        public UnitOfWork(T context)
        {
            Context = context;
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }

        public virtual async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
