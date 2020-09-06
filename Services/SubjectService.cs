using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.DAL;
using University.Models;

namespace University.Services
{
    public class SubjectService
    {
        UniversityContext db;
        public SubjectService(UniversityContext db)
        {
            this.db = db;
        }

        public List<Subject> GetSubjectsList()
        {
            return db.Subjects.ToList();    
        }

        public Subject AddSubject(Subject subject)
        {
            db.Subjects.Add(subject);
            db.SaveChanges();
            return subject;
        }
    }
}
