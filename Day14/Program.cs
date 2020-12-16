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
            Console.WriteLine("Winning reindeer traveled " + GetDistance(sorted.First()) + " km");
        }

        static void SolvePart2()
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
            for (int i = 1; i <= 2503; i++)
            {
                var max = reindeers.Max(r => GetDistance(r, i));
                foreach (var r in reindeers.Where(r => GetDistance(r, i) == max)) r.score++;
            }
            var sorted = reindeers.OrderByDescending(x => x.score);
            Console.WriteLine("Winning reindeer got " + sorted.First().score + " points");
        }

        static int GetDistance(Reindeer r)
        {
            int fullCycles = 2503 / r.TotalTime();
            int dist = r.speed * fullCycles * r.flyTime;
            int leftoverSeconds = 2503 - r.TotalTime() * fullCycles;
            return dist + (leftoverSeconds < r.flyTime ? leftoverSeconds * r.speed : r.flyTime * r.speed);
        }
        static int GetDistance(Reindeer r, int time)
        {
            int fullCycles = time / r.TotalTime();
            int dist = r.speed * fullCycles * r.flyTime;
            int leftoverSeconds = time - r.TotalTime() * fullCycles;
            return dist + (leftoverSeconds < r.flyTime ? leftoverSeconds * r.speed : r.flyTime * r.speed);
        }
    }
    class Reindeer
    {
        public string name;
        public int speed;
        public int flyTime;
        public int restTime;
        public int score = 0;
        public int TotalTime()
        {
            return flyTime + restTime;
        }
    }
}
