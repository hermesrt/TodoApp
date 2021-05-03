using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWebApi.Models
{
    public class User
    {
        //
        [Key]
        public long Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Salt { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<TodoGroup> TodoGroups { get; set; }
        public User()
        {
            TodoGroups = new HashSet<TodoGroup>();
        }
    }
}
