using System;
using System.Collections.Generic;
using System.IO;

namespace Day13
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
            List<Relation> relations = new List<Relation>();
            foreach (var s in _input.Split('\n'))
            {
                var l = s.Split(" ");
                bool gain = l[2] == "gain";
                var r = new Relation { name1 = l[0], name2 = l[10], happiness = gain ? int.Parse(l[3]) : int.Parse(l[3]) * -1 };
                relations.Add(r);
            }
            Console.WriteLine();
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }
    }
    class Relation
    {
        public string name1;
        public string name2;
        public int happiness;
    }
}
