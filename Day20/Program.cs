using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day20
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
            int target = int.Parse(data[0]);
            int[] houses = new int[3600000];
            for (int i = 1; i <= 3600000; i++)
            {
                for (int j = i; j < 3600000; j += i)
                {
                    houses[j] += i * 10;
                }
            }
            int min = 0;
            int count = 0;
            foreach (var i in houses)
            {
                if (i >= target)
                {
                    min = count;
                    break;
                }
                count++;
            }
            Console.WriteLine("First house in Part 1 is " + min);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            int target = int.Parse(data[0]);
            int[] houses = new int[3600000];
            for (int i = 1; i <= 3600000; i++)
            {
                for (int j = i; j < 3600000 && j <= i * 50; j += i)
                {
                    houses[j] += i * 11;
                }
            }
            int min = 0;
            int count = 0;
            foreach (var i in houses)
            {
                if (i >= target)
                {
                    min = count;
                    break;
                }
                count++;
            }
            Console.WriteLine("First house in Part 1 is " + min);
        }
    }
}
