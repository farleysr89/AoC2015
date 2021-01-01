using System;
using System.IO;

namespace Day23
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
            string[] data = _input.Split('\n');
            int index = 0;
            int a = 0, b = 0;
            string instruction = data[0];
            while (instruction != "")
            {
                var parts = instruction.Split(" ");
                if (parts[0] == "hlf")
                {
                    if (parts[1] == "a") a /= 2;
                    else if (parts[1] == "b") b /= 2;
                    else
                        Console.WriteLine("Something Broke!");
                    index++;
                }
                else if (parts[0] == "tpl")
                {
                    if (parts[1] == "a") a *= 3;
                    else if (parts[1] == "b") b *= 3;
                    else
                        Console.WriteLine("Something Broke!");
                    index++;
                }
                else if (parts[0] == "inc")
                {
                    if (parts[1] == "a") a += 1;
                    else if (parts[1] == "b") b += 1;
                    else
                        Console.WriteLine("Something Broke!");
                    index++;
                }
                else if (parts[0] == "jmp")
                {
                    index += int.Parse(parts[1]);
                }
                else if (parts[0] == "jie")
                {
                    int x = int.Parse(parts[2]);
                    if (parts[1] == "a," && a % 2 == 0) index += x;
                    else if (parts[1] == "b," && b % 2 == 0) index += x;
                    else index++;
                }
                else if (parts[0] == "jio")
                {
                    int x = int.Parse(parts[2]);
                    if (parts[1] == "a," && a == 1) index += x;
                    else if (parts[1] == "b," && b == 1) index += x;
                    else index++;
                }
                else
                {
                    Console.WriteLine("Something Broke");
                }
                instruction = data[index];
            }
            Console.WriteLine("b register int part 1 is " + b);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            string[] data = _input.Split('\n');
            int index = 0;
            int a = 1, b = 0;
            string instruction = data[0];
            while (instruction != "")
            {
                var parts = instruction.Split(" ");
                if (parts[0] == "hlf")
                {
                    if (parts[1] == "a") a /= 2;
                    else if (parts[1] == "b") b /= 2;
                    else
                        Console.WriteLine("Something Broke!");
                    index++;
                }
                else if (parts[0] == "tpl")
                {
                    if (parts[1] == "a") a *= 3;
                    else if (parts[1] == "b") b *= 3;
                    else
                        Console.WriteLine("Something Broke!");
                    index++;
                }
                else if (parts[0] == "inc")
                {
                    if (parts[1] == "a") a += 1;
                    else if (parts[1] == "b") b += 1;
                    else
                        Console.WriteLine("Something Broke!");
                    index++;
                }
                else if (parts[0] == "jmp")
                {
                    index += int.Parse(parts[1]);
                }
                else if (parts[0] == "jie")
                {
                    int x = int.Parse(parts[2]);
                    if (parts[1] == "a," && a % 2 == 0) index += x;
                    else if (parts[1] == "b," && b % 2 == 0) index += x;
                    else index++;
                }
                else if (parts[0] == "jio")
                {
                    int x = int.Parse(parts[2]);
                    if (parts[1] == "a," && a == 1) index += x;
                    else if (parts[1] == "b," && b == 1) index += x;
                    else index++;
                }
                else
                {
                    Console.WriteLine("Something Broke");
                }
                instruction = data[index];
            }
            Console.WriteLine("b register int part 2 is " + b);
        }
    }
}
