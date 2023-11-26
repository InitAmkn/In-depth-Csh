using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les5
{
    public class MyDoubleTryParser
    {

        public double TryParse(string input)
        {

            try
            {
                double result = double.Parse(input);
                if (result >= 0)
                {
                    return result;

                }
                else
                {
                    throw new CalculatorExeption("Число отрицательное");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Это не число");
                return 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 0;
            }
        }
    }
}
