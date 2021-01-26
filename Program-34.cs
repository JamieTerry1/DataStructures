/* Jamie Terry 
 * Partners: JunBo Park, Anthony Arrellano 
 * 
 * Input
 * The first line of input contains a single integer n, (1 ≤ n ≤ 1000), which is the number 
 * of test matrices that follow. For each matrix being tested, the input will be a single line 
 * containing two integers separated by a space representing the number of rows r and columns c 
 * in the range between 1 and 10 inclusive, (1 ≤ r, c ≤ 10). This is followed by r rows each of 
 * c integers each separated by a space. All input is in row major order. Each integer is a valid 
 * 32-bit integer.

 * Output
 * For each matrix, output a single word yes or no in lowercase indicating whether it is diverse.
 * 
 * 
 */

using System;
using System.Linq;

namespace HW8_Prob3
{
    class Program
    {
        //RUNTIME: O(n^3)
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of matricies you would like to check. \nThen enter the number of rows and columns, seperated by a space.");
            Console.WriteLine("in each line, enter the contents of the row, with each number seperated by spaces. \nOnce the first matrix is filled, please enter the rows and columns of the next matrix");
            Console.WriteLine("Continue until all declared matrices are filled. ");

            //reads the number of matrices 
            int n = Convert.ToInt32(Console.ReadLine());
            //bool array to store if diverese or not 
            bool[] isDiverese = new bool[n];


            for (int i = 0; i < n; i++)
            {
                //stores values of rows and colums for matrix being checked 
                var stringArray = Console.ReadLine().Split(' ');
                int r = Convert.ToInt32(stringArray[0]);
                int c = Convert.ToInt32(stringArray[1]);

                //array to store the sums of each row 
                int[] sums = new int[r];

                //for loop to sum each element in the row 
                for (int j = 0; j < r; j++)
                {
                    var input = Console.ReadLine().Split(' ');
                    int sum = 0;
                    for ( int k = 0; k < c; k++)
                    {
                        sum += Convert.ToInt32(input[k]);
                    }
                    //adds sum to the array 
                    sums[j] = sum;

                }
                //if there are repeat sums, fills array with false, else fills with true 
                isDiverese[i] = sums.Length == sums.Distinct().Count();

                
            }

            //prints if the matrix is fiverese or not. 
            foreach (bool matrix in isDiverese)
            {
                if (matrix)
                {
                    Console.WriteLine("yes");
                }
                    
                else
                {
                    Console.WriteLine("no");
                }
            }
            
        }

      
       
    }
}
