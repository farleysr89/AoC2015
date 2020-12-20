using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day21
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
            int hp = 0, damage = 0, armor = 0;
            foreach (var s in data)
            {
                if (s == "") continue;
                var l = s.Split(": ");
                if (l[0] == "Hit Points") hp = int.Parse(l[1]);
                if (l[0] == "Armor") armor = int.Parse(l[1]);
                if (l[0] == "Damage") damage = int.Parse(l[1]);
            }
            List<Weapon> weapons = new List<Weapon>
            {
                new Weapon { name = "Dagger", cost = 8, damage = 4 },
                new Weapon { name = "Shortsword", cost = 10, damage = 5 },
                new Weapon { name = "Warhammer", cost = 25, damage = 6 },
                new Weapon { name = "Longsword", cost = 40, damage = 7 },
                new Weapon { name = "Greataxe", cost = 74, damage = 8 }
            };

            List<Armor> armors = new List<Armor>
            {
                new Armor { name = "", cost = 0, armor = 0 },
                new Armor { name = "Leather", cost = 13, armor = 1 },
                new Armor { name = "Chainmail", cost = 31, armor = 2 },
                new Armor { name = "Splintmail", cost = 53, armor = 3 },
                new Armor { name = "Bandedmail", cost = 75, armor = 4 },
                new Armor { name = "Platemail", cost = 102, armor = 5 }
            };

            List<Ring> rings = new List<Ring>
            {
                new Ring { name = "", cost = 0, armor = 0 },
                new Ring { name = " ", cost = 0, armor = 0 },
                new Ring { name = "Damage +1", cost = 25, damage = 1 },
                new Ring { name = "Damage +2", cost = 50, damage = 2 },
                new Ring { name = "Damage +3", cost = 100, damage = 3 },
                new Ring { name = "Armor +1", cost = 20, armor = 1 },
                new Ring { name = "Armor +2", cost = 40, armor = 2 },
                new Ring { name = "Armor +3", cost = 80, armor = 3 }
            };
            int minCost = int.MaxValue;
            foreach (var w in weapons)
            {
                foreach (var a in armors)
                {
                    foreach (var r in rings)
                    {
                        foreach (var rr in rings.Where(x => x.name != r.name))
                        {
                            int cost = w.cost + a.cost + r.cost + rr.cost;
                            if (cost >= minCost) continue;
                            else if (Fight(hp, damage, armor, 100, w.damage + r.damage + rr.damage, a.armor + r.armor + rr.armor))
                            {
                                minCost = cost;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Minimum cost = " + minCost);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            int hp = 0, damage = 0, armor = 0;
            foreach (var s in data)
            {
                if (s == "") continue;
                var l = s.Split(": ");
                if (l[0] == "Hit Points") hp = int.Parse(l[1]);
                if (l[0] == "Armor") armor = int.Parse(l[1]);
                if (l[0] == "Damage") damage = int.Parse(l[1]);
            }
            List<Weapon> weapons = new List<Weapon>
            {
                new Weapon { name = "Dagger", cost = 8, damage = 4 },
                new Weapon { name = "Shortsword", cost = 10, damage = 5 },
                new Weapon { name = "Warhammer", cost = 25, damage = 6 },
                new Weapon { name = "Longsword", cost = 40, damage = 7 },
                new Weapon { name = "Greataxe", cost = 74, damage = 8 }
            };

            List<Armor> armors = new List<Armor>
            {
                new Armor { name = "", cost = 0, armor = 0 },
                new Armor { name = "Leather", cost = 13, armor = 1 },
                new Armor { name = "Chainmail", cost = 31, armor = 2 },
                new Armor { name = "Splintmail", cost = 53, armor = 3 },
                new Armor { name = "Bandedmail", cost = 75, armor = 4 },
                new Armor { name = "Platemail", cost = 102, armor = 5 }
            };

            List<Ring> rings = new List<Ring>
            {
                new Ring { name = "", cost = 0, armor = 0 },
                new Ring { name = " ", cost = 0, armor = 0 },
                new Ring { name = "Damage +1", cost = 25, damage = 1 },
                new Ring { name = "Damage +2", cost = 50, damage = 2 },
                new Ring { name = "Damage +3", cost = 100, damage = 3 },
                new Ring { name = "Armor +1", cost = 20, armor = 1 },
                new Ring { name = "Armor +2", cost = 40, armor = 2 },
                new Ring { name = "Armor +3", cost = 80, armor = 3 }
            };
            int maxCost = int.MinValue;
            foreach (var w in weapons)
            {
                foreach (var a in armors)
                {
                    foreach (var r in rings)
                    {
                        foreach (var rr in rings.Where(x => x.name != r.name))
                        {
                            int cost = w.cost + a.cost + r.cost + rr.cost;
                            if (cost <= maxCost) continue;
                            else if (!Fight(hp, damage, armor, 100, w.damage + r.damage + rr.damage, a.armor + r.armor + rr.armor))
                            {
                                maxCost = cost;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Maximum cost = " + maxCost);
        }

        static bool Fight(int hp1, int damage1, int armor1, int hp2, int damage2, int armor2)
        {
            int turns1 = (int)Math.Ceiling((double)hp1 / Math.Max(damage2 - armor1, 1));
            int turns2 = (int)Math.Ceiling((double)hp2 / Math.Max(damage1 - armor2, 1));
            return turns2 >= turns1;
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
