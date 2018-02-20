using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMetanit
{
    public static class Grouping
    {
        public static void Example1()
        {
            var phones = new List<Phone>()
            {
                new Phone {Name="Lumia 430", Company="Microsoft" },
                new Phone {Name="Mi 5", Company="Xiaomi" },
                new Phone {Name="LG G 3", Company="LG" },
                new Phone {Name="iPhone 5", Company="Apple" },
                new Phone {Name="Lumia 930", Company="Microsoft" },
                new Phone {Name="iPhone 6", Company="Apple" },
                new Phone {Name="Lumia 630", Company="Microsoft" },
                new Phone {Name="LG G 4", Company="LG" }
            };

            var phoneGroups = from phone in phones
                              group phone by phone.Company;

            foreach (var g in phoneGroups)
            {
                Console.WriteLine(g.Key);
                foreach (var p in g)
                    Console.WriteLine("    " + p.Name);
            }
        }

        public static void Example2()
        {
            var phones = new List<Phone>()
            {
                new Phone {Name="Lumia 430", Company="Microsoft" },
                new Phone {Name="Mi 5", Company="Xiaomi" },
                new Phone {Name="LG G 3", Company="LG" },
                new Phone {Name="iPhone 5", Company="Apple" },
                new Phone {Name="Lumia 930", Company="Microsoft" },
                new Phone {Name="iPhone 6", Company="Apple" },
                new Phone {Name="Lumia 630", Company="Microsoft" },
                new Phone {Name="LG G 4", Company="LG" }
            };

            var phoneGroups = phones.GroupBy(phone => phone.Company);

            foreach (var g in phoneGroups)
            {
                Console.WriteLine(g.Key);
                foreach (var p in g)
                    Console.WriteLine("    " + p.Name);
            }
        }
    }
}
