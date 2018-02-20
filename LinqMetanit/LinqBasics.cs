using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMetanit
{
    public static class LinqBasics
    {
        public static void Example1()
        {
            var teams = new[] { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };

            var selectedTeams = new List<string>();

            foreach (var t in teams)
            {
                if (t.ToUpper().StartsWith("Б"))
                    selectedTeams.Add(t);
            }

            selectedTeams.Sort();

            foreach (var t in selectedTeams)
                Console.WriteLine(t);
        }

        public static void Example2()
        {
            var teams = new[] { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };

            var selectedTeams = from t in teams
                                where t.ToUpper().StartsWith("Б")
                                orderby t
                                select t;

            foreach (var t in selectedTeams)
                Console.WriteLine(t);
        }

        public static void Example3()
        {
            var teams = new[] { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };

            var selectedTeams = teams.Where(t => t.ToUpper().StartsWith("Б"))
                                     .OrderBy(t => t);

            foreach (var t in selectedTeams)
                Console.WriteLine(t);
        }

        public static void Example4()
        {
            var teams = new[] { "Бавария", "Боруссия", "Реал Мадрид", "Манчестер Сити", "ПСЖ", "Барселона" };

            var count1 = (from t in teams
                          where t.ToUpper().StartsWith("Б")
                          select t)
                         .Count();

            var count2 = teams.Count(t => t.ToUpper().StartsWith("Б"));

            Console.WriteLine(count1 == count2);
        }
    }
}
