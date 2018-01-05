using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppLibrary
{
    public class Answer
    {
        public int Id { get; set; }
        public string Challenge { get; set; }

        public bool IsRight { get; set; }

        public Question Question { get; set; }
    }
}
