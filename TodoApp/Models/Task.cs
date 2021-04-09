using System.ComponentModel.DataAnnotations;

namespace TodoWebApi.Models
{
    public class Task
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public long TaskGroupId { get; set; }
        public TaskGroup TaskGroup { get; set; }
    }
}
