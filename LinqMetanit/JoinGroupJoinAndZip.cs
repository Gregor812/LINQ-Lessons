using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqMetanit
{
    public static class JoinGroupJoinAndZip
    {
        public static void Example1()
        {
            var teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country = "Германия" },
                new Team { Name = "Барселона", Country = "Испания" }
            };

            var players = new List<Player>()
            {
                new Player { Name = "Месси", Team = "Барселона"},
                new Player { Name = "Неймар", Team = "Барселона"},
                new Player { Name = "Роббен", Team = "Бавария"}
            };

            var result = from pl in players
                         join t in teams on pl.Team equals t.Name
                         select new { pl.Name, pl.Team, t.Country };

            foreach (var r in result)
                Console.WriteLine("{0} - {1} ({2})", r.Name, r.Team, r.Country);
        }

        public static void Example2()
        {
            var teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country = "Германия" },
                new Team { Name = "Барселона", Country = "Испания" }
            };

            var players = new List<Player>()
            {
                new Player { Name = "Месси", Team = "Барселона"},
                new Player { Name = "Неймар", Team = "Барселона"},
                new Player { Name = "Роббен", Team = "Бавария"}
            };

            var result = players.Join(teams, p => p.Team, t => t.Name, (p, t) => new { p.Name, p.Team, t.Country });

            foreach (var r in result)
                Console.WriteLine("{0} - {1} ({2})", r.Name, r.Team, r.Country);
        }

        public static void Example3()
        {
            var teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country = "Германия" },
                new Team { Name = "Барселона", Country = "Испания" }
            };

            var players = new List<Player>()
            {
                new Player { Name = "Месси", Team = "Барселона"},
                new Player { Name = "Неймар", Team = "Барселона"},
                new Player { Name = "Роббен", Team = "Бавария"}
            };

            var result = teams.GroupJoin(players,
                                         t => t.Name,
                                         p => p.Team,
                                         (team, pls) => new
                                         {
                                             team.Name,
                                             team.Country,
                                             Players = pls.Select(p => p.Name)
                                         });

            foreach (var g in result)
            {
                Console.WriteLine("{0} ({1})", g.Name, g.Country);

                foreach (var p in g.Players)
                    Console.WriteLine(p);

                Console.WriteLine();
            }
        }

        public static void Example4()
        {
            var teams = new List<Team>()
            {
                new Team { Name = "Бавария", Country ="Германия" },
                new Team { Name = "Барселона", Country ="Испания" },
                new Team { Name = "Ювентус", Country ="Италия" }
            };

            var players = new List<Player>()
            {
                new Player {Name="Роббен", Team="Бавария"},
                new Player {Name="Неймар", Team="Барселона"},
                new Player {Name="Буффон", Team="Ювентус"}
            };

            var result = players.Zip(teams, (p, t) => new { p.Name, p.Team, t.Country });

            foreach (var r in result)
                Console.WriteLine("{0} - {1} ({2})", r.Name, r.Team, r.Country);
        }
    }
}
