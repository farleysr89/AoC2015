using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day18
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
            bool[,] lights = new bool[100, 100];
            int x = 0, y = 0;
            foreach (var s in data)
            {
                if (s == "") continue;
                foreach (var c in s)
                {
                    lights[x, y] = c == '#';
                    x++;
                }
                y++;
                x = 0;
            }
            for (int i = 0; i < 100; i++)
            {
                bool[,] newLights = (bool[,])lights.Clone();
                for (x = 0; x < 100; x++)
                {
                    for (y = 0; y < 100; y++)
                    {
                        int count = CheckNeighbors(x, y, lights);
                        if (lights[x, y] && count != 2 && count != 3) newLights[x, y] = false;
                        if (!lights[x, y] && count == 3) newLights[x, y] = true;
                    }
                }
                lights = (bool[,])newLights.Clone();
            }
            int lightCount = 0;
            foreach (var b in lights)
            {
                if (b) lightCount++;
            }
            Console.WriteLine("Lighted lights Part 1 = " + lightCount);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            bool[,] lights = new bool[100, 100];
            int x = 0, y = 0;
            foreach (var s in data)
            {
                if (s == "") continue;
                foreach (var c in s)
                {
                    lights[x, y] = c == '#';
                    x++;
                }
                y++;
                x = 0;
            }
            lights[0, 0] = true;
            lights[0, 99] = true;
            lights[99, 0] = true;
            lights[99, 99] = true;
            for (int i = 0; i < 100; i++)
            {
                bool[,] newLights = (bool[,])lights.Clone();
                for (x = 0; x < 100; x++)
                {
                    for (y = 0; y < 100; y++)
                    {
                        int count = CheckNeighbors(x, y, lights);
                        if (lights[x, y] && count != 2 && count != 3) newLights[x, y] = false;
                        if (!lights[x, y] && count == 3) newLights[x, y] = true;
                    }
                }
                lights = (bool[,])newLights.Clone();
                lights[0, 0] = true;
                lights[0, 99] = true;
                lights[99, 0] = true;
                lights[99, 99] = true;
            }
            int lightCount = 0;
            foreach (var b in lights)
            {
                if (b) lightCount++;
            }
            Console.WriteLine("Lighted lights Part 2  = " + lightCount);
        }
        static int CheckNeighbors(int x, int y, bool[,] lights)
        {
            int count = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int h = y - 1; h <= y + 1; h++)
                {
                    if (i == x && h == y) continue;
                    if (i < 0 || h < 0 || i > 99 || h > 99) continue;
                    if (lights[i, h]) count++;
                }
            }
            return count;
        }
    }
}
