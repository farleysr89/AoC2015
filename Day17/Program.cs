using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day17
{
    class Program
    {
        static readonly int eggnog = 150;
        static void Main(string[] args)
        {
            SolvePart1();
            SolvePart2();
        }

        static void SolvePart1()
        {
            string _input = File.ReadAllText("Input.txt");
            List<int> containers = _input.Split('\n').Select(i => int.Parse(i)).ToList();
            int count = 0;
            var sorted = containers.OrderByDescending(x => x).ToList();
            int x = 1;
            foreach (var i in sorted)
            {
                var tmpList = new List<int>(sorted.Skip(x));
                count += TrySolve(eggnog - i, tmpList);
                x++;
            }
            Console.WriteLine("Total combinations = " + count);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<int> containers = _input.Split('\n').Select(i => int.Parse(i)).ToList();
            int count = 0;
            var sorted = containers.OrderByDescending(x => x).ToList();
            int x = 1;
            int minCount = int.MaxValue;
            foreach (var i in sorted)
            {
                var tmpList = new List<int>(sorted.Skip(x));
                minCount = Math.Min(minCount, TrySolveMin(eggnog - i, tmpList, 1));
                x++;
            }
            x = 1;
            foreach (var i in sorted)
            {
                var tmpList = new List<int>(sorted.Skip(x));
                count += TrySolveCountMin(eggnog - i, tmpList, 1, minCount);
                x++;
            }
            Console.WriteLine("Total combinations of min containers = " + count);
        }
        static int TrySolve(int remaining, List<int> containers)
        {
            if (remaining == 0) return 1;
            int count = 0;
            int x = 1;
            foreach (var i in containers)
            {
                if (i <= remaining)
                {
                    var tmpList = new List<int>(containers.Skip(x));
                    count += TrySolve(remaining - i, tmpList);
                }
                x++;
            }
            return count;
        }
        static int TrySolveMin(int remaining, List<int> containers, int conCount)
        {
            if (remaining == 0) return conCount;
            int minCount = int.MaxValue;
            int x = 1;
            foreach (var i in containers)
            {
                if (i <= remaining)
                {
                    var tmpList = new List<int>(containers.Skip(x));
                    minCount = Math.Min(minCount, TrySolveMin(remaining - i, tmpList, conCount + 1));
                }
                x++;
            }
            return minCount;
        }
        static int TrySolveCountMin(int remaining, List<int> containers, int conCount, int minCount)
        {
            if (conCount > minCount) return 0;
            if (remaining == 0) return conCount == minCount ? 1 : 0;
            int count = 0;
            int x = 1;
            foreach (var i in containers)
            {
                if (i <= remaining)
                {
                    var tmpList = new List<int>(containers.Skip(x));
                    count += TrySolveCountMin(remaining - i, tmpList, conCount + 1, minCount);
                }
                x++;
            }
            return count;
        }
    }
}
