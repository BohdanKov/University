using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.Services;
using University.Models;
using University.DAL;


namespace University.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentController : Controller
    {

        private StudentService studentService;

        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost("new")]
        public Student CreateStudent(Student student)
        {
            return studentService.AddStudent(student);
        }

        [HttpPatch("update/{id}")]
        public Student UpdateStudent(int id,[FromBody] Student student)
        {
            return studentService.ChangesStudent(id, student);
        }

        [HttpGet]
        public List<Student> GetStudents()
        {
            return studentService.GetStudentsList();
        }

        [HttpGet("rating/{id}")]
        public List<StudentRating> GetRatingBySubject(int id)
        {
            return studentService.GetStudentsRatingBySubject(id);
        }

        [HttpGet("rating")]
        public List<StudentRating> GetGeneralRating()
        {
            return studentService.GetStudentsGeneralRating();
        }

        [HttpDelete("delete/{id}")]
        public void DeleteStudent(int id)
        {
            studentService.RemoveStudent(id);
        }


    }
}
