using System;
using System.Collections.Generic;
using System.IO;

namespace Day03
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
            int x = 0;
            int y = 0;
            HashSet<Tuple<int,int>> houses = new HashSet<Tuple<int, int>>();
            houses.Add(new Tuple<int, int>(x, y));
            foreach(char c in _input)
            {
                switch (c)
                {
                    case '<':
                        x--;
                        break;
                    case '>':
                        x++;
                        break;
                    case '^':
                        y++;
                        break;
                    case 'v':
                        y--;
                        break;
                    default:
                        break;
                }
                houses.Add(new Tuple<int, int>(x, y));
            }
            Console.WriteLine("Houses visited = " + houses.Count);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }
    }
}
