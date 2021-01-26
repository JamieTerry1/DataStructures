/* Jamie Terry
 * Partners: Anthony Arellano, JunBo Park 
 * 
 * runtime: O(b)
 * 
 */

using System;
using System.Data;

namespace HW2_Prob1_JamieTerry
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        int product(int a, int b)
        {
            int sum = 0; 
            for (int i = 0; i < b; i++) //O(b)
            {
                sum += a; 
            }
            return sum;
        }
    }
}
