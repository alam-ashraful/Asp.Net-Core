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
            Account A1 = new Account();
            A1.SetName("Ashraful Alam");
            A1.SetBalance(100000.3694);

            Console.WriteLine("ID: {0}\nName: {1}\nBalance: {2:0.00}\n", A1.AccountId(), A1.GetName(), A1.GetBalance());

        }
    }
}
