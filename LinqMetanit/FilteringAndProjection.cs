using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMetanit
{
    public static class FilteringAndProjection
    {
        public static void Example1()
        {
            var numbers = new[] { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            var evensGreaterThan10 = from n in numbers
                                     where (n % 2 == 0) && (n > 10)
                                     select n;

            foreach (var e in evensGreaterThan10)
                Console.WriteLine(e);
        }

        public static void Example2()
        {
            var numbers = new[] { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            var evensGreaterThan10 = numbers.Where(n => (n % 2 == 0) && (n > 10));

            foreach (var e in evensGreaterThan10)
                Console.WriteLine(e);
        }

        public static void Example3()
        {
            var users = new[]
            {
                new User {Name = "Том",  Age = 23, Languages = {"английский", "немецкий"}},
                new User {Name = "Боб",  Age = 27, Languages = {"английский", "французский"}},
                new User {Name = "Джон", Age = 29, Languages = {"английский", "испанский"}},
                new User {Name = "Элис", Age = 24, Languages = {"испанский", "немецкий"}}
            };

            var userOlderThan25 = from user in users
                                  where user.Age > 25
                                  select user;

            foreach (var u in userOlderThan25)
                Console.WriteLine(u);
        }

        public static void Example4()
        {
            var users = new[]
            {
                new User {Name = "Том",  Age = 23, Languages = {"английский", "немецкий"}},
                new User {Name = "Боб",  Age = 27, Languages = {"английский", "французский"}},
                new User {Name = "Джон", Age = 29, Languages = {"английский", "испанский"}},
                new User {Name = "Элис", Age = 24, Languages = {"испанский", "немецкий"}}
            };

            var userOlderThan25 = users.Where(user => user.Age > 25);

            foreach (var u in userOlderThan25)
                Console.WriteLine(u);
        }

        public static void Example5()
        {
            var users = new[]
            {
                new User {Name = "Том",  Age = 23, Languages = {"английский", "немецкий"}},
                new User {Name = "Боб",  Age = 27, Languages = {"английский", "французский"}},
                new User {Name = "Джон", Age = 29, Languages = {"английский", "испанский"}},
                new User {Name = "Элис", Age = 24, Languages = {"испанский", "немецкий"}}
            };

            var userYongerThan28AndKnowingEnglish = from user in users
                                                    from lang in user.Languages
                                                    where user.Age < 28
                                                    where lang == "английский"
                                                    select user;

            foreach (var u in userYongerThan28AndKnowingEnglish)
                Console.WriteLine(u);
        }

        public static void Example6()
        {
            var users = new[]
            {
                new User {Name = "Том",  Age = 23, Languages = {"английский", "немецкий"}},
                new User {Name = "Боб",  Age = 27, Languages = {"английский", "французский"}},
                new User {Name = "Джон", Age = 29, Languages = {"английский", "испанский"}},
                new User {Name = "Элис", Age = 24, Languages = {"испанский", "немецкий"}}
            };

            var userYongerThan28AndKnowingEnglish = users.Where(user => user.Languages.Contains("английский"))
                                                         .Where(user => user.Age < 28);

            foreach (var u in userYongerThan28AndKnowingEnglish)
                Console.WriteLine(u);
        }

        public static void Example7()
        {
            var users = new List<User>();

            users.Add(new User { Name = "Sam", Age = 43 });
            users.Add(new User { Name = "Tom", Age = 33 });

            var names = from user in users
                        select user.Name;

            foreach (var n in names)
                Console.WriteLine(n);
        }

        public static void Example8()
        {
            var users = new List<User>();

            users.Add(new User { Name = "Sam", Age = 43 });
            users.Add(new User { Name = "Tom", Age = 33 });

            var names = users.Select(user => user.Name);

            foreach (var n in names)
                Console.WriteLine(n);
        }

        public static void Example9()
        {
            var users = new List<User>();

            users.Add(new User { Name = "Sam", Age = 43 });
            users.Add(new User { Name = "Tom", Age = 33 });

            var items = from user in users
                        select new
                        {
                            FirstName = user.Name,
                            BirthYear = DateTime.Now.Year - user.Age
                        };

            foreach (var i in items)
                Console.WriteLine("{0} - {1}", i.FirstName, i.BirthYear);
        }

        public static void Example10()
        {
            var users = new List<User>();

            users.Add(new User { Name = "Sam", Age = 43 });
            users.Add(new User { Name = "Tom", Age = 33 });

            var items = users.Select(user => new
            {
                FirstName = user.Name,
                BirthYear = DateTime.Now.Year - user.Age
            });

            foreach (var i in items)
                Console.WriteLine("{0} - {1}", i.FirstName, i.BirthYear);
        }

        public static void Example11()
        {
            var users = new List<User>();

            users.Add(new User { Name = "Sam", Age = 43 });
            users.Add(new User { Name = "Tom", Age = 33 });

            var people = from user in users
                         let name = "Mr. " + user.Name
                         select new
                         {
                             Name = name,
                             user.Age
                         };

            foreach (var p in people)
                Console.WriteLine("{0} - {1}", p.Name, p.Age);
        }

        public static void Example12()
        {
            var users = new List<User>()
            {
                new User { Name = "Sam", Age = 43},
                new User { Name = "Tom", Age = 33 }
            };

            var phones = new List<Phone>()
            {
                new Phone { Name="Lumia 630", Company="Microsoft"},
                new Phone { Name="iPhone 6",  Company="Apple"}
            };

            var people = from u in users
                         from p in phones
                         select new
                         {
                             u.Name,
                             Phone = p.Name
                         };

            foreach (var p in people)
                Console.WriteLine("{0} - {1}", p.Name, p.Phone);
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public User()
        {
            Languages = new List<string>();
        }

        public override string ToString()
        {
            return $"{Name} - {Age}";
        }
    }

    public class Phone
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }
}
