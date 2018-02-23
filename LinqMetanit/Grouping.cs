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

        public static void Example3()
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

            var groupsWithCount = from p in phones
                                  group p by p.Company into pg
                                  select new
                                  {
                                      Name = pg.Key,
                                      Count = pg.Count()
                                  };

            foreach (var g in groupsWithCount)
                Console.WriteLine("{0}: {1}", g.Name, g.Count);
        }

        public static void Example4()
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

            var groupsWithCount = phones.GroupBy(p => p.Company)
                                        .Select(g => new
                                        {
                                            Name = g.Key,
                                            Count = g.Count()
                                        });

            foreach (var g in groupsWithCount)
                Console.WriteLine("{0}: {1}", g.Name, g.Count);
        }

        public static void Example5()
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

            var groupsWithCount = phones.GroupBy(p => p.Company)
                                        .Select(g => new
                                        {
                                            Name = g.Key,
                                            Count = g.Count(),
                                            Phones = from p in g select p
                                        });

            foreach (var g in groupsWithCount)
            {
                Console.WriteLine("{0}: {1}", g.Name, g.Count);

                foreach (var p in g.Phones)
                    Console.WriteLine(p.Name);

                Console.WriteLine();
            }
        }

        public static void Example6()
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

            var groupsWithCount = phones.GroupBy(p => p.Company)
                                        .Select(g => new
                                        {
                                            Name = g.Key,
                                            Count = g.Count(),
                                            Phones = g.Select(p => p)
                                        });

            foreach (var g in groupsWithCount)
            {
                Console.WriteLine("{0}: {1}", g.Name, g.Count);

                foreach (var p in g.Phones)
                    Console.WriteLine(p.Name);

                Console.WriteLine();
            }
        }
    }
}
