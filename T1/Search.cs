using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    public class Search
    {
        public static int FindElementAt(int[] arr, int elem)
        {
            int maxLength = arr.Length;
            int index = 0;
            while (index != maxLength)
            {
                if (arr[index] == elem)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        public static int BinarySearch(int[] arr, int l, int m, int elem)
        {
            int mid = l + (m - 1) / 2;

            if (m >= l)
            {
                if (arr[mid] == elem)
                    return mid;

                if (arr[mid] > elem)
                    return BinarySearch(arr, l, mid - 1, elem);
                return BinarySearch(arr, l, m + 1, elem);
            }

            return -1;
        }

        public static string FindDuplicate(int[] arr, int arrSize)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int i, j;

            for (i = 0; i < arrSize; i++)
            {
                for (j = i + 1; j < arrSize; j++)
                {
                    if (arr[i] == arr[j])
                        stringBuilder.Append(arr[i]);
                }
            }

            if (!string.IsNullOrEmpty(stringBuilder.ToString()))
                return stringBuilder.ToString();
            return "not found";
        }

        public static string SumFromTwoArray(int[] arr1, int[] arr2, int elem)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr2[j] == elem - arr1[i])
                    {
                        stringBuilder.Append(string.Format("First array : {0} > {1}\nSecond array: {2} > {3}\n", i.ToString(), arr1[i].ToString(), j.ToString(), arr2[j].ToString()));
                    }
                }
            }

            if (!string.IsNullOrEmpty(stringBuilder.ToString()))
                return stringBuilder.ToString();
            return "not found";
        }

        public static void SelectionSort(int[] array, int array_size)
        {
            int tmp, min_key;

            for (int j = 0; j < array_size - 1; j++)
            {
                min_key = j;

                for (int k = j + 1; k < array_size; k++)
                {
                    if (array[k] < array[min_key])
                    {
                        min_key = k;
                    }
                }

                tmp = array[min_key];
                array[min_key] = array[j];
                array[j] = tmp;
            }

            Console.WriteLine("The Array After Selection Sort is: ");
            for (int i = 0; i < array_size; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
