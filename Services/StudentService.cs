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

        public Student AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return student;
        }

        public Student ChangesStudent(int id, Student student)
        {
            Student updatedStudent = db.Students.Find(id);
            
            if(student.FirstName != null) { updatedStudent.FirstName = student.FirstName; }
            if(student.LastName != null) { updatedStudent.LastName = student.LastName; }
            if(student.Group != null) { updatedStudent.Group = student.Group; }
            db.SaveChanges();
           
            return updatedStudent;
        }

        public void RemoveStudent(int id)
        {
            db.Students.Remove(db.Students.First(r => r.ID == id));
            db.SaveChanges();
        }

        public List<Student> GetStudentsList()
        {
            return db.Students.ToList();
        }

        public List<StudentRating> GetStudentsRatingBySubject(int idSubj)
        {
            return GetRating(db.Marks.Where(m => m.SubjectID == idSubj).ToList());
        }

        public List<StudentRating> GetStudentsGeneralRating()
        {
            return GetRating(db.Marks.ToList());
        }

        public List<StudentRating> GetRating(List<Mark> listMarks)
        {
            List<StudentRating> studentsRating = new List<StudentRating>();

            while (listMarks.Any())
            {
                var currentStudentId = listMarks[0].StudentID;
                StudentRating stud = new StudentRating();
                var student = db.Students.Find(currentStudentId);
                stud.StudentFullName = student.FirstName + " " + student.LastName;

                float sum = 0;
                float count = 0;
                for(int i=0; i < listMarks.Count; i++)
                {
                    if(listMarks[i].StudentID == currentStudentId)
                    {
                        sum += listMarks[i].Grade;
                        count ++;
                        listMarks.Remove(listMarks[i]);
                        i--;
                    }
                }
                stud.AveregeGrade = (float)System.Math.Round(sum / count, 2);    
                studentsRating.Add(stud);   
            }
            studentsRating.Sort((x, y) => y.AveregeGrade.CompareTo(x.AveregeGrade));
            return studentsRating;
        }
    }
}
