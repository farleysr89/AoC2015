using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day15
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
            Ingredient[] ingredients = new Ingredient[data.Count - 1];
            int count = 0;
            foreach (var s in data)
            {
                if (s == "") continue;
                var line = s.Split(":");
                var name = line[0];
                var values = line[1].Trim().Split(", ");
                var i = new Ingredient { name = name };
                foreach (var v in values)
                {
                    var x = v.Split(" ");
                    i.values.Add(x[0], int.Parse(x[1]));
                }
                ingredients[count] = i;
                count++;
            }
            int max = int.MinValue;
            for (int i = 0; i <= 100; i++)
            {
                for (int j = 0; j <= 100; j++)
                {
                    if (i + j > 100) break;
                    for (int k = 0; k <= 100; k++)
                    {
                        if (i + j + k > 100) break;
                        for (int l = 0; l <= 100; l++)
                        {
                            if (i + j + k + l > 100) break;
                            int a = Math.Max(0, i * ingredients[0].values["capacity"] +
                                                j * ingredients[1].values["capacity"] +
                                                k * ingredients[2].values["capacity"] +
                                                l * ingredients[3].values["capacity"]);
                            int b = Math.Max(0, i * ingredients[0].values["durability"] +
                                                j * ingredients[1].values["durability"] +
                                                k * ingredients[2].values["durability"] +
                                                l * ingredients[3].values["durability"]);
                            int c = Math.Max(0, i * ingredients[0].values["flavor"] +
                                                j * ingredients[1].values["flavor"] +
                                                k * ingredients[2].values["flavor"] +
                                                l * ingredients[3].values["flavor"]);
                            int d = Math.Max(0, i * ingredients[0].values["texture"] +
                                                j * ingredients[1].values["texture"] +
                                                k * ingredients[2].values["texture"] +
                                                l * ingredients[3].values["texture"]);
                            max = Math.Max(max, a * b * c * d);
                        }
                    }
                }
            }
            Console.WriteLine("Maximum cookie score is " + max);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }
    }
    class Ingredient
    {
        public string name;
        public Dictionary<string, int> values = new Dictionary<string, int>();
    }
}
