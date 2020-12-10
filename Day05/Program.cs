using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day05
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
            List<string> strings = _input.Split('\n').ToList();
            List<string> niceStrings = new List<string>();
            string vowels = "aeiou";
            string[] badPairs = new string[]
            {
                "ab",
                "cd",
                "pq",
                "xy"
            };
            // Regex from here: https://stackoverflow.com/questions/2564092/net-regular-expression-for-n-number-of-consecutive-characters
            string reg = @"\S*(.)\1\S*";
            foreach (var s in strings)
            {
                bool bad = false;
                foreach(var b in badPairs)
                {
                    if (s.Contains(b))
                    {
                        bad = true;
                        break;
                    }
                }
                if (bad) continue;
                MatchCollection matches = Regex.Matches(s, reg);
                if (!matches.Any()) continue;
                if (s.Where(c => vowels.Contains(c)).Count() < 3) continue;
                niceStrings.Add(s);
            }
            Console.WriteLine("Nice strings Part 1 = " + niceStrings.Count());
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> strings = _input.Split('\n').ToList();
            List<string> niceStrings = new List<string>();
            string reg1 = @"(.)(.)(.*?)\1\2";
            string reg2 = @"(.).\1";
            foreach (var s in strings)
            {
                MatchCollection matches = Regex.Matches(s, reg1);
                if (!matches.Any()) continue;
                matches = Regex.Matches(s, reg2);
                if (!matches.Any()) continue;
                niceStrings.Add(s);
            }
            Console.WriteLine("Nice strings Part 2 = " + niceStrings.Count());
        }
    }
}

