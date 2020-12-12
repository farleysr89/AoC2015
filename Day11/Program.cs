using System;
using System.IO;
using System.Linq;

namespace Day11
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
            string pass = _input;
            while (!Validate(pass))
            {
                pass = Increment(pass);
            }
            Console.WriteLine("Next password = " + pass);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }

        static bool Validate(string pass)
        {
            if (pass.Contains('i') || pass.Contains('o') || pass.Contains('l')) return false;
            string[] inc = new string[]
            {
                "abc",
                "bcd",
                "cde",
                "def",
                "efg",
                "fgh",
                "ghi",
                "hij",
                "ijk",
                "jkl",
                "klm",
                "lmn",
                "mno",
                "nop",
                "opq",
                "pqr",
                "qrs",
                "rst",
                "stu",
                "tuv",
                "uvw",
                "vwx",
                "wxy",
                "xyz"
            };
            if (!inc.Any(s => pass.Contains(s))) return false;

            string[] dup = new string[]
            {
                "aa",
                "bb",
                "cc",
                "dd",
                "ee",
                "ff",
                "gg",
                "hh",
                "ii",
                "jj",
                "kk",
                "ll",
                "mm",
                "nn",
                "oo",
                "pp",
                "qq",
                "rr",
                "ss",
                "tt",
                "uu",
                "vv",
                "ww",
                "xx",
                "yy",
                "zz"
            };
            if (dup.Where(d => pass.Contains(d)).Count() < 2) return false;
            return true;
        }

        static string Increment(string pass)
        {
            var c = pass.ToCharArray();
            Array.Reverse(c);
            int index = 0;
            while (true)
            {
                if (c[index] == 'z')
                {
                    c[index] = 'a';
                    index++;
                    continue;
                }
                c[index]++;
                break;
            }
            Array.Reverse(c);
            return new string(c);
        }
    }
}
