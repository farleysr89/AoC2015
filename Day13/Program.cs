using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day13
{
    class Program
    {
        static void Main()
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
                guests.Add(s1);
                guests.Add(s2);
                if (relations.Any(t => t.guests.Contains(s1) && t.guests.Contains(s2)))
                {
                    foreach (var r in relations)
                    {
                        if (r.guests.Contains(s1) && r.guests.Contains(s2))
                        {
                            r.happiness += gain ? int.Parse(x[3]) : int.Parse(x[3]) * -1;
                        }
                    }
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
            var sortedRelations = relations.OrderByDescending(x => x.happiness).ToList();
            int maxHappiness = int.MinValue;
            List<int> totals = new List<int>();
            foreach (var r in sortedRelations)
            {
                HashSet<string> visited = new HashSet<string>
                {
                    r.guests[0],
                    r.guests[1]
                };
                var tmpRelations = new List<Relation>(sortedRelations);
                tmpRelations.Remove(r);
                int tmp = CheckMaxRoute(tmpRelations, visited, guests, r.guests[1], r.happiness, r.guests[0]);
                totals.Add(tmp);
                if (tmp > maxHappiness) maxHappiness = tmp;
                tmp = CheckMaxRoute(tmpRelations, visited, guests, r.guests[0], r.happiness, r.guests[1]);
                totals.Add(tmp);
                if (tmp > maxHappiness) maxHappiness = tmp;
            }
            Console.WriteLine("Max Happiness = " + maxHappiness);
        }

        static void SolvePart2()
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
                guests.Add(s1);
                guests.Add(s2);
                if (relations.Any(t => t.guests.Contains(s1) && t.guests.Contains(s2)))
                {
                    foreach (var r in relations)
                    {
                        if (r.guests.Contains(s1) && r.guests.Contains(s2))
                        {
                            r.happiness += gain ? int.Parse(x[3]) : int.Parse(x[3]) * -1;
                        }
                    }
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
            foreach (var g in guests)
            {
                relations.Add(new Relation { guests = new string[] { "Santa", g }, happiness = 0 });
            }
            guests.Add("Santa");
            var sortedRelations = relations.OrderByDescending(x => x.happiness).ToList();
            int maxHappiness = int.MinValue;
            List<int> totals = new List<int>();
            foreach (var r in sortedRelations)
            {
                HashSet<string> visited = new HashSet<string>
                {
                    r.guests[0],
                    r.guests[1]
                };
                var tmpRelations = new List<Relation>(sortedRelations);
                tmpRelations.Remove(r);
                int tmp = CheckMaxRoute(tmpRelations, visited, guests, r.guests[1], r.happiness, r.guests[0]);
                totals.Add(tmp);
                if (tmp > maxHappiness) maxHappiness = tmp;
                tmp = CheckMaxRoute(tmpRelations, visited, guests, r.guests[0], r.happiness, r.guests[1]);
                totals.Add(tmp);
                if (tmp > maxHappiness) maxHappiness = tmp;
            }
            Console.WriteLine("Max Happiness = " + maxHappiness);
        }

        public static int CheckMaxRoute(List<Relation> relations, HashSet<string> added, HashSet<string> guests, string last, int happiness, string first)
        {
            if (added.Count == guests.Count) return happiness + relations.First(x => x.guests.Contains(last) && x.guests.Contains(first)).happiness;


            int maxHappiness = int.MinValue;
            foreach (var r in relations.Where(x => x.guests.Contains(last) && (!added.Contains(x.guests[1]) || !added.Contains(x.guests[0]))))
            {
                HashSet<string> tmpVisited = new HashSet<string>(added)
                {
                    r.guests[1],
                    r.guests[0]
                };
                var tmpRoutes = new List<Relation>(relations);
                tmpRoutes.Remove(r);
                int tmp = CheckMaxRoute(tmpRoutes, tmpVisited, guests, last == r.guests[1] ? r.guests[0] : r.guests[1], happiness + r.happiness, first);
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
