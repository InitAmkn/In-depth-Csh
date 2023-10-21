using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les2
{
    internal interface IBits
    {
        //Спроектируйте интерфейс для класса способного устанавливать и
        //получать  значения отдельных бит в  заданном числе. 
        // до 21:20

    }


    class Bits : IBits
    {
        public Bits(byte b)
        {
            this.Value = b;
        }

        public byte Value { get; private set; } = 0;
        public bool this[int index]
        {
            get
            {
                if (index > 7 || index < 0)
                    return false;
                return ((Value >> index) & 1) == 1;
            }
            set
            {
                if (index > 7 || index < 0) return;
                if (value == true)
                    Value = (byte)(Value | (1 << index));
                else
                {
                    var mask = (byte)(1 << index);
                    mask = (byte)(0xff ^ mask);
                    Value &= (byte)(Value & mask);
                }
            }
        }


        public static implicit operator byte(Bits b) => b.Value;
        public static explicit operator Bits(byte b) => new Bits(b);
    }
}
