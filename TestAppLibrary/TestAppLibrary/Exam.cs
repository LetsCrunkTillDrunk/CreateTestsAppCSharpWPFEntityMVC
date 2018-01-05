using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppLibrary
{
        public class Exam
    {
        public Exam()
        {
            //this.Questions = new HashSet<Question>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuestionNumber { get; set; }
        public int QuestionToPass { get; set; }

        public int TimeToPass { get; set; }

        public Subject Subject { get; set; }

    }
}
