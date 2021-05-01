using System.ComponentModel.DataAnnotations;

namespace TodoWebApi.Models
{
    public class Todo
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsDone { get; set; }
        [Required]
        public long GroupId { get; set; }
        public TodoGroup Group { get; set; }
    }
}
