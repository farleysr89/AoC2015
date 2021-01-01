using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day19
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
            bool last = false;
            List<Rule> rules = new List<Rule>();
            string compound = "";
            foreach (var s in data)
            {
                if (s == "")
                {
                    last = true;
                    continue;
                }
                if (last)
                {
                    compound = s;
                }
                else
                {
                    var r = s.Split(" => ");
                    rules.Add(new Rule { input = r[0], output = r[1] });
                }
            }
            HashSet<string> outputs = new HashSet<string>();
            foreach (var r in rules)
            {
                for (int i = 0; i < compound.Length - (r.input.Length - 1); i++)
                {
                    if (compound.Substring(i, r.input.Length) == r.input)
                    {
                        var newString = compound.Substring(0, i) + r.output + compound[(i + r.input.Length)..];
                        outputs.Add(newString);
                    }
                }
            }
            Console.WriteLine("Total Possibilities = " + outputs.Count());
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            string s = data.Last();
            int l = Regex.Matches(s, "[A-Z]").Count;
            int c = Regex.Matches(s, "Ar").Count + Regex.Matches(s, "Rn").Count;
            int y = Regex.Matches(s, "Y").Count;
            Console.WriteLine("Minimum steps = " + (l - c - y * 2 - 1));
        }
    }
    class Rule
    {
        public string input;
        public string output;
    }
}
