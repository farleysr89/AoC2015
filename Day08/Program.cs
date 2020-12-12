using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day08
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
            int total = 0;
            int newTotal = 0;
            foreach (var s in data)
            {
                total += s.Length;
                var a = Regex.Unescape(s);
                newTotal += a.Length - 2;
            }
            Console.WriteLine("Difference Part 1 = " + (total - newTotal));
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText(@"Input.txt");
            List<string> data = _input.Split('\n').ToList();

            int total = 0;
            int newTotal = 0;
            foreach (var s in data)
            {
                total += s.Length;
                newTotal += 2;
                foreach (char c in s)
                {
                    newTotal += c == '\\' || c == '\"' ? 2 : 1;
                }
            }

            Console.WriteLine("Difference Part 2 = " + (newTotal - total));
        }
    }
}
