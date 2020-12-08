using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day02
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
            string[] presents = _input.Split('\n');
            int sqFt = 0;
            foreach(string s in presents)
            {
                if (s != "")
                {
                    List<int> dims = s.Split("x").Select(x => int.Parse(x)).ToList();
                    dims.Sort();
                    sqFt += 2 * (dims[0] * dims[1]) + 2 * (dims[1] * dims[2]) + 2 * (dims[2] * dims[0]) + dims[0] * dims[1];
                }
            }
            Console.WriteLine("Total square feet of wrapping paper is " + sqFt + " ft");
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            string[] presents = _input.Split('\n');
            int ft = 0;
            foreach (string s in presents)
            {
                if (s != "")
                {
                    List<int> dims = s.Split("x").Select(x => int.Parse(x)).ToList();
                    dims.Sort();
                    ft += 2 * (dims[0] + dims[1]) + dims[0] * dims[1] * dims[2];
                }
            }
            Console.WriteLine("Total feet of ribbon is " + ft + " ft");
        }
    }
}
