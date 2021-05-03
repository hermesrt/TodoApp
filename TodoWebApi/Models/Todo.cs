using System.ComponentModel.DataAnnotations;

namespace TodoWebApi.Models
{
    public class Todo
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsDone { get; set; }
        [Required]
        public long GroupId { get; set; }
        [Required]
        public long Priority { get; set; }
        public TodoGroup Group { get; set; }
    }
}
