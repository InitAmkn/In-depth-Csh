

using System.Security.Cryptography.X509Certificates;

namespace les3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           
            Maze maze = new Maze(new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 0, 0, 0, 0, 0, 1 },
                {1, 0, 1, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1, 0, 2 },
                {1, 1, 0, 0, 1, 1, 1 },
                {1, 1, 1, 0, 1, 2, 1 },
                {1, 1, 1, 2, 1, 1, 1 }
            });


            Console.WriteLine(maze.HasCountExit(3,0));

        }

    }
}