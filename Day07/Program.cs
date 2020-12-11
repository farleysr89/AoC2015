using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day07
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
            data.Sort();
            Dictionary<string, int> evaluatedNodes = new Dictionary<string, int>();
            bool canEvaluate(string key) => evaluatedNodes.ContainsKey(key); 
            Console.WriteLine("");
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }
    }
}
