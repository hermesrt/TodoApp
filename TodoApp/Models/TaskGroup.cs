using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoWebApi.Models
{
    public class TaskGroup
    {
        [Key]
        public long Id { get; set; }
        public string Names { get; set; }
        public ICollection<Task> Tasks { get; set; }

        public TaskGroup()
        {
            Tasks = new HashSet<Task>();
        }
    }
}
