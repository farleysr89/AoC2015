using System;
using System.IO;

namespace Day10
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
            Console.WriteLine(countnndSay(_input, 40).Length);
        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }

        // Returns n'th term in  
        // look-and-say sequence 
        // Taken from here: https://www.geeksforgeeks.org/look-and-say-sequence/
        static string countnndSay(string str, int n)
        {

            // Find n'th term by generating  
            // all terms from 3 to n-1.  
            // Every term is generated using 
            // previous term 
            for (int i = 1; i <= n; i++)
            {
                // In below for loop, previous  
                // character is processed in  
                // current iteration. That is  
                // why a dummy character is  
                // added to make sure that loop 
                // runs one extra iteration. 
                str += '$';
                int len = str.Length;

                int cnt = 1; // Initialize count of 
                             // matching chars 
                string tmp = ""; // Initialize i'th  
                                 // term in series 
                char[] arr = str.ToCharArray();

                // Process previous term  
                // to find the next term 
                for (int j = 1; j < len; j++)
                {
                    // If current character 
                    // does't match 
                    if (arr[j] != arr[j - 1])
                    {
                        // Append count of  
                        // str[j-1] to temp 
                        tmp += cnt + 0;

                        // Append str[j-1] 
                        tmp += arr[j - 1];

                        // Reset count 
                        cnt = 1;
                    }

                    // If matches, then increment  
                    // count of matching characters 
                    else cnt++;
                }

                // Update str 
                str = tmp;
            }

            return str;
        }
    }
}
