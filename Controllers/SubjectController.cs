using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using University.Services;
using University.Models;
using University.DAL;

namespace University.Controllers
{
    [ApiController]
    [Route("api/subjects")]
    public class SubjectController : Controller
    {
        private SubjectService subjectService;

        public SubjectController(SubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpPost("new")]
        public Subject AddNewSubjcet(Subject subject)
        {
            return subjectService.AddSubject(subject);
        }

        [HttpGet]
        public List<Subject> GetSubjects()
        {
            return subjectService.GetSubjectsList();
        }

        [HttpPatch("update/{id}")]
        public Subject UpdateSubject(int id, [FromBody] Subject subject)
        {
            return subjectService.ChangeSubject(id, subject);
        }

    }
}
