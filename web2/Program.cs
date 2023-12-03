namespace ThreadsSeminar
{
    internal class Program
    {

        //Напишите многопоточное приложение, которое определяет все
        //IP-адреса интернет-ресурса и определяет до которого из них лучше Ping.

        private static int _sum1 = 0;
        private static int _sum2 = 0;

        private static int[] _arr1 = { 1, 5, 8, 8, 7, 1, 7, 6, 4 };
        private static int[] _arr2 = { 1, 9, 2, 3, 1, 4, 6, 4, 4 };

        static void Main(string[] args)
        {

            Thread thread1 = new Thread(Task1);
            Thread thread2 = new Thread(Task2);

            thread1.Start();
            thread2.Start();
            thread1.Join(1000);

            Console.WriteLine($"{_sum1} : {_sum2} : {_sum1 + _sum2}");

        }

        public static void Task1(object? arr)
        {
            _sum1 = _arr1.Sum();
        }
        public static void Task2(object? arr)
        {
            _sum2 = _arr2.Sum();
        }


    }






}