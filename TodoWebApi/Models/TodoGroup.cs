using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoWebApi.Models
{
    public class TodoGroup
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public ICollection<Todo> Todos { get; set; }

        public TodoGroup()
        {
            Todos = new HashSet<Todo>();
        }
    }
}
