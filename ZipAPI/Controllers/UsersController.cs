using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZipAPI.Data;
using ZipAPI.Models;

namespace ZipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ZipDbContext _context;

        public UsersController(ZipDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var result = _context.Users
                .Include(user => user.Account)
                .ToList();
            return result;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users
                .Include(user => user.Account)
                .SingleOrDefaultAsync(user => user.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            } catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
    }
}
