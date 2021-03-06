using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoWebApi.Models
{
    public class TodoGroup
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long UserId { get; set; }
        [Required]
        public long Priority { get; set; }
        public ICollection<Todo> Todos { get; set; }

        public TodoGroup()
        {
            Todos = new HashSet<Todo>();
        }
    }
}
