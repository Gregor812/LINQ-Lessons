using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBase
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var evenNumbers = numbers
                             .Where(n => (n % 2) == 0)
                             .ToList();

            var evenSquares = evenNumbers
                             .Select(e => e * e)
                             .ToList();

            var firstFive = numbers
                           .Take(5)
                           .ToList();

            var lastFive = numbers
                          .Reverse()
                          .Take(5)
                          .Reverse()
                          .ToList();

            var exceptFirstFive = numbers
                                 .Skip(5)
                                 .ToList();

            var exceptLastFive = numbers
                                .Reverse()
                                .Skip(5)
                                .Reverse()
                                .ToList();

            foreach (var num in ParseNumbers(new[] { "-0", "+0000" }))
                Console.WriteLine(num);
            foreach (var num in ParseNumbers(new List<string> { "1", "", "-03", "0" }))
                Console.WriteLine(num);

            foreach (var point in Point.ParsePoints(new[] { "1 -2", "-3 4", "0 2" }))
                Console.WriteLine(point.X + " " + point.Y);
            foreach (var point in Point.ParsePoints(new List<string> { "+01 -0042" }))
                Console.WriteLine(point.X + " " + point.Y);

            var words = new[] { "ab", "", "c", "de" };
            var letters = words.SelectMany(w => w).ToList();  //IEnumerable<char> letters = words.SelectMany(w => w.ToCharArray()); -- the same

            Classroom[] classes =
            {
                new Classroom {Students = {"Pavel", "Ivan", "Petr"},},
                new Classroom {Students = {"Anna", "Ilya", "Vladimir"},},
                new Classroom {Students = {"Bulat", "Alex", "Galina"},}
            };
            var allStudents = Classroom.GetAllStudents(classes);
            Array.Sort(allStudents);
            Console.WriteLine(string.Join(" ", allStudents));
        }

        public static int[] ParseNumbers(IEnumerable<string> lines)
        {
            return lines
                  .Where(l => int.TryParse(l, out _))
                  .Select(i => int.Parse(i))
                  .ToArray();
        }
    }

    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static List<Point> ParsePoints(IEnumerable<string> lines)
        {
            return lines
                  .Select(l =>
                  {
                      var position = l
                                    .Split(' ')
                                    .Select(int.Parse)
                                    .ToArray();
                      return new Point(position[0], position[1]);
                  })
                  .ToList();
        }
    }

    public class Classroom
    {
        public List<string> Students = new List<string>();

        public static string[] GetAllStudents(Classroom[] classes)
        {
            return classes.SelectMany(c => c.Students).ToArray();
        }
    }
}
