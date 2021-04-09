using System.ComponentModel.DataAnnotations;

namespace TodoWebApi.Models
{
    public class Todo
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public long TaskGroupId { get; set; }
        public TodoGroup TaskGroup { get; set; }
    }
}
