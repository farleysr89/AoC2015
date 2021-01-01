using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day06
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
            List<Instruction> instructions = new List<Instruction>();
            foreach (var s in data)
            {
                Instruction i = new Instruction();
                var x = s.Split(" ");
                if (x[0] == "toggle")
                {
                    i.command = x[0];
                    var xs = x[1].Split(",");
                    var ys = x[3].Split(",");
                    i.x1 = int.Parse(xs[0]);
                    i.y1 = int.Parse(xs[1]);
                    i.x2 = int.Parse(ys[0]);
                    i.y2 = int.Parse(ys[1]);
                }
                else
                {
                    i.command = x[0] + " " + x[1];
                    var xs = x[2].Split(",");
                    var ys = x[4].Split(",");
                    i.x1 = int.Parse(xs[0]);
                    i.y1 = int.Parse(xs[1]);
                    i.x2 = int.Parse(ys[0]);
                    i.y2 = int.Parse(ys[1]);
                }
                instructions.Add(i);
            }
            bool[,] lights = new bool[1000, 1000];
            foreach (var i in instructions)
            {
                switch (i.command)
                {
                    case "toggle":
                        for (int x = i.x1; x <= i.x2; x++)
                        {
                            for (int y = i.y1; y <= i.y2; y++)
                            {
                                lights[x, y] = !lights[x, y];
                            }
                        }
                        break;
                    case "turn on":
                        for (int x = i.x1; x <= i.x2; x++)
                        {
                            for (int y = i.y1; y <= i.y2; y++)
                            {
                                lights[x, y] = true;
                            }
                        }
                        break;
                    case "turn off":
                        for (int x = i.x1; x <= i.x2; x++)
                        {
                            for (int y = i.y1; y <= i.y2; y++)
                            {
                                lights[x, y] = false;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            int count = 0;
            foreach (var r in lights)
            {
                if (r) count++;
            }
            Console.WriteLine("Lighted lights for part 1 = " + count);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            List<Instruction> instructions = new List<Instruction>();
            foreach (var s in data)
            {
                Instruction i = new Instruction();
                var x = s.Split(" ");
                if (x[0] == "toggle")
                {
                    i.command = x[0];
                    var xs = x[1].Split(",");
                    var ys = x[3].Split(",");
                    i.x1 = int.Parse(xs[0]);
                    i.y1 = int.Parse(xs[1]);
                    i.x2 = int.Parse(ys[0]);
                    i.y2 = int.Parse(ys[1]);
                }
                else
                {
                    i.command = x[0] + " " + x[1];
                    var xs = x[2].Split(",");
                    var ys = x[4].Split(",");
                    i.x1 = int.Parse(xs[0]);
                    i.y1 = int.Parse(xs[1]);
                    i.x2 = int.Parse(ys[0]);
                    i.y2 = int.Parse(ys[1]);
                }
                instructions.Add(i);
            }
            int[,] lights = new int[1000, 1000];
            foreach (var i in instructions)
            {
                switch (i.command)
                {
                    case "toggle":
                        for (int x = i.x1; x <= i.x2; x++)
                        {
                            for (int y = i.y1; y <= i.y2; y++)
                            {
                                lights[x, y] = lights[x, y] + 2;
                            }
                        }
                        break;
                    case "turn on":
                        for (int x = i.x1; x <= i.x2; x++)
                        {
                            for (int y = i.y1; y <= i.y2; y++)
                            {
                                lights[x, y] = lights[x, y] + 1;
                            }
                        }
                        break;
                    case "turn off":
                        for (int x = i.x1; x <= i.x2; x++)
                        {
                            for (int y = i.y1; y <= i.y2; y++)
                            {
                                lights[x, y] = Math.Max(lights[x, y] - 1, 0);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            long count = 0;
            foreach (var r in lights)
            {
                count += r;
            }
            Console.WriteLine("Lighted lights for part 2 = " + count);
        }
    }

    class Instruction
    {
        public string command;
        public int x1, x2, y1, y2;
    }
}
