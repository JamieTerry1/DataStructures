using System;

namespace HWWeek8_Prob1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 17, 22, 9, 5, 6, 19, 20 };
            int k = arr.Length;
            ThirdLargest(arr, k);
            NthLargest(arr, 5);

        }

        //method to find the 3rd largest element in a given array
        //RUNTME: O(n)
        static void ThirdLargest(int[] arr, int arr_size)
        {
            if (arr_size < 3)
            {
                Console.WriteLine("Input invalid");
                return;
            }

            //finding the first largest value 
            int first = arr[0];
            for (int i = 1; i < arr_size; i++)
            {
                if (arr[i] > first)
                    first = arr[i];
            }

            //finding the second largest value 
            int second = -int.MaxValue;
            for (int i = 0; i < arr_size; i++)
            {
                if (arr[i] > second && arr[i] < first)
                    second = arr[i];
            }

            //finding the third largest value 
            int third = -int.MaxValue;
            for (int i = 0; i < arr_size; i++)
            {
                if (arr[i] > third && arr[i] < second)
                {
                    third = arr[i];
                  
                }
            }
            Console.WriteLine("The third Largest element is " + third);
        }

        //method to find the Nth largest element in a given array 
        //RUNTIME: O(n)
        static void NthLargest(int[] arr, int n)
        {
            //sorts the given array 
            Array.Sort(arr);

            //Return N'th element in the sorted array 
            for (int i = arr.Length; i > int.MinValue; i--)
            {
                
                n--;

                if (n == 0)
                {
                    int value = arr[i-1];
                    Console.WriteLine("The Nth largest number is " + value);
                }
            }
                
            
        }
    }
}
