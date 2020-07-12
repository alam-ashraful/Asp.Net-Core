using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace T1
{

    class Program : Account
    {
        static void Main(string[] args)
        {
            //Account A1 = new Account();
            //A1.SetName("Ashraful Alam");
            //A1.SetBalance(100000.3694);

            //Console.WriteLine("ID: {0}\nName: {1}\nBalance: {2:0.00}\n", A1.AccountId(), A1.GetName(), A1.GetBalance());
            int[] userArry = { 1, 5, 8, 56, 6, 88, 889 };
            int[] userArry1 = { 2, 5, 4, 50, 4, 85, 80, 889 };

            //Console.WriteLine("Found element at {0}", Search.FindElementAt(userArry, 56));
            //Console.WriteLine("Found element at {0}", Search.BinarySearch(userArry, 0, userArry.Length, 85));
            //Console.WriteLine("Found element at {0}", Search.FindDuplicate(userArry, userArry.Length));
            //Console.WriteLine(Search.SumFromTwoArray(userArry, userArry1, 10));

            //Search.SelectionSort(userArry1, userArry1.Length);

            int n = 25489;
            int sum = 0;
            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }

            Console.WriteLine("Sum of the digits of the said integer: " + sum);

        }
    }
}
