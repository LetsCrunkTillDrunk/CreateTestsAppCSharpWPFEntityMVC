using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppLibrary
{
    public class UserQuestion
    {
        public int Id { get; set; }       
        public bool? IsRight { get; set; }
        public User User { get; set; }
        public Question Question { get; set; }
    }
}
