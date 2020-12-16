using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day14
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
            List<Reindeer> reindeers = new List<Reindeer>();
            foreach (var s in data)
            {
                var l = s.Split(" ");
                var name = l[0];
                var speed = l[3];
                var flyTime = l[6];
                var restTime = l[13];
                reindeers.Add(new Reindeer { name = name, speed = int.Parse(speed), flyTime = int.Parse(flyTime), restTime = int.Parse(restTime) });
            }
            var sorted = reindeers.OrderByDescending(x => GetDistance(x));
            Console.WriteLine("Winning reindeer traveled " + GetDistance(sorted.First()) + "km");
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }

        static int GetDistance(Reindeer r)
        {
            int fullCycles = 2503 / r.TotalTime();
            int dist = r.speed * fullCycles * r.flyTime;
            int leftoverSeconds = 2503 - r.TotalTime() * fullCycles;
            return dist + (leftoverSeconds < r.flyTime ? leftoverSeconds * r.speed : r.flyTime * r.speed);
        }
    }
    class Reindeer
    {
        public string name;
        public int speed;
        public int flyTime;
        public int restTime;
        public int TotalTime()
        {
            return flyTime + restTime;
        }
    }
}
