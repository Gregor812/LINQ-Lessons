using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMetanit
{
    public class AllAny
    {
        public static void Example1()
        {
            var users = new List<User>()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };

            var result = users.All(u => u.Age > 20);

            if(result)
                Console.WriteLine("Возраст всех пользователей больше 20 лет.");
            else
                Console.WriteLine("Есть пользователи младше 20 лет.");

            bool result2 = users.All(u => u.Name.StartsWith("T"));

            if (result2)
                Console.WriteLine("У всех пользователей имя начинается с T.");
            else
                Console.WriteLine("Не у всех пользователей имя начинается с T.");
        }

        public static void Example2()
        {
            var users = new List<User>()
            {
                new User { Name = "Tom", Age = 23 },
                new User { Name = "Sam", Age = 43 },
                new User { Name = "Bill", Age = 35 }
            };

            bool result = users.Any(u => u.Age < 20);

            if (result)
                Console.WriteLine("Есть пользователи с возрастом меньше 20 лет.");
            else
                Console.WriteLine("Возраст всех пользователей больше 20 лет.");

            bool result2 = users.Any(u => u.Name.StartsWith("T"));

            if (result2)
                Console.WriteLine("Есть пользователи, имя которых начинается с T.");
            else
                Console.WriteLine("Нет ни одного пользователя, имя которого начинается с T.");
        }
    }
}
