using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Day04
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
            int i = 0;
            while (true)
            {
                string tmp = MD5Hash(_input + i.ToString());
                if (tmp.Substring(0, 5) == "00000") break;
                i++;
            }
            Console.WriteLine("Answer is " + i);

        }

        static void SolvePart2()
        {
            string _input = File.ReadAllText("Input.txt");
        }

        // Function taken from here: https://www.godo.dev/tutorials/csharp-md5/
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
