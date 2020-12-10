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
            Console.WriteLine("Houses visited Part1 = " + houses.Count);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            HashSet<Tuple<int, int>> houses = new HashSet<Tuple<int, int>>();
            houses.Add(new Tuple<int, int>(x1, y1));
            bool robo = false;
            foreach (char c in _input)
            {
                if (!robo)
                {
                    switch (c)
                    {
                        case '<':
                            x1--;
                            break;
                        case '>':
                            x1++;
                            break;
                        case '^':
                            y1++;
                            break;
                        case 'v':
                            y1--;
                            break;
                        default:
                            break;
                    }
                    houses.Add(new Tuple<int, int>(x1, y1));
                }
                else
                {
                    switch (c)
                    {
                        case '<':
                            x2--;
                            break;
                        case '>':
                            x2++;
                            break;
                        case '^':
                            y2++;
                            break;
                        case 'v':
                            y2--;
                            break;
                        default:
                            break;
                    }
                    houses.Add(new Tuple<int, int>(x2, y2));
                }
                robo = !robo;
            }
            Console.WriteLine("Houses visited Part2 = " + houses.Count);
        }
    }
}
