using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZipAPI.Data;
using ZipAPI.Models;
using ZipAPI.ViewModels;

namespace ZipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ZipDbContext _context;
        private readonly IMapper _mapper;

        public AccountsController(ZipDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _context.Accounts
                .Include(account => account.User)
                .ToListAsync();
        }

        // GET: api/Accounts1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _context.Accounts
                .Include(account => account.User)
                .SingleOrDefaultAsync(account => account.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        // POST: api/Accounts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(AccountPostDTO accountPost)
        {
            var account = _mapper.Map<Account>(accountPost);
            try
            {
                var user = _context.Users.Find(account.UserId);
                if (user == null)
                {
                    return BadRequest("The user is not found.");
                }
                else if (user.MonthlySalary - user.MonthlyExpenses < 1000)
                {
                    return BadRequest("The user's monthly salary - expense is less than $1000. Cannot create account for the user.");
                }
                else
                {
                    _context.Accounts.Add(account);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException)
            {
                return BadRequest("One user can only have one account.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        }

    }
}
