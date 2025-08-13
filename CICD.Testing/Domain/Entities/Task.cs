using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Entities;
using Domain.Enums;

namespace Domain.Entities
{
    public class Task : IEntity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public Enums.TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public IEnumerable<TaskComment>? TaskComments { get; set; }
    }
}
