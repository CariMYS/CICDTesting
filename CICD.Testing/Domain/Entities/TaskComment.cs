using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Entities;

namespace Domain.Entities
{
    public class TaskComment : IEntity
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public Task? Task { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string Comment { get; set; }
    }
}
