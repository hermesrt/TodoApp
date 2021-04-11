using System.ComponentModel.DataAnnotations;

namespace TodoWebApi.Models
{
    public class Todo
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsDone { get; set; }
        public long GroupId { get; set; }
        public TodoGroup Group { get; set; }
    }
}
