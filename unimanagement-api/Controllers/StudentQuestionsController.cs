﻿using System;
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
    public class StudentQuestionsController : ControllerBase
    {
        private readonly UniversityMgtDBContext _context;

        public StudentQuestionsController(UniversityMgtDBContext context)
        {
            _context = context;
        }

        // GET: api/StudentQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentQuestion>>> GetStudentQuestions()
        {
            return await _context.StudentQuestions.ToListAsync();
        }

        // GET: api/StudentQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentQuestion>> GetStudentQuestion(int id)
        {
            var studentQuestion = await _context.StudentQuestions.FindAsync(id);

            if (studentQuestion == null)
            {
                return NotFound();
            }

            return studentQuestion;
        }

        [HttpGet("quiz/{studentId}/{quizId}")]
        public List<StudentQuestion> GetStudentQuestions(int studentId, int quizId)
        {
            var studentQuestions = _context.StudentQuestions.Where(s => s.StudentId == studentId && s.QuizId == quizId).ToList();

            return studentQuestions;
        }

        [HttpGet("quiz/{quizId}")]
        public List<StudentQuestion> GetStudentQuestionsByQuizId(int quizId)
        {
            var studentQuestions = _context.StudentQuestions.Where(s => s.QuizId == quizId).GroupBy(p => p.StudentId).Select(g =>
                   new StudentQuestion { StudentId = g.Key }).ToList();

            return studentQuestions;
        }

        [HttpGet("results/{studentId}/{quizId}")]
        public List<StudentAnswerModel> GetStudentResults(int studentId, int quizId)
        {
            var answerList = _context.Questions.Where(q => q.QuizId == quizId).Join(_context.StudentQuestions, q => q.Id, s => s.QuestionId, (q, s) => new StudentAnswerModel
            {
                Text = q.Text,
                CorrectAnswer = q.CorrectAnswer,
                Answer1 = q.Answer1,
                Answer2 = q.Answer2,
                Answer3 = q.Answer3,
                StudentAnswerText = s.AnswerText,
                IsCorrectAnswer = s.IsCorrectAnswer,
                QuestionId = q.Id,
                QuizId = q.QuizId,
                StudentId = s.StudentId
            }).Where(a => a.StudentId == studentId && a.QuizId == quizId).ToList();

            return answerList;
        }

        // PUT: api/StudentQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentQuestion(int id, StudentQuestion studentQuestion)
        {
            if (id != studentQuestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentQuestionExists(id))
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

        // POST: api/StudentQuestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentQuestion>> PostStudentQuestion(List<StudentQuestion> studentQuestionsList)
        {
            _context.StudentQuestions.AddRange(studentQuestionsList);
            await _context.SaveChangesAsync();

            return Ok(studentQuestionsList);
        }

        // DELETE: api/StudentQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentQuestion(int id)
        {
            var studentQuestion = await _context.StudentQuestions.FindAsync(id);
            if (studentQuestion == null)
            {
                return NotFound();
            }

            _context.StudentQuestions.Remove(studentQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentQuestionExists(int id)
        {
            return _context.StudentQuestions.Any(e => e.Id == id);
        }
    }
}
