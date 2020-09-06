﻿using System;
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


    }
}
