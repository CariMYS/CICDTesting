using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.EntityFrameworkCore.Interfaces;
using Domain.Entities;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface ITaskCommentRepository : IReadBaseRepository<TaskComment>, IWriteBaseRepository<TaskComment>
    {
    }
}
