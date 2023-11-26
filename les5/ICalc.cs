using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace les5
{
    internal interface ICalc

    {
        double Result { get; set; }
        void Sum(double x);
        void Sub(double x);
        void Multiply(double x);
        void Divide(double x);
        event EventHandler<EventArgs> MyEventHandler;
        void CancelLast() { }
    }
}
