using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebApi.Models;

namespace TodoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoGroupController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public TodoGroupController(TodoDbContext context)
        {
            _context = context;
        }

        public class TodogroupParams
        {
            public long UserId { get; set; }
        }

        // GET: api/TodoGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoGroup>>> GetTodoGroup([FromQuery] TodogroupParams pars)
        {
            var dbSet = _context.TodoGroup.Select(e => e);
            if (pars.UserId > 0)
            {
                dbSet = dbSet.Where(e => e.UserId == pars.UserId);
            }
            return await dbSet.ToListAsync();
        }

        // GET: api/TodoGroup/5
        [HttpGet("{id}")]
        public ActionResult<TodoGroup[]> GetTodoGroup(long id)
        {
            var todoGroup = _context.TodoGroup.Where(e => e.Id == id).ToArray();

            if (todoGroup == null)
            {
                return NotFound();
            }

            return todoGroup;
        }

        // PUT: api/TodoGroup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoGroup(long id, TodoGroup todoGroup)
        {
            if (id != todoGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoGroup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoGroup>> PostTodoGroup(TodoGroup todoGroup)
        {
            _context.TodoGroup.Add(todoGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoGroup", new { id = todoGroup.Id }, todoGroup);
        }

        // DELETE: api/TodoGroup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoGroup(long id)
        {
            var todoGroup = await _context.TodoGroup.FindAsync(id);
            if (todoGroup == null)
            {
                return NotFound();
            }

            _context.TodoGroup.Remove(todoGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoGroupExists(long id)
        {
            return _context.TodoGroup.Any(e => e.Id == id);
        }
    }
}
