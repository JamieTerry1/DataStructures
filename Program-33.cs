using System;

namespace HW8_Prob2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {10, 9, 8, 7, 6, 5, 4};
            int n = arr.Length;

            if (CheckSorted(arr, n) != 0)
            {
                Console.WriteLine("");
            }
            else
                Console.WriteLine("Not sorted");
           

        }

        static int CheckSorted(int[] arr, int n)
        {
            int i = 0;
            //if the array has one or no elements 
            if ( n == 1 || n == 0)
            {
                Console.WriteLine("There is not enough elements to check");
                return 1;
            }

            //if the next position is greater than 0th index 
            if (arr[i] < arr[i + 1])
            {
                if (arr[n - 1] < arr[n - 2])
                {
                    return 0;
                }

                Console.WriteLine("The array is sorted in ascending order");
                return 1;
            }

            //if the next position is less than 0th index 
            if (arr[i] > arr[i + 1])
            {
                if (arr[n-1] > arr[n - 2])
                {
                    return 0;
                }

                Console.WriteLine("The array is in descending order");
                return 1;
            }

            return CheckSorted(arr, n - 1);
        }
    }
}
