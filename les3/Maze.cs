public class Maze
{
    /*
    Есть лабиринт описанный в виде двумерного массива 
    где 1 это стены, 0 - проход, 2 - искомая цель.
    Пример лабиринта:
    1 1 1 1 1 1 1
    1 0 0 0 0 0 1
    1 0 1 1 1 0 1
    0 0 0 0 1 0 2
    1 1 0 0 1 1 1
    1 1 1 1 1 1 1
    1 1 1 1 1 1 1
    Напишите алгоритм определяющий наличие выхода из 
    лабиринта и выводящий на экран  координаты точки выхода если таковые имеются.
    */
    private int[,] maze;

    public Maze(int[,] maze)
    {
        this.maze = maze;
    }

    public bool HasExit(int startI, int startJ)
    {
        if (maze[startI, startJ] == 1)
        {
            Console.WriteLine("Начальная точка находится в стене!");
            return false;
        }
        else if (maze[startI, startJ] == 2)
        {
            Console.WriteLine("Выход находится на входе");
            return true;
        }

        var stack = new Stack<Tuple<int, int>>();
        stack.Push(new(startI, startJ));

        while (stack.Count > 0)
        {
            var temp = stack.Pop();

            if (maze[temp.Item1, temp.Item2] == 2)
            {
                Console.WriteLine("Выход найден!");
                return true;
            }

            maze[temp.Item1, temp.Item2] = 1;

            if (temp.Item2 > 0 && maze[temp.Item1, temp.Item2 - 1] != 1)
                stack.Push(new(temp.Item1, temp.Item2 - 1)); // вверх

            if (temp.Item2 + 1 < maze.GetLength(1) && maze[temp.Item1, temp.Item2 + 1] != 1)
                stack.Push(new(temp.Item1, temp.Item2 + 1)); // низ

            if (temp.Item1 > 0 && maze[temp.Item1 - 1, temp.Item2] != 1)
                stack.Push(new(temp.Item1 - 1, temp.Item2)); // лево

            if (temp.Item1 + 1 < maze.GetLength(0) && maze[temp.Item1 + 1, temp.Item2] != 1)
                stack.Push(new(temp.Item1 + 1, temp.Item2)); // право
        }

        return false;
    }

    //    Доработайте приложение поиска пути в лабиринте, но на этот раз вам нужно определить сколько всего выходов имеется в лабиринте:

    //int[,] labirynth1 = new int[,]
    //{
    //{1, 1, 1, 1, 1, 1, 1 },
    //{1, 0, 0, 0, 0, 0, 1 },
    //{1, 0, 1, 1, 1, 0, 1 },
    //{0, 0, 0, 0, 1, 0, 0 },
    //{1, 1, 0, 0, 1, 1, 1 },
    //{1, 1, 1, 0, 1, 1, 1 },
    //{1, 1, 1, 0, 1, 1, 1 }
    //};

    //    Сигнатура метода:

    public int HasCountExit(int startI, int startJ)
    {
        if (maze[startI, startJ] == 1)
        {
            Console.WriteLine("Начальная точка находится в стене!");
            return 0;
        }
        else if (maze[startI, startJ] == 2)
        {
            Console.WriteLine("Выход находится на входе");
            return 1;
        }

        var stack = new Stack<Tuple<int, int>>();
        stack.Push(new(startI, startJ));
        int count = 0;
        while (stack.Count > 0)
        {
            var temp = stack.Pop();

            if (maze[temp.Item1, temp.Item2] == 2)
            {
                count++;
            }

            maze[temp.Item1, temp.Item2] = 1;

            if (temp.Item2 > 0 && maze[temp.Item1, temp.Item2 - 1] != 1)
                stack.Push(new(temp.Item1, temp.Item2 - 1)); // вверх

            if (temp.Item2 + 1 < maze.GetLength(1) && maze[temp.Item1, temp.Item2 + 1] != 1)
                stack.Push(new(temp.Item1, temp.Item2 + 1)); // низ

            if (temp.Item1 > 0 && maze[temp.Item1 - 1, temp.Item2] != 1)
                stack.Push(new(temp.Item1 - 1, temp.Item2)); // лево

            if (temp.Item1 + 1 < maze.GetLength(0) && maze[temp.Item1 + 1, temp.Item2] != 1)
                stack.Push(new(temp.Item1 + 1, temp.Item2)); // право
        }

        return count;
    }
}