using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMetanit
{
    public static class SkipAndTake
    {
        public static void Example1()
        {
            var numbers = new[] { -3, -2, -1, 0, 1, 2, 3 };
            var result = numbers.Take(3);

            foreach (var r in result)
                Console.WriteLine(r);
        }

        public static void Example2()
        {
            var numbers = new[] { -3, -2, -1, 0, 1, 2, 3 };
            var result = numbers.Skip(3);

            foreach (var r in result)
                Console.WriteLine(r);
        }

        public static void Example3()
        {
            var numbers = new[] { -3, -2, -1, 0, 1, 2, 3 };
            var result = numbers.Skip(4).Take(3);

            foreach (var r in result)
                Console.WriteLine(r);
        }

        public static void Example4()
        {
            var teams = new [] { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
            var result = teams.TakeWhile(x => x.StartsWith("Б"));

            foreach (var r in result)
                Console.WriteLine(r);
        }

        public static void Example5()
        {
            var teams = new[] { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };
            var result = teams.SkipWhile(x => x.StartsWith("Б"));

            foreach (var r in result)
                Console.WriteLine(r);
        }
    }
}
