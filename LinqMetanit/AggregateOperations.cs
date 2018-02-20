using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMetanit
{
    public static class AggregateOperations
    {
        public static void Example1()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };

            Console.WriteLine(numbers.Aggregate((x, y) => x - y));
            Console.WriteLine(numbers.Aggregate((x, y) => x + y));
        }

        public static void Example2()
        {
            var numbers = new[] { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
            var size = (from n in numbers
                        where (n % 2 == 0) && (n > 10)
                        select n)
                       .Count();

            Console.WriteLine(size);
        }

        public static void Example3()
        {
            var numbers = new[] { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
            var size = numbers.Count(n => (n % 2 == 0) && (n > 10));

            Console.WriteLine(size);
        }

        public static void Example4()
        {
            var numbers = new[] { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
            List<User> users = new List<User>()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };

            Console.WriteLine(numbers.Sum());
            Console.WriteLine();
        }

        public static void Example5()
        {
            int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };
            List<User> users = new List<User>()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };

            Console.WriteLine(numbers.Min());
            Console.WriteLine(users.Min(u => u.Age));

            Console.WriteLine(numbers.Max());
            Console.WriteLine(users.Max(u => u.Age));

            Console.WriteLine(numbers.Average());
            Console.WriteLine(users.Average(u => u.Age));
        }
    }
}
