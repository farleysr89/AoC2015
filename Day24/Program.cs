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
            int tmpTotal = 0;
            int index1 = 0;
            List<List<int>> solutions = new List<List<int>>();
            foreach (int i in dataArr)
            {
                List<int> sol = new List<int>
                {
                    i
                };
                tmpTotal = i;
                int index2 = index1 + 1;
                while (true)
                {
                    if (index2 >= dataArr.Length) break;
                    if (dataArr[index2] + tmpTotal > parcelSize)
                    {
                        index2++;
                        continue;
                    }
                    sol.Add(dataArr[index2]);
                    tmpTotal += dataArr[index2];
                    if (tmpTotal == parcelSize)
                    {
                        solutions.Add(sol);
                        break;
                    }
                    index2++;
                }
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
                Console.WriteLine("QE of solution is " + qe);
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
            Console.WriteLine("QE of solution is " + smallestQE);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
