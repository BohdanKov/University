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
