using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1.Currency
{
    public class CurrencyConverter
    {
        public string Convert(int a)
        {
            switch (a)
            {
                case 1:
                    return "DOLLAR";
                case 2:
                    return "EURO";
                default:
                    return "invalid";
            }
        }
    }
}
