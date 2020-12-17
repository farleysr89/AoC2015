﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day16
{
    class Program
    {
        static int children = 3;
        static int cats = 7;
        static int samoyeds = 2;
        static int pomeranians = 3;
        static int akitas = 0;
        static int vizslas = 0;
        static int goldfish = 5;
        static int trees = 3;
        static int cars = 2;
        static int perfumes = 1;
        static void Main(string[] args)
        {
            SolvePart1();
            SolvePart2();
        }

        static void SolvePart1()
        {
            string _input = File.ReadAllText("Input.txt");
            var data = _input.Split('\n');
            List<AuntSue> aunts = new List<AuntSue>();
            foreach (var s in data)
            {
                if (s == "") continue;
                var line = s.Split(": ");
                var a = new AuntSue { title = line[0] };
                foreach (var i in s.Substring(s.IndexOf(":") + 1).Split(", "))
                {
                    var x = i.Trim().Split(": ");
                    if (x[0] == "children") a.children = int.Parse(x[1]);
                    if (x[0] == "cats") a.cats = int.Parse(x[1]);
                    if (x[0] == "samoyeds") a.samoyeds = int.Parse(x[1]);
                    if (x[0] == "pomeranians") a.pomeranians = int.Parse(x[1]);
                    if (x[0] == "akitas") a.akitas = int.Parse(x[1]);
                    if (x[0] == "vizslas") a.vizslas = int.Parse(x[1]);
                    if (x[0] == "goldfish") a.goldfish = int.Parse(x[1]);
                    if (x[0] == "trees") a.trees = int.Parse(x[1]);
                    if (x[0] == "cars") a.cars = int.Parse(x[1]);
                    if (x[0] == "perfumes") a.perfumes = int.Parse(x[1]);
                }
                aunts.Add(a);
            }
            List<AuntSue> poss = new List<AuntSue>();
            foreach (var a in aunts)
            {
                if ((children == a.children || a.children == null) &&
                    (cats == a.cats || a.cats == null) &&
                    (samoyeds == a.samoyeds || a.samoyeds == null) &&
                    (pomeranians == a.pomeranians || a.pomeranians == null) &&
                    (akitas == a.akitas || a.akitas == null) &&
                    (vizslas == a.vizslas || a.vizslas == null) &&
                    (goldfish == a.goldfish || a.goldfish == null) &&
                    (trees == a.trees || a.trees == null) &&
                    (cars == a.cars || a.cars == null) &&
                    (perfumes == a.perfumes || a.perfumes == null))
                {
                    poss.Add(a);
                }
            }
            Console.WriteLine("Correct answer is " + poss.First().title);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }
    }
    class AuntSue
    {
        public string title;
        public int? children;
        public int? cats;
        public int? samoyeds;
        public int? pomeranians;
        public int? akitas;
        public int? vizslas;
        public int? goldfish;
        public int? trees;
        public int? cars;
        public int? perfumes;
    }
}
