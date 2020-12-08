using System;
using System.IO;

namespace Day01
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
            int floor = 0;
            foreach(char c in _input)
            {
                floor += c == '(' ? 1 : -1;
            }
            Console.WriteLine("Destination is floor " + floor);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            int floor = 0;
            int count = 0;
            foreach (char c in _input)
            {
                count++;
                floor += c == '(' ? 1 : -1;
                if (floor < 0) break;
            }
            Console.WriteLine("Basement index is " + count);
        }
    }
}
