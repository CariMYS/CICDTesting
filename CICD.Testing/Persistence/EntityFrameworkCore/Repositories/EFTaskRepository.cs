using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.RepositoryInterfaces;
using Core.Persistence.EntityFrameworkCore;
using Persistence.EntityFrameworkCore.DbContexts;
using Task = Domain.Entities.Task;

namespace Persistence.EntityFrameworkCore.Repositories
{
    public class EFTaskRepository : EFEntityBaseRepository<Task, AppDbContext>, ITaskRepository
    {
        public EFTaskRepository(AppDbContext context) : base(context)
        {
        }
    }
}
