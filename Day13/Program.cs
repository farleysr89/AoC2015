using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            SolvePart1();
            SolvePart2();
        }

        static void SolvePart1()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            List<Relation> relations = new List<Relation>();
            HashSet<string> guests = new HashSet<string>();
            foreach (var s in data)
            {
                var x = s.Split(" ");
                bool gain = x[2] == "gain";
                var s1 = x[0];
                var s2 = x[10].Remove(x[10].Length - 1, 1);
                if (relations.Any(r => r.guests.Contains(s1) && r.guests.Contains(s2)))
                {
                    relations.Where(r => r.guests.Contains(s1) && r.guests.Contains(s2)).Select(f => { f.happiness += gain ? int.Parse(x[3]) : int.Parse(x[3]) * -1; return f; });
                }
                else
                {
                    string[] g = new string[2];
                    g[0] = s1;
                    g[1] = s2;
                    var relation = new Relation { guests = g, happiness = gain ? int.Parse(x[3]) : int.Parse(x[3]) * -1 };
                    relations.Add(relation);
                }
            }
            Console.WriteLine();
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }

        public static int CheckMaxRoute(List<Relation> routes, HashSet<string> added, HashSet<string> guests, string last, int happiness)
        {
            if (added.Count == guests.Count) return happiness;

            int maxHappiness = int.MinValue;
            foreach (var r in routes.Where(x => x.guests.Contains(last) && (!added.Contains(x.guests[1]) || !added.Contains(x.guests[0]))))
            {
                HashSet<string> tmpVisited = new HashSet<string>(added)
                {
                    r.guests[1],
                    r.guests[0]
                };
                var tmpRoutes = new List<Relation>(routes);
                tmpRoutes.Remove(r);
                int tmp = CheckMaxRoute(tmpRoutes, tmpVisited, guests, last == r.guests[1] ? r.guests[0] : r.guests[1], happiness + r.happiness);
                if (tmp > maxHappiness) maxHappiness = tmp;
            }
            return maxHappiness;
        }
    }
    class Relation
    {
        public string[] guests = new string[2];
        public int happiness;
    }
}
