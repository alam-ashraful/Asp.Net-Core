using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{

    class Program : Account
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Account().AccountId());
        }
    }
}
