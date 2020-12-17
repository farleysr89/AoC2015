using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day17
{
    class Program
    {
        static int eggnog = 150;
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
    }
}
