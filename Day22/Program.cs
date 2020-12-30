using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day22
{
    class Program
    {
        static readonly List<Spell> spells = new List<Spell> { new Spell { name = "Magic Missle", cost = 53, damage = 4 },
                                                               new Spell { name = "Drain", cost = 73, damage = 2, heal = 2 },
                                                               new Spell { name = "Shield", cost = 113, shield = 6 },
                                                               new Spell { name = "Poison", cost = 173, poison = 6 },
                                                               new Spell { name = "Recharge", cost = 229, recharge = 5 }};
        static void Main()
        {
            SolvePart1();
            SolvePart2();
        }

        static void SolvePart1()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            int hp = 0, damage = 0;
            foreach (var s in data)
            {
                if (s == "") continue;
                var l = s.Split(": ");
                if (l[0] == "Hit Points") hp = int.Parse(l[1]);
                if (l[0] == "Damage") damage = int.Parse(l[1]);
            }
            int playerHP = 50;
            int mana = 500;
            int lowestMana = Fight(hp, damage, playerHP, mana, 0, 0, 0, 0, true, int.MaxValue);


            Console.WriteLine("Lowest Mana = " + lowestMana);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            Console.WriteLine("");
        }

        static int Fight(int bossHP, int BossDamage, int playerHP, int playerMana, int shield, int poison, int recharge, int manaCost, bool playerTurn, int lowestCost)
        {
            //int lowestCost = int.MaxValue;
            if (bossHP <= 0) return manaCost;
            if (playerHP <= 0) return -1;
            if (manaCost > lowestCost) return -1;
            if (!playerTurn)
            {
                playerHP -= shield > 0 ? Math.Max(1, BossDamage - 7) : BossDamage;
                if (poison > 0) bossHP -= 3;
                if (recharge > 0) playerMana += 101;
                shield--;
                poison--;
                recharge--;
                return Fight(bossHP, BossDamage, playerHP, playerMana, shield, poison, recharge, manaCost, true, lowestCost);
            }
            else
            {
                if (poison > 0) bossHP -= 3;
                if (bossHP <= 0) return manaCost;
                if (recharge > 0) playerMana += 101;
                shield--;
                poison--;
                recharge--;
                if (!spells.Any(x => x.cost <= playerMana)) return -1;
                foreach (var s in spells.Where(x => x.cost <= playerMana))
                {
                    if (poison > 2 && s.poison > 0) continue;
                    if (shield > 2 && s.shield > 0) continue;
                    if (recharge > 2 && s.recharge > 0) continue;
                    int tmp = Fight(bossHP - s.damage, BossDamage, playerHP + s.heal, playerMana - s.cost, Math.Max(shield, s.shield), Math.Max(poison, s.poison), Math.Max(recharge, s.recharge), manaCost + s.cost, false, lowestCost);
                    if (tmp != -1)
                    {
                        lowestCost = Math.Min(lowestCost, tmp);
                    }
                }
            }
            return lowestCost;
        }
    }
    public class Spell
    {
        public string name;
        public int cost;
        public int damage;
        public int heal;
        public int shield;
        public int poison;
        public int recharge;
    }
}
