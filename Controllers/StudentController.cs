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
    
    public class StudentController : Controller
    {
        
        private StudentService studentService;

        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }
        [HttpGet("students")]
        public List<Student> GetStudents()
        {
            Console.WriteLine(studentService.GetStudentsList());
            return studentService.GetStudentsList();
        }
    }
}
