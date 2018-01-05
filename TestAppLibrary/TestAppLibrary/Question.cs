using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppLibrary
{
    public class Question
    {
        public int Id { get; set; }
        public string Challenge { get; set; }
        public bool MultiChoice { get; set; }
        public int AnswersNumber { get; set; }
        public Exam Exam { get; set; }
    }
}
