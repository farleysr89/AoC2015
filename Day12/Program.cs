using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace Day12
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
            var j = (JArray)JsonConvert.DeserializeObject(_input);
            Console.WriteLine("sum of part 1 = " + Calculate(j, null));

        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
            var j = (JArray)JsonConvert.DeserializeObject(_input);
            Console.WriteLine("Sum of part 2 = " + Calculate(j, "red"));
        }

        static long Calculate(JObject o, string filter)
        {
            if (o.Properties().Select(x => x.Value).OfType<JValue>().Select(x => x.Value).Contains(filter)) return 0;
            return o.Properties().Sum((dynamic a) => (long)Calculate(a.Value, filter));
        }
        static long Calculate(JArray arr, string filter) => arr.Sum((Func<dynamic, long>)((dynamic a) => (long)Calculate(a, filter)));
        static long Calculate(JValue val, string filter) => val.Type == JTokenType.Integer ? (long)val.Value : 0;
    }
}
