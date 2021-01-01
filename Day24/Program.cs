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
            List<string> data = _input.Split('\n').ToList();
            int total = 0;
            foreach (var s in data)
            {
                if (s == "") continue;
                total += int.Parse(s);
            }
            int parcelSize = total / 3;
            Console.WriteLine("Total = " + total + " parcal size = " + parcelSize);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
}
