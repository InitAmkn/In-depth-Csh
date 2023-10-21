

using System.Security.Cryptography.X509Certificates;

namespace les3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Дан список целых чисел(числа не последовательны), 
            //в котором некоторые числа повторяются.
            //Выведите список чисел на экран, исключив из него повторы.
            List<int> ints = new List<int> { 0, 1, 1, -1, 101, 102, 101, 11, 1111, 11 };
            List<int> resolt = deleteRepetitions(ints);
            foreach (var item in resolt)
            {
                 Console.Write(item + " ");
            }
           
        }
        public static List<int> deleteRepetitions(List<int> ints)
        {
            List<int> resolt = new List<int>();
            foreach (int i in ints)
            {
                if (!ints.Contains(i))
                {
                    resolt.Add(i);
                }
            }
            return resolt;
        }

    }
}