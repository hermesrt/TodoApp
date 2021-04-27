﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoWebApi.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public ICollection<Todo> Todos { get; set; }
        public ICollection<TodoGroup> TodoGroups { get; set; }
        public User()
        {
            Todos = new HashSet<Todo>();
            TodoGroups = new HashSet<TodoGroup>();
        }
    }
}
