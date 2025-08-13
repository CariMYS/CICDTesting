using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.EntityFrameworkCore.Interfaces;
using Task = Domain.Entities.Task;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface ITaskRepository : IReadBaseRepository<Task>, IWriteBaseRepository<Task>
    {
    }
}
