using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day09
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
            List<Route> routes = new List<Route>();
            HashSet<string> cities = new HashSet<string>();
            foreach (var s in data)
            {
                var x = s.Split(" ");
                var r = new Route { dist = int.Parse(x[4]) };
                r.ends[0] = x[0];
                r.ends[1] = x[2];
                cities.Add(x[0]);
                cities.Add(x[2]);
                routes.Add(r);
            }
            var sortedRoutes = routes.OrderBy(x => x.dist);
            int minDist = int.MaxValue;
            foreach (var r in sortedRoutes)
            {
                HashSet<string> visited = new HashSet<string>
                {
                    r.ends[0],
                    r.ends[1]
                };
                var tmpRoutes = new List<Route>(sortedRoutes);
                tmpRoutes.Remove(r);
                int tmp = CheckRoute(tmpRoutes, visited, cities, r.ends[1], r.dist);
                if (tmp < minDist) minDist = tmp;
                tmp = CheckRoute(tmpRoutes, visited, cities, r.ends[0], r.dist);
                if (tmp < minDist) minDist = tmp;
            }
            Console.WriteLine("Min distance = " + minDist);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            List<Route> routes = new List<Route>();
            HashSet<string> cities = new HashSet<string>();
            foreach (var s in data)
            {
                var x = s.Split(" ");
                var r = new Route { dist = int.Parse(x[4]) };
                r.ends[0] = x[0];
                r.ends[1] = x[2];
                cities.Add(x[0]);
                cities.Add(x[2]);
                routes.Add(r);
            }
            var sortedRoutes = routes.OrderByDescending(x => x.dist);
            int maxDist = int.MinValue;
            foreach (var r in sortedRoutes)
            {
                HashSet<string> visited = new HashSet<string>
                {
                    r.ends[0],
                    r.ends[1]
                };
                var tmpRoutes = new List<Route>(sortedRoutes);
                tmpRoutes.Remove(r);
                int tmp = CheckMaxRoute(tmpRoutes, visited, cities, r.ends[1], r.dist);
                if (tmp > maxDist) maxDist = tmp;
                tmp = CheckMaxRoute(tmpRoutes, visited, cities, r.ends[0], r.dist);
                if (tmp > maxDist) maxDist = tmp;
            }
            Console.WriteLine("Max distance = " + maxDist);
        }

        public static int CheckRoute(List<Route> routes, HashSet<string> visited, HashSet<string> cities, string last, int dist)
        {
            if (visited.Count == cities.Count) return dist;

            int minDist = int.MaxValue;
            foreach (var r in routes.Where(x => x.ends.Contains(last) && (!visited.Contains(x.ends[1]) || !visited.Contains(x.ends[0]))))
            {
                HashSet<string> tmpVisited = new HashSet<string>(visited)
                {
                    r.ends[1],
                    r.ends[0]
                };
                var tmpRoutes = new List<Route>(routes);
                tmpRoutes.Remove(r);
                int tmp = CheckRoute(tmpRoutes, tmpVisited, cities, last == r.ends[1] ? r.ends[0] : r.ends[1], dist + r.dist);
                if (tmp < minDist) minDist = tmp;
            }
            return minDist;
        }
        public static int CheckMaxRoute(List<Route> routes, HashSet<string> visited, HashSet<string> cities, string last, int dist)
        {
            if (visited.Count == cities.Count) return dist;

            int maxDist = int.MinValue;
            foreach (var r in routes.Where(x => x.ends.Contains(last) && (!visited.Contains(x.ends[1]) || !visited.Contains(x.ends[0]))))
            {
                HashSet<string> tmpVisited = new HashSet<string>(visited)
                {
                    r.ends[1],
                    r.ends[0]
                };
                var tmpRoutes = new List<Route>(routes);
                tmpRoutes.Remove(r);
                int tmp = CheckMaxRoute(tmpRoutes, tmpVisited, cities, last == r.ends[1] ? r.ends[0] : r.ends[1], dist + r.dist);
                if (tmp > maxDist) maxDist = tmp;
            }
            return maxDist;
        }
    }
    class Route
    {
        public string[] ends = new string[2];
        public int dist;
    }
}
