using DotNet_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DotNet_Web_API.Data;

namespace DotNet_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRegController : ControllerBase
    {
        private readonly StudentDbContext _context;
        public StudentRegController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStudent()
        {
            var x = _context.Students.ToList();

            return Ok(x);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }



        [HttpPost]
        public IActionResult RegisterStudent(AddStudentDto addStudentDto)
        {
            var student = new Student
            {
                Name = addStudentDto.Name,
                Age = addStudentDto.Age ?? 0,
                Email = addStudentDto.Email
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok(student);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchStudent(int id, AddStudentDto dto)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            if (dto.Name != null)
                student.Name = dto.Name;

            if (dto.Age.HasValue)
                student.Age = dto.Age.Value;

            if (dto.Email != null)
                student.Email = dto.Email;

            _context.SaveChanges();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudentById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Ok($"Student with ID {id} has been deleted.");
        }



    }
}