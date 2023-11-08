using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les5
{
    internal class Terminal
    {
        Calc calc = new Calc();
        private int numInput()
        {
            Console.Write("Введите число: ");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("число некорректно ");
                return numInput();
            }
        }

        private void operationInput(int inputNum)
        {
           
            Console.WriteLine("Выберите действие: \n" +
                   "+ : Слоение\n" +
                   "- : Вычитание\n" +
                   "* : Умножение\n" +
                   "/ : Деление\n" +
                   "< : Отмена действия\n");

            string? input = Console.ReadLine();
            switch (input)
            {
                case "+":
                    calc.Sum(inputNum);
                    break;
                case "-":
                    calc.Sub(inputNum);
                    break;
                case "*":
                    calc.Multiply(inputNum);
                    break;
                case "/":
                    calc.Divide(inputNum);
                    break;
                case "<":
                    calc.CancelLast();
                    break;
                default:
                    Console.WriteLine("Некорректный ввод операции");
                    operationInput(inputNum);
                    break;

            }
        }
        private static void Calc_MyEventHandler(object? sender, EventArgs s)
        {
            if (sender is Calc)
                Console.WriteLine(((Calc)sender).Result);
        }
        public void Start()
        {
            //Доработайте программу калькулятор реализовав
            //выбор действий и вывод результатов на экран в
            //цикле так чтобы калькулятор мог работать до
            //тех пор пока пользователь не нажмет отмена
            //или введёт пустую строку.

            
            calc.MyEventHandler += Calc_MyEventHandler;
            int inputNum = numInput();
            calc.Sum(inputNum);
            while (true)
            {
                inputNum = numInput();
                operationInput(inputNum);
            }

        }
    }
}

