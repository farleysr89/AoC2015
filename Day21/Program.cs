using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day21
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
            int hp, damage, armor;
            foreach (var s in data)
            {
                if (s == "") continue;
                var l = s.Split(": ");
                if (l[0] == "Hit Points") hp = int.Parse(l[1]);
                if (l[0] == "Armor") armor = int.Parse(l[1]);
                if (l[0] == "Damage") damage = int.Parse(l[1]);
            }
            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(new Weapon { name = "Dagger", cost = 8, damage = 4 });
            weapons.Add(new Weapon { name = "Shortsword", cost = 10, damage = 5 });
            weapons.Add(new Weapon { name = "Warhammer", cost = 25, damage = 6 });
            weapons.Add(new Weapon { name = "Longsword", cost = 40, damage = 7 });
            weapons.Add(new Weapon { name = "Greataxe", cost = 74, damage = 8 });

            List<Armor> armors = new List<Armor>();
            armors.Add(new Armor { name = "", cost = 0, armor = 0 });
            armors.Add(new Armor { name = "Leather", cost = 13, armor = 1 });
            armors.Add(new Armor { name = "Chainmail", cost = 31, armor = 2 });
            armors.Add(new Armor { name = "Splintmail", cost = 53, armor = 3 });
            armors.Add(new Armor { name = "Bandedmail", cost = 75, armor = 4 });
            armors.Add(new Armor { name = "Platemail", cost = 102, armor = 5 });

            List<Ring> rings = new List<Ring>();
            rings.Add(new Ring { name = "", cost = 0, armor = 0 });
            rings.Add(new Ring { name = "", cost = 0, armor = 0 });
            rings.Add(new Ring { name = "Damage +1", cost = 25, damage = 1 });
            rings.Add(new Ring { name = "Damage +2", cost = 50, damage = 2 });
            rings.Add(new Ring { name = "Damage +3", cost = 100, damage = 3 });
            rings.Add(new Ring { name = "Armor +1", cost = 20, armor = 1 });
            rings.Add(new Ring { name = "Armor +2", cost = 40, armor = 2 });
            rings.Add(new Ring { name = "Armor +3", cost = 80, armor = 3 });
            Console.WriteLine("");
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            Console.WriteLine("");
        }
    }
    class Weapon
    {
        public string name;
        public int damage;
        public int cost;
    }

    class Armor
    {
        public string name;
        public int armor;
        public int cost;
    }

    class Ring
    {
        public string name;
        public int armor;
        public int damage;
        public int cost;
    }
}
