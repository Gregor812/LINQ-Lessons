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
            var letters = words.SelectMany(w => w).ToList(); //IEnumerable<char> letters = words.SelectMany(w => w.ToCharArray()); -- the same

            Classroom[] classes =
            {
                new Classroom {Students = {"Pavel", "Ivan", "Petr"},},
                new Classroom {Students = {"Anna", "Ilya", "Vladimir"},},
                new Classroom {Students = {"Bulat", "Alex", "Galina"},}
            };
            var allStudents = Classroom.GetAllStudents(classes);
            Array.Sort(allStudents);
            Console.WriteLine(string.Join(" ", allStudents));

            var p = new Point(0, 0);
            var neighbours = Point.GetNeighbours(p);

            var gridDots = firstFive.SelectMany(left => firstFive.Select(right => new[] { left, right })).ToArray();

            var vocabulary = GetSortedWords(
                "Hello, hello, hello, how low",
                "",
                "With the lights out, it's less dangerous",
                "Here we are now; entertain us",
                "I feel stupid and contagious",
                "Here we are now; entertain us",
                "A mulatto, an albino, a mosquito, my libido...",
                "Yeah, hey"
            );
            foreach (var word in vocabulary)
                Console.WriteLine(word);
        }

        public static int[] ParseNumbers(IEnumerable<string> lines)
        {
            return lines
                  .Where(l => int.TryParse(l, out _))
                  .Select(i => int.Parse(i))
                  .ToArray();
        }

        public static string[] GetSortedWords(params string[] textLines)
        {
            return textLines.SelectMany(line => line.Split(new[] { " ", ",", ";", "...", "'" },
                                                           StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(s => s.ToLowerInvariant()))
                            .Distinct()
                            .OrderBy(s => s)
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

        public override bool Equals(object obj)
        {
            if (obj is Point p)
                return X == p.X && Y == p.Y;
            return false;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
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

        public static IEnumerable<Point> GetNeighbours(Point p)
        {
            int[] d = { -1, 0, 1 }; // используйте подсказку, если не понимаете зачем тут этот массив :)
            return d.SelectMany(dx => d.Select(dy => new Point(p.X + dx, p.Y + dy))).Where(point => !point.Equals(p));
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
