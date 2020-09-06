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

        public Subject ChangeSubject(int id, Subject subject)
        {
            Subject updatedSubject = db.Subjects.Find(id);

            if(subject.NameOfSubject != null) { updatedSubject.NameOfSubject = subject.NameOfSubject; }
            if(subject.Teacher != null) { updatedSubject.Teacher = subject.Teacher; }
            db.SaveChanges();

            return updatedSubject;

        }
    }
}
