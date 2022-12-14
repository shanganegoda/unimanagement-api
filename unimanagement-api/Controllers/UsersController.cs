using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using unimanagement_api.Entities.DB;
using unimanagement_api.Entitites;

namespace unimanagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UniversityMgtDBContext _context;

        public UsersController(UniversityMgtDBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            //Add to Student table
            Student student = new Student();
            student.Name = user.Username;
            student.Title = "";
            student.DOB = DateTime.Now;
            student.Description = "";
            student.GPA = 0;
            student.HasCalculatedGPA = false;
            _context.Students.Add(student);
            _context.SaveChanges();

            //Add to User table
            user.StudentId = student.Id;
            user.IsLecturer = false;
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // POST: api/Users/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Login")]
        public async Task<ActionResult<User>> LoginUser(User user)
        {
            var userEntity = await _context.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();
            if (userEntity == null)
            {
                return NotFound();
            } else if (userEntity.Password == user.Password)
            {
                return userEntity;
            }

            return NoContent();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
