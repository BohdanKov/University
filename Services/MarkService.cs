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
    }
}
