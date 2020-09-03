using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.DAL;
using University.Models;

namespace University.Services
{
    public class MarkService
    {
        UniversityContext db;

        public MarkService(UniversityContext db)
        {
            this.db = db;
        }

        public Mark AddMark(Mark mark)
        {
            db.Marks.Add(mark);
            db.SaveChanges();
            return mark;
        }

        public void UpdateMark(int id, int newValue)
        {
            Mark temp = db.Marks.First(e => e.ID == id);
            temp.Grade = newValue;
            db.SaveChanges();
        }

        public void DeleteMark(int id)
        {
            db.Marks.Remove(db.Marks.First(e => e.ID == id));
            db.SaveChanges();
        }
    }
}
