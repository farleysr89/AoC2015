using System;
using System.Collections.Generic;

namespace Day25
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
            int row = 2978 - 1;
            int col = 3083 - 1;
            long firstCode = 20151125;
            long multi = 252533;
            long divisor = 33554393;
            List<List<long>> codes = new List<List<long>>
            {
                new List<long> { firstCode }
            };
            int x = 0, y = 1;
            int maxY = y;
            var prevCode = firstCode;
            while (true)
            {
                if (codes.Count <= y) codes.Add(new List<long>());

                long tmp = prevCode * multi;
                tmp %= divisor;
                codes[y].Add(tmp);
                prevCode = tmp;
                if (x == col && y == row) break;
                x++;
                y--;
                if (y < 0)
                {
                    maxY++;
                    y = maxY;
                    x = 0;
                }
            }
            Console.WriteLine("Solution is " + codes[row][col]);
        }

        static void SolvePart2()
        {
            Console.WriteLine("");
        }
    }
}
