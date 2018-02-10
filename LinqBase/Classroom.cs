using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBase
{
    public class Classroom
    {
        public List<string> Students = new List<string>();

        public static string[] GetAllStudents(Classroom[] classes)
        {
            return classes.SelectMany(c => c.Students).ToArray();
        }
    }
}
