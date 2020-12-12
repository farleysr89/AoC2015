using System;
using System.IO;
using System.Text;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = SolvePart1();
            SolvePart2(s);
        }

        static string SolvePart1()
        {
            string _input = File.ReadAllText("Input.txt");
            for (int i = 1; i <= 40; i++)
            {
                _input = lookandsay(_input);
            }
            Console.WriteLine("Part 1 " + _input.Length);
            return _input;
        }

        static void SolvePart2(string s)
        {
            for (int i = 1; i <= 10; i++)
            {
                s = lookandsay(s);
            }
            Console.WriteLine("Part 2 " + s.Length);
        }

        static string lookandsay(string number)
        {
            StringBuilder result = new StringBuilder();

            char repeat = number[0];
            number = number.Substring(1, number.Length - 1) + " ";
            int times = 1;

            foreach (char actual in number)
            {
                if (actual != repeat)
                {
                    result.Append(Convert.ToString(times) + repeat);
                    times = 1;
                    repeat = actual;
                }
                else
                {
                    times += 1;
                }
            }
            return result.ToString();
        }
    }
}
