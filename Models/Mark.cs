using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class Mark
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public int Grade { get; set; }
        public DateTime Date { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }

    }
}
