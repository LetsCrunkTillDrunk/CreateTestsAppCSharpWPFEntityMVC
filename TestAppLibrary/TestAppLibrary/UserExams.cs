using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppLibrary
{
    public class UserExams
    {
        public int Id { get; set; }
        public bool? IsPassed { get; set; }
        public User User { get; set; }
        public Exam Exam { get; set; }
    }
}
