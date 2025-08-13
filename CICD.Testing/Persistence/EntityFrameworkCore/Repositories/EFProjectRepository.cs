using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.RepositoryInterfaces;
using Core.Persistence.EntityFrameworkCore;
using Domain.Entities;
using Persistence.EntityFrameworkCore.DbContexts;

namespace Persistence.EntityFrameworkCore.Repositories
{
    public class EFProjectRepository : EFEntityBaseRepository<Project, AppDbContext>, IProjectRepository
    {
        public EFProjectRepository(AppDbContext context) : base(context)
        {
        }
    }
}
