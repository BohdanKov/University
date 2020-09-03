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
    }
}
