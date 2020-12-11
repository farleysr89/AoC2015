using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day07
{
    class Program
    {
        static void Main(string[] args)
        {
            int b = SolvePart1();
            SolvePart2(b);
        }

        static int SolvePart1()
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            data.Sort();
            Dictionary<string, int> evaluatedNodes = new Dictionary<string, int>();
            bool canEvaluate(string key) => evaluatedNodes.ContainsKey(key);
            while (true)
            {
                List<string> tmpData = new List<string>(data);
                foreach(var s in tmpData)
                {
                    var functs = new List<string> { "RSHIFT", "LSHIFT", "AND", "OR" };
                    var arguments = s.Split(" ");
                    int i = -1;
                    string key = "";
                    if (arguments[0] == "NOT")
                    {
                        if(int.TryParse(arguments[1],out int output))
                        {
                            key = arguments[3];
                            i = ~output;
                        }
                        else if (canEvaluate(arguments[1]))
                        {
                            key = arguments[3];
                            i = ~evaluatedNodes[arguments[1]];
                        }
                    }
                    else if (functs.Contains(arguments[1]))
                    {
                        if (arguments[1] == "RSHIFT")
                        {
                            if (int.TryParse(arguments[0], out int output1))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = output1 >> output2;                                    
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = output1 >> evaluatedNodes[arguments[2]];
                                }
                            }
                            if (canEvaluate(arguments[0]))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] >> output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] >> evaluatedNodes[arguments[2]];
                                }
                            }
                        }
                        else if (arguments[1] == "LSHIFT")
                        {
                            if (int.TryParse(arguments[0], out int output1))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = output1 << output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = output1 << evaluatedNodes[arguments[2]];
                                }
                            }
                            if (canEvaluate(arguments[0]))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] << output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] << evaluatedNodes[arguments[2]];
                                }
                            }
                        }
                        else if (arguments[1] == "AND")
                        {
                            if (int.TryParse(arguments[0], out int output1))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = output1 & output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = output1 & evaluatedNodes[arguments[2]];
                                }
                            }
                            if (canEvaluate(arguments[0]))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] & output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] & evaluatedNodes[arguments[2]];
                                }
                            }
                        }
                        else if (arguments[1] == "OR")
                        {
                            if (int.TryParse(arguments[0], out int output1))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = output1 | output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = output1 | evaluatedNodes[arguments[2]];
                                }
                            }
                            if (canEvaluate(arguments[0]))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] | output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] | evaluatedNodes[arguments[2]];
                                }
                            }
                        }                      
                    }
                    else if(arguments[1] == "->")
                    {
                        if (int.TryParse(arguments[0], out int output))
                        {
                            key = arguments[2];
                            i = int.Parse(arguments[0]);
                        }
                        else if (canEvaluate(arguments[0]))
                        {
                            key = arguments[2];
                            i = evaluatedNodes[arguments[0]];
                        }
                    }
                    else
                    {
                        Console.WriteLine("Something Broke! " + s);
                        break;
                    }
                    if (key != "")
                    {
                        evaluatedNodes.Add(key, i);
                        data.Remove(s);
                    }
                }
                if (data.Count == 0) break;
            }
            Console.WriteLine("value of a for part 1 is " + evaluatedNodes["a"]);
            return evaluatedNodes["a"];
        }

        static void SolvePart2(int b)
        {
            string _input = File.ReadAllText("Input.txt");
            List<string> data = _input.Split('\n').ToList();
            data.Sort();
            Dictionary<string, int> evaluatedNodes = new Dictionary<string, int>();
            bool canEvaluate(string key) => evaluatedNodes.ContainsKey(key);
            while (true)
            {
                List<string> tmpData = new List<string>(data);
                foreach (var s in tmpData)
                {
                    var functs = new List<string> { "RSHIFT", "LSHIFT", "AND", "OR" };
                    var arguments = s.Split(" ");
                    int i = -1;
                    string key = "";
                    if (arguments[0] == "NOT")
                    {
                        if (int.TryParse(arguments[1], out int output))
                        {
                            key = arguments[3];
                            i = ~output;
                        }
                        else if (canEvaluate(arguments[1]))
                        {
                            key = arguments[3];
                            i = ~evaluatedNodes[arguments[1]];
                        }
                    }
                    else if (functs.Contains(arguments[1]))
                    {
                        if (arguments[1] == "RSHIFT")
                        {
                            if (int.TryParse(arguments[0], out int output1))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = output1 >> output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = output1 >> evaluatedNodes[arguments[2]];
                                }
                            }
                            if (canEvaluate(arguments[0]))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] >> output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] >> evaluatedNodes[arguments[2]];
                                }
                            }
                        }
                        else if (arguments[1] == "LSHIFT")
                        {
                            if (int.TryParse(arguments[0], out int output1))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = output1 << output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = output1 << evaluatedNodes[arguments[2]];
                                }
                            }
                            if (canEvaluate(arguments[0]))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] << output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] << evaluatedNodes[arguments[2]];
                                }
                            }
                        }
                        else if (arguments[1] == "AND")
                        {
                            if (int.TryParse(arguments[0], out int output1))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = output1 & output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = output1 & evaluatedNodes[arguments[2]];
                                }
                            }
                            if (canEvaluate(arguments[0]))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] & output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] & evaluatedNodes[arguments[2]];
                                }
                            }
                        }
                        else if (arguments[1] == "OR")
                        {
                            if (int.TryParse(arguments[0], out int output1))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = output1 | output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = output1 | evaluatedNodes[arguments[2]];
                                }
                            }
                            if (canEvaluate(arguments[0]))
                            {
                                if (int.TryParse(arguments[2], out int output2))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] | output2;
                                }
                                else if (canEvaluate(arguments[2]))
                                {
                                    key = arguments[4];
                                    i = evaluatedNodes[arguments[0]] | evaluatedNodes[arguments[2]];
                                }
                            }
                        }
                    }
                    else if (arguments[1] == "->")
                    {
                        if (int.TryParse(arguments[0], out int output))
                        {
                            key = arguments[2];
                            i = int.Parse(arguments[0]);
                        }
                        else if (canEvaluate(arguments[0]))
                        {
                            key = arguments[2];
                            i = evaluatedNodes[arguments[0]];
                        }
                    }
                    else
                    {
                        Console.WriteLine("Something Broke! " + s);
                        break;
                    }
                    if (key != "")
                    {
                        if (key == "b") i = b;
                        evaluatedNodes.Add(key, i);
                        data.Remove(s);
                    }
                }
                if (data.Count == 0) break;
            }
            Console.WriteLine("value of a for part 2 is " + evaluatedNodes["a"]);
        }
    }
}
