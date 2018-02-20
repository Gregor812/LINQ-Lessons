using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMetanit
{
    public static class Sorting
    {
        public static void Example1()
        {
            var numbers = new[] { 3, 12, 4, 10, 34, 20, 55, -66, 77, 88, 4 };

            var orderedNumbers = from n in numbers
                                 orderby n
                                 select n;

            foreach (var o in orderedNumbers)
                Console.WriteLine(o);
        }

        public static void Example2()
        {
            var users = new List<User>()
            {
                new User { Name = "Tom", Age = 33 },
                new User { Name = "Bob", Age = 30 },
                new User { Name = "Tom", Age = 21 },
                new User { Name = "Sam", Age = 43 }
            };

            var orderedUsers = from user in users
                               orderby user.Name ascending
                               select user;

            foreach (var o in orderedUsers)
                Console.WriteLine(o);
        }

        public static void Example3()
        {
            var users = new List<User>()
            {
                new User { Name = "Tom", Age = 33 },
                new User { Name = "Bob", Age = 30 },
                new User { Name = "Tom", Age = 21 },
                new User { Name = "Sam", Age = 43 }
            };

            var orderedUsers = users.OrderByDescending(user => user.Name);

            foreach (var o in orderedUsers)
                Console.WriteLine(o);
        }

        public static void Example4()
        {
            var users = new List<User>()
            {
                new User { Name = "Tom", Age = 33 },
                new User { Name = "Bob", Age = 30 },
                new User { Name = "Tom", Age = 21 },
                new User { Name = "Sam", Age = 43 }
            };

            var orderedUsers = from user in users
                               orderby user.Name ascending, user.Age, user.Name.Length
                               select user;

            foreach (var o in orderedUsers)
                Console.WriteLine(o);
        }

        public static void Example5()
        {
            var users = new List<User>()
            {
                new User { Name = "Tom", Age = 33 },
                new User { Name = "Bob", Age = 30 },
                new User { Name = "Tom", Age = 21 },
                new User { Name = "Sam", Age = 43 }
            };

            var orderedUsers = users.OrderByDescending(user => user.Name).ThenByDescending(user => user.Age).ThenByDescending(user => user.Name.Length);

            foreach (var o in orderedUsers)
                Console.WriteLine(o);
        }
    }
}
