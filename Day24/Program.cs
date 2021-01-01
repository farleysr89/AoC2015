using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day24
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
            List<int> data = _input.Split('\n').Select(x => int.Parse(x)).ToList();
            int total = 0;
            foreach (var s in data)
            {
                total += s;
            }
            int parcelSize = total / 3;
            int[] dataArr = data.OrderByDescending(x => x).ToArray();
            Console.WriteLine("Total = " + total + " parcal size = " + parcelSize);
            int index1 = 1;
            HashSet<List<int>> solutions = new HashSet<List<int>>();
            foreach (int i in dataArr)
            {
                var tmp = new List<int> { i };
                var tmpSol = GetSolutions(tmp, dataArr[index1..], solutions, i, parcelSize);
                if (tmpSol != null) solutions.IntersectWith(tmpSol);
                index1++;
            }
            int min = solutions.Min(x => x.Count);
            List<List<int>> smallestSolutions = solutions.Where(x => x.Count == min).ToList();
            if (smallestSolutions.Count == 1)
            {
                int qe = 1;
                foreach (var i in smallestSolutions.First())
                {
                    qe *= i;
                }
                Console.WriteLine("QE of solution Part 1 is " + qe);
                return;
            }
            long smallestQE = long.MaxValue;
            foreach (var l in smallestSolutions)
            {
                long tmpQE = 1;
                foreach (var i in l)
                {
                    tmpQE *= i;
                }
                if (tmpQE < smallestQE) smallestQE = tmpQE;
            }
            Console.WriteLine("QE of solution Part 1 is " + smallestQE);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<int> data = _input.Split('\n').Select(x => int.Parse(x)).ToList();
            int total = 0;
            foreach (var s in data)
            {
                total += s;
            }
            int parcelSize = total / 4;
            int[] dataArr = data.OrderByDescending(x => x).ToArray();
            Console.WriteLine("Total = " + total + " parcal size = " + parcelSize);
            int index1 = 1;
            HashSet<List<int>> solutions = new HashSet<List<int>>();
            foreach (int i in dataArr)
            {
                var tmp = new List<int> { i };
                var tmpSol = GetSolutions(tmp, dataArr[index1..], solutions, i, parcelSize);
                if (tmpSol != null) solutions.IntersectWith(tmpSol);
                index1++;
            }
            int min = solutions.Min(x => x.Count);
            List<List<int>> smallestSolutions = solutions.Where(x => x.Count == min).ToList();
            if (smallestSolutions.Count == 1)
            {
                int qe = 1;
                foreach (var i in smallestSolutions.First())
                {
                    qe *= i;
                }
                Console.WriteLine("QE of solution Part 2 is " + qe);
                return;
            }
            long smallestQE = long.MaxValue;
            foreach (var l in smallestSolutions)
            {
                long tmpQE = 1;
                foreach (var i in l)
                {
                    tmpQE *= i;
                }
                if (tmpQE < smallestQE) smallestQE = tmpQE;
            }
            Console.WriteLine("QE of solution Part 2 is " + smallestQE);
        }
        static HashSet<List<int>> GetSolutions(List<int> curr, int[] dataArr, HashSet<List<int>> solutions, int total, int goal)
        {
            int index = 0;
            foreach (int i in dataArr)
            {
                index++;
                if (total + i > goal) continue;
                if (total + i == goal)
                {
                    curr.Add(i);
                    solutions.Add(curr);
                    return solutions;
                }
                else
                {
                    var tmp = new List<int>(curr)
                    {
                        i
                    };
                    var tmpSol = GetSolutions(tmp, dataArr[index..], solutions, total + i, goal);
                    if (tmpSol != null) solutions.IntersectWith(tmpSol);
                }
            }
            return solutions;
        }
    }
}
