using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.DAL;
using University.Models;

namespace University.Services
{
    public class StudentService
    {
        UniversityContext db;

        public StudentService(UniversityContext db)
        {
            this.db = db;
        }

        public List<Student> GetStudentsList()
        {
            return db.Students.ToList();
        }
    }
}
