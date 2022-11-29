using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using unimanagement_api.Entities.DB;
using unimanagement_api.Entitites;
using unimanagement_api.Models;

namespace unimanagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPASubjectsController : ControllerBase
    {
        private readonly UniversityMgtDBContext _context;

        public GPASubjectsController(UniversityMgtDBContext context)
        {
            _context = context;
        }

        // GET: api/GPASubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GPASubject>>> GetGPASubjects()
        {
            return await _context.GPASubjects.ToListAsync();
        }

        // GET: api/GPASubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GPAViewModel>> GetGPASubject(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            var gPASubjects = await _context.GPASubjects.ToListAsync();

            GPAViewModel gPAViewModel = new GPAViewModel();
            gPAViewModel.Score = student.GPA;
            gPAViewModel.GPASubjects = gPASubjects;

            if (gPASubjects.Count() == 0)
            {
                return NotFound();
            }

            return gPAViewModel;
        }

        // PUT: api/GPASubjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGPASubject(int id, GPASubject gPASubject)
        {
            if (id != gPASubject.Id)
            {
                return BadRequest();
            }

            _context.Entry(gPASubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GPASubjectExists(id))
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

        // POST: api/GPASubjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GPASubject>> PostGPASubject([FromBody]GPAViewModel gpaModel)
        {
            int studentId = gpaModel.GPASubjects.FirstOrDefault() != null ? gpaModel.GPASubjects.FirstOrDefault().StudentId : 0;

            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
            {
                return NotFound();
            }

            student.GPA = gpaModel.Score;
            student.HasCalculatedGPA = true;
            _context.Entry(student).State = EntityState.Modified;

            var existingSubjects = _context.GPASubjects.Where(x => x.StudentId == studentId).ToList();
            _context.GPASubjects.RemoveRange(existingSubjects);
            _context.GPASubjects.AddRange(gpaModel.GPASubjects);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/GPASubjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGPASubject(int id)
        {
            var gPASubject = await _context.GPASubjects.FindAsync(id);
            if (gPASubject == null)
            {
                return NotFound();
            }

            _context.GPASubjects.Remove(gPASubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GPASubjectExists(int id)
        {
            return _context.GPASubjects.Any(e => e.Id == id);
        }
    }
}
