using System;
using System.Collections.Generic;
using T1.Currency;
using T1.LinkedList;
using T1.Sort;

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
            //int[] userArry = { 1, 5, 8, 56, 6, 88, 889 };
            //int[] userArry1 = { 2, 5, 4, 50, 4, 85, 80, 889 };

            //Console.WriteLine("Found element at {0}", Search.FindElementAt(userArry, 56));
            //Console.WriteLine("Found element at {0}", Search.BinarySearch(userArry, 0, userArry.Length, 85));
            //Console.WriteLine("Found element at {0}", Search.FindDuplicate(userArry, userArry.Length));
            //Console.WriteLine(Search.SumFromTwoArray(userArry, userArry1, 10));

            //Search.SelectionSort(userArry1, userArry1.Length);

            //int n = 25489;
            //int sum = 0;
            //while (n != 0)
            //{
            //    sum += n % 10;
            //    n /= 10;
            //}

            //Console.WriteLine("Sum of the digits of the said integer: " + sum);

            //List<MyList> myLists = new List<MyList>()
            //{
            //    new MyList(),
            //    new MyList()
            //};

            //myLists[0].AddSorted(9);
            //myLists[0].AddSorted(6);
            ////myLists[0].AddSorted(1);
            //myLists[0].AddSorted(1);

            //myLists[1].AddSorted(4);
            //myLists[1].AddSorted(-9);
            //myLists[1].AddSorted(-30);

            MyList myList1 = new MyList();
            MyList myList2 = new MyList();

            myList1.AddSorted(9);
            myList1.AddSorted(-61);
            myList1.AddSorted(1);
            myList1.AddSorted(100);

            myList2.AddSorted(4);
            myList2.AddSorted(-9);
            myList2.AddSorted(30);

            //Node rs = SortedMarge(myList1.headNode, myList2.headNode);
            //rs.Print();

            int[] a = new int[] { 61, 12, 33, 6, 4, 85 };
            //string[] arrStr = new string[] { "BOB", "TOM", "ASH", "CASH" };

            MargeSort2.sort<int>(a);
            //MargeSort2.sort<string>(arrStr);

            foreach (var item in a)
            {
                Console.Write($"->{item}");
            }

            //CurrencyConverter n = new CurrencyConverter();
            //Console.WriteLine("You entered for: {0}", n.Convert(1));
        }

        public static Node SortedMarge(Node A, Node B)
        {
            if (A == null) return B;
            if (B == null) return A;

            if (A.data < B.data)
            {
                A.next = SortedMarge(A.next, B);
                return A;
            }
            else
            {
                B.next = SortedMarge(A, B.next);
                return B;
            }
        }
    }
}
