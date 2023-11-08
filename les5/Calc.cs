using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les5
{
    internal class Calc : ICalc
    {
        public double Result { set; get; } = 0D;

        public event EventHandler<EventArgs>? MyEventHandler;
        List<double> ListResult { set; get; } = new List<double>();
        private void PrintResult()
        {
            MyEventHandler?.Invoke(this, new EventArgs());
        }
       
        public void Divide(int x)
        {
            if (x == 0)
            {
                saveHistory(Result);
                PrintResult();
                return;
            }
            Result /= x;
            saveHistory(Result);
            PrintResult();
        }

        public void Multiply(int x)
        {
            Result *= x;
            saveHistory(Result);
            PrintResult();
        }

        public void Sub(int x)
        {
            Result -= x;
            saveHistory(Result);
            PrintResult();
        }

        public void Sum(int x)
        {
            Result += x;
            saveHistory(Result);
            PrintResult();

        }
        public void CancelLast() {
            if(ListResult.Count>0)
            {
                ListResult.Remove(ListResult.Count-1);
                Result = ListResult[ListResult.Count - 1];
                PrintResult();
            }
        }
        private void saveHistory(double result)
        {

             ListResult.Add(result);
        }
    }
}
