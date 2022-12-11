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
    //[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly UniversityMgtDBContext _context;

        public QuestionsController(UniversityMgtDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Question>> Post([FromBody] Question question)
        {    
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            //return _context.Questions;
            return await _context.Questions.ToListAsync();
        }

        [HttpGet("{quizId}")]

        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions([FromRoute] int quizId)
        {
            return await _context.Questions.Where(q => q.QuizId == quizId).ToListAsync(); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion(int id, [FromBody] Question question)
        //public async Task<IActionResult> PutQuestion(int id, [FromBody] Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(question);
        }

        // DELETE: api/questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
