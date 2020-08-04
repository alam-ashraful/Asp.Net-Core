//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace T1.Sort
//{
//    public static class MargeSort
//    {
//        public static void sort<T>(T[] a)
//            where T : IComparable<T>
//        {
//            sort(a, 0, a.Length);
//        }

//        public static void sort<T>(T[] a, int low, int high)
//            where T : IComparable<T>
//        {
//            int N = high - low;
//            if (N <= 1)
//                return;

//            int mid = low + N / 2;

//            sort(a, low, mid);
//            sort(a, mid, high);

//            T[] aux = new T[N];
//            int i = low, j = mid;
//            for (int k = 0; k < N; k++)
//            {
//                if (i == mid) aux[k] = a[j++];
//                else if (j == high) aux[k] = a[i++];
//                else if (a[j].CompareTo(a[i]) < 0) aux[k] = a[j++];
//                else aux[k] = a[i++];
//            }

//            for (int k = 0; k < N; k++)
//            {
//                a[low + k] = aux[k];
//            }
//        }
//    }
//}
